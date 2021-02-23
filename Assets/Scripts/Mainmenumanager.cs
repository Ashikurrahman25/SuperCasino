using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Mainmenumanager : MonoBehaviour
{
    public TextMeshProUGUI Score;
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

        Score.text = "HighScore: " + PlayerPrefs.GetInt("highscore").ToString("00");
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

        if(ProductManager.instance.allLists.achievedPrizes.Count != 0)
        {
            for (int i = 0; i < ProductManager.instance.allLists.achievedPrizes.Count; i++)
            {
                GameObject gift = Instantiate(giftPrefab, giftContainer.transform);
                gift.GetComponent<GiftButtonView>().SetDetails(ProductManager.instance.prizeSprites[ProductManager.instance.allLists.achievedPrizes[i].iconIndex], ProductManager.instance.allLists.achievedPrizes[i].sellPrice);
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
