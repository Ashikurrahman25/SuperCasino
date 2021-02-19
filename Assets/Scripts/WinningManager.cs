using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningManager : MonoBehaviour
{
   
    [SerializeField] GameObject GameOverPanel;

    [SerializeField] bool isArcadeMode;
    [SerializeField] bool menuShown;

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
        prizeController.SelectRandomPrize(scoreManager.Score);

        menuShown = true;

        Debug.Log("LIKS");
    }

    public void ShowScoring()
    {
        scoreText.text = scoreManager.Score.ToString("00");
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("highscore",0)}";
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
