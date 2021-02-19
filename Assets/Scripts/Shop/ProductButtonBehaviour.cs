using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductButtonBehaviour : MonoBehaviour
{
    [Header("References to shop & product manager")]
     ProductManager productManager;
     ShopManager shopManager;

    private void Start()
    {
        productManager = ProductManager.instance;
        shopManager = ShopManager.instance;
    }

    
    /// <summary>
    /// This function handles the click on items button 
    /// </summary>
    public void OnSelect()
    {
        int index = transform.GetSiblingIndex();
        shopManager.selectIndex = index;
        shopManager.clickedButton = this.gameObject;

        if (!shopManager.onPrizeChamber)
        {
            if (shopManager.onBall)
            {
                shopManager.productTitle.text = productManager.allLists.ballSkins[index].productName;
                
                if (!productManager.allLists.ballSkins[index].isBought)
                {
                    shopManager.productPrice.text = productManager.allLists.ballSkins[index].productPrice.ToString("00");
                    shopManager.buyButton.GetComponentInChildren<Text>().text = "Buy";
                }
                else
                {
                    shopManager.productPrice.text = "Owned";

                    if (!productManager.allLists.ballSkins[index].isSelected)
                        shopManager.buyButton.GetComponentInChildren<Text>().text = "Select";
                    else
                        shopManager.buyButton.GetComponentInChildren<Text>().text = "Selected";
                }

                if (productManager.ballSprites[index] != null)
                {
                    //Texture2D tex = productManager.ballSprites[index];
                    //shopManager.productIcon.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
                }
            }
            else if (shopManager.onBG)
            {
                shopManager.productTitle.text = productManager.allLists.backgrounds[index].productName;
                
                if (!productManager.allLists.backgrounds[index].isBought)
                {
                    shopManager.productPrice.text = productManager.allLists.backgrounds[index].productPrice.ToString("00");
                    shopManager.buyButton.GetComponentInChildren<Text>().text = "Buy";
                }
                else
                {
                    shopManager.productPrice.text = "Owned";

                    if (!productManager.allLists.backgrounds[index].isSelected)
                        shopManager.buyButton.GetComponentInChildren<Text>().text = "Select";
                    else
                        shopManager.buyButton.GetComponentInChildren<Text>().text = "Selected";
                }

                if (productManager.backgroundSprites[index] != null)
                    shopManager.productIcon.sprite = productManager.backgroundSprites[index];
            }
            else if (shopManager.onPowerup)
            {
                shopManager.buyButton.GetComponentInChildren<Text>().text = "Buy";
                shopManager.productTitle.text = productManager.allLists.powerUps[index].productName;
                shopManager.productPrice.text = productManager.allLists.powerUps[index].productPrice.ToString("00");

                if (productManager.powerUpSprites[index] != null)
                    shopManager.productIcon.sprite = productManager.powerUpSprites[index];
            }


        }
        else
        {
            if(!shopManager.infoPanel.activeSelf)
                shopManager.infoPanel.SetActive(true);

            if(productManager.allLists.achievedPrizes.Count > 0)
            {
                shopManager.productTitle.text = productManager.allLists.achievedPrizes[index].prizeName;
                shopManager.productPrice.text = productManager.allLists.achievedPrizes[index].sellPrice.ToString("00");

                if (productManager.prizeSprites[productManager.allLists.achievedPrizes[index].iconIndex] != null)
                    shopManager.productIcon.sprite = productManager.prizeSprites[productManager.allLists.achievedPrizes[index].iconIndex];
            }
        }
    }
}
