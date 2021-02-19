using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeSec = 120f;
    public bool TimesUp;
    [SerializeField] Text TimerText;
    [SerializeField] float Minute, second;

   
    void Update()
    {
       
     
        Minute =Mathf.Clamp((TimeSec / 60) - (TimeSec % 60)/60,0,5);
        second =Mathf.Clamp(Mathf.RoundToInt(TimeSec % 60),0,59);


        if (TimeSec<=0)
        {
            TimesUp = true;
        }
        else if(!TimesUp)
        {
            TimeSec -= Time.deltaTime;
        }

        TimerText.text = Minute.ToString("00") + ":" + second.ToString("00");
    }
}
