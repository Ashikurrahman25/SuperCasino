using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeController : MonoBehaviour
{
    public int minScoreForPrize;
    public int selectedPrizeIndex;

    bool prizeShown;
    public bool claimed;

    public Prize prizeToClaim;

    public GameObject prizePanel;
    public TextMeshProUGUI prizeTitle;
    public TextMeshProUGUI prizePrice;
    public Image prizeImage;
    public Prize[] prizeVariations;


    public void SelectRandomPrize(int score)
    {
        if (prizeShown || score < minScoreForPrize || claimed) return;
        prizeShown = true;

        if (score >= minScoreForPrize && score < minScoreForPrize *2)
            selectedPrizeIndex = Random.Range(0, 15);
        else if (score >= minScoreForPrize * 2 && score < minScoreForPrize * 3)
            selectedPrizeIndex = Random.Range(15,30);
        else if(score >= minScoreForPrize * 3 && score < minScoreForPrize * 4)
            selectedPrizeIndex = Random.Range(30, 45);
        else if (score >= minScoreForPrize * 4)
            selectedPrizeIndex = Random.Range(45, 60);

        prizeToClaim = prizeVariations[selectedPrizeIndex];
        prizePanel.SetActive(true);
        prizeTitle.text = prizeToClaim.prizeName;
        prizePrice.text = prizeToClaim.sellPrice.ToString();
        prizeImage.sprite = ProductManager.instance.prizeSprites[prizeToClaim.iconIndex];
        Debug.Log("Prize Set up");
        AudioController.audioController.PlayPrize();
    }

    public void ClaimPrize()
    {
        prizePanel.SetActive(false);
        ProductManager.instance.allLists.prizeVariations[selectedPrizeIndex].availableCount++;
        SaveSystem.Save(ProductManager.instance.allLists);
        prizeShown = false;
        claimed = true;
        AudioController.audioController.PlayButtonAudio();
        Debug.Log("Prize claimed");
    }

    public void InstantSell()
    {
        prizePanel.SetActive(false);
        int coins = PlayerPrefs.GetInt("coins", 0);

        coins += prizeToClaim.sellPrice;
        PlayerPrefs.SetInt("coins", coins);
        AudioController.audioController.CoinAdded();
    }

}
