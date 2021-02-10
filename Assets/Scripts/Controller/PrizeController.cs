using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeController : MonoBehaviour
{
    public int minScoreForPrize;
    public int selectedPrizeIndex;

    public Prize prizeToClaim;

    public GameObject prizePanel;
    public TextMeshProUGUI prizeTitle;
    public TextMeshProUGUI prizePrice;
    public Image prizeImage;

    public Prize[] prizeVariations;


    public void SelectRandomPrize(int score)
    {
        if (score >= minScoreForPrize && score < minScoreForPrize *2)
            selectedPrizeIndex = Random.Range(0, 15);
        else if (score >= minScoreForPrize * 2 && score < minScoreForPrize * 3)
            selectedPrizeIndex = Random.Range(15,30);
        else if(score >= minScoreForPrize * 3 && score < minScoreForPrize * 4)
            selectedPrizeIndex = Random.Range(30, 45);
        else if (score >= minScoreForPrize * 4 && score < minScoreForPrize * 5)
            selectedPrizeIndex = Random.Range(45, 60);

        prizeToClaim = prizeVariations[selectedPrizeIndex];
        prizePanel.SetActive(true);
        prizeTitle.text = prizeToClaim.prizeName;
        prizePrice.text = prizeToClaim.sellPrice.ToString();
        prizeImage.sprite = ProductManager.instance.prizeSprites[prizeToClaim.iconIndex];   
        Debug.Log("Prize Set up");
    }

    public void ClaimPrize()
    {
        ProductManager.instance.allLists.achievedPrizes.Add(prizeToClaim);
        SaveSystem.Save(ProductManager.instance.allLists);
        prizePanel.SetActive(false);
    }
}
