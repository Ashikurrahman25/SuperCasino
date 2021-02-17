using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Mainmenumanager : MonoBehaviour
{
    public Animator Anim;
    bool isHidden = false;
    public TextMeshProUGUI Score;
    public GameObject ModeSelectionPanel;

    public GameObject settingsPanel;


    public ShopManager shopManager;
    public int firstTimePlay;

    public GameObject[] shopPanels;


    public void ShowHideSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
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
            Debug.Log("Not First Time");
            ProductManager.instance.LoadList();
        }

        Score.text = "HighScore: " + PlayerPrefs.GetInt("highscore").ToString();


    }

    public void ArcadeMode()  
    {
        SceneManager.LoadScene("Arcade");
    }
    public void LimitedMode()
    {
       
        SceneManager.LoadScene("Three Lives");
    }

    public void Play()
    {
        ModeSelectionPanel.SetActive(true);
    }

    public void Cross()
    {
        ModeSelectionPanel.SetActive(false);
    }

    public void ActivateDeactivatePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
        shopManager.OnButtonClick(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ScoreShowHide()
    {
        
        if (isHidden)
        {
            Anim.Play("Show");
            isHidden = false;
            return;
        }
        else
        {
            Anim.Play("Hide");
            isHidden = true;
        }
    }

    public void ShowShopPanel(GameObject panelToActivate)
    {
        for (int i = 0; i < shopPanels.Length; i++)
        {
            shopPanels[i].SetActive(false);
        }

        panelToActivate.SetActive(true);
    }

    public void HideShopPanel(GameObject panelToHide)
    {
        panelToHide.SetActive(false);
    }
}
