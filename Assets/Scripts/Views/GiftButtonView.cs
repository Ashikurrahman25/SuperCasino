using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiftButtonView : MonoBehaviour
{

    public TextMeshProUGUI priceText;
    public Image giftIcon;

    public void SetDetails(Sprite sp, int price)
    {
        priceText.text = price.ToString("00");
        giftIcon.sprite = sp;
    }

    public void SellGifts()
    {
        int buttonIndex = transform.GetSiblingIndex();
        Prize prize = ProductManager.instance.allLists.achievedPrizes[buttonIndex];
        FindObjectOfType<ShopManager>().UpdateCoin(ProductManager.instance.allLists.achievedPrizes[buttonIndex].sellPrice, true);

        Destroy(gameObject);
        ProductManager.instance.allLists.achievedPrizes.RemoveAt(buttonIndex);
        ProductManager.instance.SaveLists();

        if (ProductManager.instance.allLists.achievedPrizes.Count == 0)
            FindObjectOfType<Mainmenumanager>().ShowItem();
    }
}
