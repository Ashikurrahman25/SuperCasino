using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    public Image itemIcon;

    public Image buttonImage;
    public GameObject coinIcon;
    public Sprite selectedIcon;
    public Sprite normalIcon;
    public Color selectedColor;
    public Color normalColor;

    public bool isBall;
    public bool isBG;
    public bool isPowerUp;
    public bool isBought;

    ProductManager productManager;

    private void Start()
    {
        productManager = ProductManager.instance;
    }

    public void SetDetail(string name, string price, Sprite icon)
    {
        itemName.text = name;
        itemPrice.text = price;
        itemIcon.sprite = icon;
    }

    public void ChangeStatus(bool isSelected)
    {
        coinIcon.SetActive(false);

        if (isSelected)
        {
            buttonImage.sprite = selectedIcon;
            buttonImage.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = selectedColor;
        }
        else
        {
            buttonImage.sprite = normalIcon;
            buttonImage.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = normalColor;
        }
    }

    public void OnClick()
    {
        int coin = PlayerPrefs.GetInt("coins", 0);
        int buttonIndex = transform.GetSiblingIndex();
        AudioController.audioController.PlayButtonAudio();
        Product product = new Product();

        if (isBall)
        {
            product = productManager.allLists.ballSkins[buttonIndex];

            if (!product.isBought)
            {
                if(coin >= product.productPrice)
                {
                    productManager.allLists.ballSkins[buttonIndex].isBought = true;
                    isBought = true;
                    itemPrice.text = "Select";
                    coinIcon.SetActive(false);
                    AudioController.audioController.BuyAudio();
                }
                else
                {
                    ShopManager.instance.ActivateDeactivatePanel(ShopManager.instance.failedPanel);
                    return;
                }
            }
            else
            {
                for (int i = 0; i < productManager.allLists.ballSkins.Length; i++)
                {
                    productManager.allLists.ballSkins[i].isSelected = false;
                }

                SelectItem(buttonIndex);

                return;
            }
        }
        else if (isBG)
        {
            product = productManager.allLists.backgrounds[buttonIndex];

            if (!product.isBought)
            {
                if (coin >= product.productPrice)
                {
                    productManager.allLists.backgrounds[buttonIndex].isBought = true;
                    isBought = true;
                    itemPrice.text = "Select";
                    coinIcon.SetActive(false);
                    AudioController.audioController.BuyAudio();
                }
                else
                {
                    ShopManager.instance.ActivateDeactivatePanel(ShopManager.instance.failedPanel);
                    return;
                }
            }
            else
            {
                for (int i = 0; i < productManager.allLists.backgrounds.Length; i++)
                {
                    productManager.allLists.backgrounds[i].isSelected = false;
                }

                SelectItem(buttonIndex);
                return;
            }
        }          
        else if (isPowerUp)
        {
            product = productManager.allLists.powerUps[buttonIndex];

            if(coin >= product.productPrice)
            {
                GlobalData.megaBomb++;

                ShopManager.instance.UpdatePowerup();
                AudioController.audioController.BuyAudio();
            }
            else
            {
                ShopManager.instance.ActivateDeactivatePanel(ShopManager.instance.failedPanel);
                return;
            }
        }

        ShopManager.instance.UpdateCoin(product.productPrice, false);
        productManager.SaveLists();
    }


    public void SelectItem(int index)
    {
        ResetUI();

        ChangeStatus(true);
        transform.parent.GetChild(index).GetComponent<ItemView>().itemPrice.text = "Selected";
       
        if (isBall)
        {
            productManager.allLists.ballSkins[index].isSelected = true;
            GlobalData.selectedBall = index;
            PlayerPrefs.SetInt("selectedball", GlobalData.selectedBall);
        }
        else if (isBG)
        {
            productManager.allLists.backgrounds[index].isSelected = true;
            GlobalData.selectedBG = index;
            PlayerPrefs.SetInt("selectedBG", GlobalData.selectedBG);
        }

        productManager.SaveLists();
       
    }

    public void ResetUI()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<ItemView>().buttonImage.sprite = normalIcon;

            if (transform.parent.GetChild(i).GetComponent<ItemView>().isBought)
            {
                transform.parent.GetChild(i).GetComponent<ItemView>().itemPrice.text = "Select";
                //transform.parent.GetChild(0).GetComponent<ItemView>().itemPrice.text = "Select";
            }

            transform.parent.GetChild(i).GetComponent<ItemView>().buttonImage.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = normalColor;
        }
    }
}
