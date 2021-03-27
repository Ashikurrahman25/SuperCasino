﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningManager : MonoBehaviour
{
   
    [SerializeField] GameObject GameOverPanel;

    [SerializeField] public bool isArcadeMode;
    [SerializeField] bool menuShown;
    [SerializeField] public bool isGameOver;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    PrizeController prizeController;
    ScoreManager scoreManager;
    Timer timer;

    void Start()
    {
        prizeController = FindObjectOfType<PrizeController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        timer = FindObjectOfType<Timer>();
    }

    
    void Update()
    {
        if (isArcadeMode && !menuShown)
        {
            if (timer.TimesUp)
            {
                HandleWin();
            }
        }
    }

    public void HandleWin()
    {  
        prizeController.claimed = false;
        ShowScoring();
        GameOverPanel.SetActive(true);

        if(isArcadeMode)
            prizeController.SelectRandomPrize(scoreManager.Score);

        menuShown = true;
        isGameOver = true;
        AdsManager.instance.ShowInterstitial();
    }

    public void ShowScoring()
    {
        scoreText.text = scoreManager.Score.ToString("00");
        
        if(isArcadeMode)
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("arcade",0)}";
        else
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("endless", 0)}";
    }


    public void OnRetry()
    {
        AudioController.audioController.PlayButtonAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenu()
    {
        AudioController.audioController.PlayButtonAudio();
        SceneManager.LoadScene("Main Menu");
    }
}
