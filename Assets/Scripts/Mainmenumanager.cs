using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Mainmenumanager : MonoBehaviour
{
    public TextMeshProUGUI scoreEndless;
    public TextMeshProUGUI scoreArcade;
    public GameObject ModeSelectionPanel;

    public GameObject settingsPanel;
    public GameObject noIetm;


    public ShopManager shopManager;
    public int firstTimePlay;

    public GameObject[] shopPanels;

    public VibrationMusicControll vibrate;


    public GameObject giftContainer;
    public GameObject giftPanel;
    public GameObject giftPrefab;
    public GameObject infoPanel;


    public void ShowHideSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
        AudioController.audioController.PlayButtonAudio();
    }


    private void Start()
    {
      
        if (PlayerPrefs.GetInt("playcount", 0) == 0)
        {
            firstTimePlay++;
            PlayerPrefs.SetInt("playcount", firstTimePlay);
            ProductManager.instance.SaveLists();
        }
        else
        {
            int powerUps = PlayerPrefs.GetInt("total_powerups", 0);
            int balls = PlayerPrefs.GetInt("total_balls", 0);
            int bg = PlayerPrefs.GetInt("total_bg", 0);

            if(powerUps != ProductManager.instance.allLists.powerUps.Length
               || balls != ProductManager.instance.allLists.ballSkins.Length
               || bg != ProductManager.instance.allLists.backgrounds.Length)
            {
                ProductManager.instance.SaveLists();
            }
            else
            {
                ProductManager.instance.LoadList();
            }
        }

        scoreEndless.text = "Endless: " + PlayerPrefs.GetInt("endless").ToString("00");
        scoreArcade.text = "Arcade: " + PlayerPrefs.GetInt("arcade").ToString("00");
        vibrate = GetComponent<VibrationMusicControll>();
    }

    public void ArcadeMode()  
    {
        AudioController.audioController.PlayButtonAudio();
        SceneManager.LoadScene("Arcade");
    }
    public void LimitedMode()
    {
        AudioController.audioController.PlayButtonAudio();
        SceneManager.LoadScene("Three Lives");
    }

    public void Play()
    {
        AudioController.audioController.PlayButtonAudio();
        ModeSelectionPanel.SetActive(true);
    }

    public void Cross()
    {
        AudioController.audioController.PlayButtonAudio();
        ModeSelectionPanel.SetActive(false);
    }

    public void ActivateDeactivatePanel(GameObject panel)
    {
        AudioController.audioController.PlayButtonAudio();
        panel.SetActive(!panel.activeSelf);
    }

    public void Quit()
    {
        AudioController.audioController.PlayButtonAudio();
        Application.Quit();
    }

    public void ShowShopPanel(GameObject panelToActivate)
    {
        for (int i = 0; i < shopPanels.Length; i++)
        {
            shopPanels[i].SetActive(false);
        }

        panelToActivate.SetActive(true);
        AudioController.audioController.PlayButtonAudio();
    }

    public void HideShopPanel(GameObject panelToHide)
    {
        panelToHide.SetActive(false);
        AudioController.audioController.PlayButtonAudio();
    }

    public void GoToPrize()
    {
        giftPanel.SetActive(true);
        giftContainer.KillAllChild();

        if(ProductManager.instance.allLists.prizeVariations.Length != 0)
        {
            for (int i = 0; i < ProductManager.instance.allLists.prizeVariations.Length; i++)
            {
                GameObject gift = Instantiate(giftPrefab, giftContainer.transform);

                if (ProductManager.instance.allLists.prizeVariations[i].availableCount == 0)
                    gift.GetComponent<GiftButtonView>().overlay.SetActive (true);

                gift.GetComponent<GiftButtonView>().SetDetails(ProductManager.instance.prizeSprites[ProductManager.instance.allLists.prizeVariations[i].iconIndex], ProductManager.instance.allLists.prizeVariations[i].sellPrice, ProductManager.instance.allLists.prizeVariations[i].availableCount);
            }
        }
        else
        {
            ShowItem();

        }
        AudioController.audioController.PlayButtonAudio();
    }

    public void ShowItem()
    {
        noIetm.SetActive(true);
    }
}
