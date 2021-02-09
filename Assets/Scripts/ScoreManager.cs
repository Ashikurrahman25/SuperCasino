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

    void Start()
    {
       Score = 0;
    }

   
    void Update()
    {
      
        ScoreText.text = Score.ToString();
        float _score = Score * 0.05f;
        PlayerPrefs.SetFloat("Prize Name",_score);
    }

    public void IncreasePoint()
    {
        if (!doubleScore)
            Score++;
        else
            Score += 2;
     
        PlayerPrefs.SetInt("Score", Score);
    }





}
