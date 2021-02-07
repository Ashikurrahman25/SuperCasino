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
    void Start()
    {

    }

    
    void Update()
    {
        if (isArcadeMode)
        {
            if (FindObjectOfType<Timer>().TimesUp)
            {
                GameOverPanel.SetActive(true);
            }
        }
        else if(!isArcadeMode)
        {
            if (PlayerPrefs.GetInt("Lives")<=0)
            {
                GameOverPanel.SetActive(true);
            }
        }
    
        oldValue = PlayerPrefs.GetFloat("Prize Name");
        Prize.fillAmount = oldValue;
      

    }

    public void Showstar()
    {
     
       
      
    }


}
