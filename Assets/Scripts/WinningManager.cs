using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningManager : MonoBehaviour
{
   
    [SerializeField]
    GameObject GameOverPanel;

    [SerializeField]
    private float oldValue;
    public bool isArcadeMode;
    public Image Prize;
    public bool Win;

    PrizeController prizeController;
    ScoreManager scoreManager;

    void Start()
    {
        prizeController = FindObjectOfType<PrizeController>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    
    void Update()
    {
       
        Prize.fillAmount = oldValue;

        if (isArcadeMode)
        {
            if (FindObjectOfType<Timer>().TimesUp)
            {
                HandleWin();
            }
        }
        else if (!isArcadeMode)
        {
            if (PlayerPrefs.GetInt("Lives") <= 0)
            {
                HandleWin();
            }
        }
    }

    public void HandleWin()
    {        
        GameOverPanel.SetActive(true);
        oldValue = PlayerPrefs.GetFloat("Prize Name");
        prizeController.SelectRandomPrize(scoreManager.Score);
    }

    public void Showstar()
    {
     
       
      
    }


}
