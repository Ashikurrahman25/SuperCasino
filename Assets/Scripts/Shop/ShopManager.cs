using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    ProductManager productManager;
    public static ShopManager instance;

    public int coins;
    public int selectIndex;

    [Space]
    [Header("UI texts for showing details")]
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI megaBombCount;
    public TextMeshProUGUI bombCount;



    public Transform ballContainer;
    public Transform BGContainer;
    public Transform powerContainer;
    public GameObject prefab;

    public GameObject failedPanel;

    private void Awake()
    {
        if (instance != null) Destroy(instance);
        else instance = this;

        GlobalData.bomb = PlayerPrefs.GetInt("bomb", 0);
        GlobalData.megaBomb = PlayerPrefs.GetInt("megaBomb", 0);

        coins = PlayerPrefs.GetInt("coins", 100000000);
        GlobalData.selectedBall = PlayerPrefs.GetInt("selectedball",0);
        GlobalData.selectedBG = PlayerPrefs.GetInt("selectedBG",0);
    }

    public void Start()
    {
        productManager = ProductManager.instance;

        UpdatePowerup();
        UpdateCoin(0, false);

        SpawnBallItems();
        SpawnBGItems();
        SpawnPowerItems();
    }


    public void SpawnBallItems()
    {
        for (int i = 0; i < productManager.allLists.ballSkins.Length; i++)
        {
            GameObject item = Instantiate(prefab, ballContainer);
            item.GetComponent<ItemView>().isBall = true;

            if (productManager.allLists.ballSkins[i].isBought)
            {
                if (productManager.allLists.ballSkins[i].isSelected)
                {
                   item.GetComponent<ItemView>().SetDetail(productManager.allLists.ballSkins[i].productName,
                    "Selected", productManager.ballSprites[i]);
                    item.GetComponent<ItemView>().ChangeStatus(true);   
                }
                else
                {
                    item.GetComponent<ItemView>().SetDetail(productManager.allLists.ballSkins[i].productName,
                    "Select", productManager.ballSprites[i]);
                    item.GetComponent<ItemView>().ChangeStatus(false);
                }
                item.GetComponent<ItemView>().isBought = true;

            }
            else
            {              
                item.GetComponent<ItemView>().SetDetail(productManager.allLists.ballSkins[i].productName,
                productManager.allLists.ballSkins[i].productPrice.ToString("00"), productManager.ballSprites[i]);
            }
            
        }
    }

    public void SpawnBGItems()
    {
        for (int i = 0; i < productManager.allLists.backgrounds.Length; i++)
        {
            GameObject item = Instantiate(prefab, BGContainer);
            item.GetComponent<ItemView>().isBG = true;

            if (productManager.allLists.backgrounds[i].isBought)
            {
                if (productManager.allLists.backgrounds[i].isSelected)
                {
                    item.GetComponent<ItemView>().SetDetail(productManager.allLists.backgrounds[i].productName,
                     "Selected", productManager.bgIcons[i]);
                    item.GetComponent<ItemView>().ChangeStatus(true);
                }
                else
                {
                    item.GetComponent<ItemView>().SetDetail(productManager.allLists.backgrounds[i].productName,
                    "Select", productManager.bgIcons[i]);
                    item.GetComponent<ItemView>().ChangeStatus(false);  
                }

                item.GetComponent<ItemView>().isBought = true;

            }
            else
            {
                item.GetComponent<ItemView>().SetDetail(productManager.allLists.backgrounds[i].productName,
                productManager.allLists.backgrounds[i].productPrice.ToString("00"), productManager.bgIcons[i]);
            }

        }
    }

    public void SpawnPowerItems()
    {
        for (int i = 0; i < productManager.allLists.powerUps.Length; i++)
        {
            GameObject item = Instantiate(prefab, powerContainer);
            item.GetComponent<ItemView>().isPowerUp = true;

            item.GetComponent<ItemView>().SetDetail(productManager.allLists.powerUps[i].productName,
            productManager.allLists.powerUps[i].productPrice.ToString("00"), productManager.powerUpSprites[i]);
        }
    }
    public void UpdatePowerup()
    {
        bombCount.text = GlobalData.bomb.ToString("00");
        megaBombCount.text = GlobalData.megaBomb.ToString("00");


        PlayerPrefs.SetInt("bomb", GlobalData.bomb);
        PlayerPrefs.SetInt("megaBomb", GlobalData.megaBomb);
    }

    public void UpdateCoin(int coinToAdd, bool add)
    {
        if (add)
            coins += coinToAdd;
        else
            coins -= coinToAdd;

        coinCount.text = coins.ToString("00");
        PlayerPrefs.SetInt("coins", coins);
    }

    public void ActivateDeactivatePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
        AudioController.audioController.PlayButtonAudio();
    }
}
