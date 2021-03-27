using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiftButtonView : MonoBehaviour
{

    public TextMeshProUGUI priceText;
    public TextMeshProUGUI availableCount;
    public Image giftIcon;
    public GameObject overlay;

    public void SetDetails(Sprite sp, int price, int count)
    {
        priceText.text = price.ToString("00");
        giftIcon.sprite = sp;
        availableCount.text = count.ToString("00");
    }

    public void SellGifts()
    {
        int buttonIndex = transform.GetSiblingIndex();
        Prize prize = ProductManager.instance.allLists.prizeVariations[buttonIndex];

        if(prize.availableCount == 0)
        {
            overlay.SetActive(true);
            return;
        }
        prize.availableCount--;

        FindObjectOfType<ShopManager>().UpdateCoin(prize.sellPrice, true);

        if(prize.availableCount == 0)
            overlay.SetActive(true);

        availableCount.text = prize.availableCount.ToString("00");

        //FindObjectOfType<PrizeController>().prizeVariations[buttonIndex].availableCount--;
        ProductManager.instance.SaveLists();
        AudioController.audioController.CoinAdded();
    }
}
