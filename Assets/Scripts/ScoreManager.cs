using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public TextMeshPro ScoreText;

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
        Score++;
     
        PlayerPrefs.SetInt("Score", Score);
    }





}
