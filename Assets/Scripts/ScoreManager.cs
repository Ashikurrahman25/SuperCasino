using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public TextMeshPro ScoreText;
    public bool doubleScore;
    public WinningManager winningManager;

    public void IncreasePoint(int score)
    {
        if (!doubleScore)
            Score += score;
        else
            Score += score *2;

        ScoreText.text = Score.ToString();

        if (winningManager.isArcadeMode)
        {
            if (Score > PlayerPrefs.GetInt("arcade", 0))
                PlayerPrefs.SetInt("arcade", Score);
        }
        else
        {
            if (Score > PlayerPrefs.GetInt("endless", 0))
                PlayerPrefs.SetInt("endless", Score);
        }
        
    }





}
