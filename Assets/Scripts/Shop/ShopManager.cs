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
    public TextMeshProUGUI productTitle;
    public TextMeshProUGUI productPrice;
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI freezeCount;
    public TextMeshProUGUI speedCount;
    public TextMeshProUGUI slowCount;
    public TextMeshProUGUI doubleCount;

    [Space]
    [Header("Buy/sell button")]
    public Image[] allButtons;
    public Sprite activateSprite;
    public Sprite deactivateSprite;

    [Space]
    [Header("Prefabs and panels")]
    public GameObject productPrefab;
    public GameObject infoPanel;
    public GameObject clickedButton;
    public GameObject buyButtons;
    public GameObject buySellPanel;
    public GameObject coinBuyingPanel;
    public Transform productContainer;
    public Button buyButton;
    public Image productIcon;

    [Space]
    [Header("Booleans for managing sates")]
    [HideInInspector] public bool onPrizeChamber;
    [HideInInspector] public bool onBall;
    [HideInInspector] public bool onBG;
    [HideInInspector] public bool onPowerup;

    private void Awake()
    {
        if (instance != null) Destroy(instance);
        else instance = this;

        GlobalData.freezeCount = PlayerPrefs.GetInt("freeze", 0);
        GlobalData.speedCount = PlayerPrefs.GetInt("speed", 0);
        GlobalData.slowCount = PlayerPrefs.GetInt("slow", 0);
        GlobalData.doubleCount = PlayerPrefs.GetInt("double", 0);

        coins = PlayerPrefs.GetInt("coins", 0);
        GlobalData.selectedBall = PlayerPrefs.GetInt("selectedball",0);
        GlobalData.selectedBG = PlayerPrefs.GetInt("selectedBG",0);
    }

    public void Start()
    {
        productManager = ProductManager.instance;
        OnBallButton();

        UpdatePowerup();
        UpdateCoin(0, false);
       
    }


    public void OnButtonClick(int index)
    {
        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].sprite = deactivateSprite;
        }

        allButtons[index].sprite = activateSprite;
        productContainer.gameObject.KillAllChild();

        if (!infoPanel.activeSelf)
            infoPanel.SetActive(true);

        if (!buyButtons.activeSelf)
            buyButtons.SetActive(true);

        if (index == 0)
        {
            coinBuyingPanel.SetActive(false);
            buySellPanel.SetActive(true);

            OnBallButton();
            onPrizeChamber = false;
        }
        else if(index == 1)
        {
            buyButtons.SetActive(false);

            coinBuyingPanel.SetActive(false);
            buySellPanel.SetActive(true);

            for (int i = 0; i < productManager.allLists.achievedPrizes.Count; i++)
            {
                GameObject go = Instantiate(productPrefab, productContainer);

                if (productManager.prizeSprites[productManager.allLists.achievedPrizes[i].iconIndex] != null)
                {
                    Sprite sp = productManager.prizeSprites[productManager.allLists.achievedPrizes[i].iconIndex];
                    productIcon.sprite = sp;
                    go.transform.GetChild(0).GetComponent<Image>().sprite = sp;
                }
            }

            if(productManager.allLists.achievedPrizes.Count > 0)
            {
                productIcon.sprite = productManager.prizeSprites[productManager.allLists.achievedPrizes[0].iconIndex];
                productTitle.text = productManager.allLists.achievedPrizes[0].prizeName;
                productPrice.text = productManager.allLists.achievedPrizes[0].sellPrice.ToString("00");
            }
            else
            {
                infoPanel.SetActive(false);
            }

            onPrizeChamber = true;
            onBall = false;
            buyButton.GetComponentInChildren<Text>().text = "Sell";
        }
        else
        {
            coinBuyingPanel.SetActive(true);
            buySellPanel.SetActive(false);
            onPrizeChamber = false;
            onBall = false;
        }

    }

    public void OnBallButton()
    {
        productContainer.gameObject.KillAllChild();
        ResetAll();

        onBall = true;

        for (int i = 0; i < productManager.allLists.ballSkins.Length; i++)
        {
            GameObject go = Instantiate(productPrefab, productContainer);
           
            if (productManager.ballSprites[i] != null)
            {
                Texture2D tex = productManager.ballSprites[i];
                Sprite sp = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
                productIcon.sprite = sp;
                go.transform.GetChild(0).GetComponent<Image>().sprite = sp;
            }


        }

        productTitle.text = productManager.allLists.ballSkins[GlobalData.selectedBall].productName;
        productPrice.text = "Owned";
        buyButton.GetComponentInChildren<Text>().text = "Selected";


        if (productManager.ballSprites[GlobalData.selectedBall] != null)
        {
            Texture2D tex = productManager.ballSprites[GlobalData.selectedBall];
            productIcon.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

    public void OnBackGroundButton()
    {
        productContainer.gameObject.KillAllChild();
        ResetAll();

        onBG = true;

        for (int i = 0; i < productManager.allLists.backgrounds.Length; i++)
        {
            GameObject go = Instantiate(productPrefab, productContainer);

            if (productManager.backgroundSprites[i] != null)
            {
                Sprite sp = productManager.backgroundSprites[i];
                productIcon.sprite = sp;
                go.transform.GetChild(0).GetComponent<Image>().sprite = sp;
            }
        }

        productTitle.text = productManager.allLists.backgrounds[GlobalData.selectedBG].productName;
        productPrice.text = "Owned";
        buyButton.GetComponentInChildren<Text>().text = "Selected";

        if (productManager.backgroundSprites[GlobalData.selectedBG] != null)
            productIcon.sprite = productManager.backgroundSprites[GlobalData.selectedBG];
    }

    public void OnPowerUpButton()
    {
        productContainer.gameObject.KillAllChild();
        ResetAll();

        onPowerup = true;

        for (int i = 0; i < productManager.allLists.powerUps.Length; i++)
        {
            GameObject go = Instantiate(productPrefab, productContainer);
            if (productManager.powerUpSprites[i] != null)
            {
                Sprite sp = productManager.powerUpSprites[i];
                productIcon.sprite = sp;
                go.transform.GetChild(0).GetComponent<Image>().sprite = sp;
            }
        }

        productTitle.text = productManager.allLists.powerUps[0].productName;
        productPrice.text = productManager.allLists.powerUps[0].productPrice.ToString("00");
        buyButton.GetComponentInChildren<Text>().text = "Buy";
    }


    public void OnBuyButton()
    {
        if (!onPrizeChamber)
        {
            if (onBall)
            {
                if (productManager.allLists.ballSkins[selectIndex].isBought)
                {
                    buyButton.GetComponentInChildren<Text>().text = "Selected";
                    GlobalData.selectedBall = selectIndex;
                    PlayerPrefs.SetInt("selectedball", GlobalData.selectedBall);

                    for (int i = 0; i < productManager.allLists.ballSkins.Length; i++)
                    {
                        productManager.allLists.ballSkins[i].isSelected = false;
                    }

                    productManager.allLists.ballSkins[selectIndex].isSelected = true;
                }
                else
                {
                    if(coins >= productManager.allLists.ballSkins[selectIndex].productPrice)
                    {

                        productManager.allLists.ballSkins[selectIndex].isBought = true;
                        buyButton.GetComponentInChildren<Text>().text = "Select";
                        productPrice.text = "Owned";
                        UpdateCoin(productManager.allLists.ballSkins[selectIndex].productPrice, false);
                    }
                    else
                    {
                        Debug.Log("Not Enough Coins!");
                    }
                }
            }
            else if (onBG)
            {
                if (productManager.allLists.backgrounds[selectIndex].isBought)
                {
                    buyButton.GetComponentInChildren<Text>().text = "Selected";
                    GlobalData.selectedBG = selectIndex;
                    PlayerPrefs.SetInt("selectedBG", GlobalData.selectedBG);

                    for (int i = 0; i < productManager.allLists.backgrounds.Length; i++)
                    {
                        productManager.allLists.backgrounds[i].isSelected = false;
                    }

                    productManager.allLists.backgrounds[selectIndex].isSelected = true;
                }
                else
                {
                    if (coins >= productManager.allLists.backgrounds[selectIndex].productPrice)
                    {                       
                        productManager.allLists.backgrounds[selectIndex].isBought = true;
                        buyButton.GetComponentInChildren<Text>().text = "Select";
                        productPrice.text = "Owned";
                        UpdateCoin(productManager.allLists.backgrounds[selectIndex].productPrice, false);
                    }
                    else
                    {
                        Debug.Log("Not Enough Coins!");
                    }
                }
            }

            else if(onPowerup)
            {
                if(coins >= productManager.allLists.powerUps[selectIndex].productPrice)
                {
                    if (selectIndex == 0)
                        GlobalData.freezeCount++;
                    else if (selectIndex == 1)
                        GlobalData.speedCount++;
                    else if (selectIndex == 2)
                        GlobalData.slowCount++;
                    else if (selectIndex == 3)
                        GlobalData.doubleCount++;

                    UpdateCoin(productManager.allLists.powerUps[selectIndex].productPrice, false);
                    UpdatePowerup();
                }
               
            }
        }
        else if(onPrizeChamber)
        {
            UpdateCoin(productManager.allLists.achievedPrizes[selectIndex].sellPrice, true);
            Destroy(clickedButton);
            productManager.allLists.achievedPrizes.RemoveAt(selectIndex);
            infoPanel.SetActive(false);
        }

        SaveSystem.Save(productManager.allLists);
    }


    public void ResetAll()
    {
        onBall = false;
        onPowerup = false;
        onBG = false;
    }

    public void UpdatePowerup()
    {
        freezeCount.text = GlobalData.freezeCount.ToString("00");
        speedCount.text = GlobalData.speedCount.ToString("00");
        slowCount.text = GlobalData.slowCount.ToString("00");
        doubleCount.text = GlobalData.doubleCount.ToString("00");

        PlayerPrefs.SetInt("freeze", GlobalData.freezeCount);
        PlayerPrefs.SetInt("speed", GlobalData.speedCount);
        PlayerPrefs.SetInt("slow", GlobalData.slowCount);
        PlayerPrefs.SetInt("double", GlobalData.doubleCount);
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

    public void AddCoin()
    {
        UpdateCoin(100, true);
    }

}
