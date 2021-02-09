using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinBuyView : MonoBehaviour
{
    public float price;
    public int amount;

    public TextMeshProUGUI priceText;
    public TextMeshProUGUI amountText;

    private void Start()
    {
        priceText.text = $"${price}";
        amountText.text = $"{amount} C";
    }

    public void OnBuy()
    {
        Debug.Log($"You are buying {amount} coins for ${price}");
    }
}
