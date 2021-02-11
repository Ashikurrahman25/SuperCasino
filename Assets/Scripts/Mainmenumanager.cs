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

    public GameObject shopPanel;
    public Button shopButton;
    public Button backFromShopButton;

    public ShopManager shopManager;
    public int firstTimePlay;

    private void OnEnable()
    {
        shopButton.onClick.AddListener(delegate { ActivateDeactivatePanel(shopPanel); });
        backFromShopButton.onClick.AddListener(delegate { ActivateDeactivatePanel(shopPanel); });
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



    }

    private void Update()
    {
        Score.text = PlayerPrefs.GetInt("highscore").ToString();
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
}
