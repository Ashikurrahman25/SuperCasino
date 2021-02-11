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


    public void IncreasePoint(int score)
    {
        if (!doubleScore)
            Score += score;
        else
            Score += score *2;

        Score = score;
        ScoreText.text = Score.ToString();

        if (Score > PlayerPrefs.GetInt("highscore", 0))
            PlayerPrefs.SetInt("highscore", Score);
    }





}
