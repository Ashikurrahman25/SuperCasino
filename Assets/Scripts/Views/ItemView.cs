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
}
