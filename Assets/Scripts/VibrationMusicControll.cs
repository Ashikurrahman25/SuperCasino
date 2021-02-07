using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationMusicControll : MonoBehaviour
{
    public GameObject CrossSign;
    public GameObject CrossSignM;
    public int VibratorIndex;
    public int MusicIndex;
    
    private void Start()
    {
        MusicIndex = PlayerPrefs.GetInt("Music");
        VibratorIndex = PlayerPrefs.GetInt("Vibrate");
        if (VibratorIndex==0)
        {
            CrossSign.SetActive(true);
         
        }
        else if (VibratorIndex== 1)
        {
            CrossSign.SetActive(false);
       
        }
        
        
        
        if (MusicIndex==0)
        {
            CrossSignM.SetActive(true);
         
        }
        else if (MusicIndex== 1)
        {
            CrossSignM.SetActive(false);
       
        }
    }
    private void Update()
    {
       
        PlayerPrefs.SetInt("Vibrate", VibratorIndex);
        PlayerPrefs.SetInt("Music", MusicIndex);
    }
    public void ControllVibration()
    {
        if(VibratorIndex==0)
        {
          
            CrossSign.SetActive(false);
            VibratorIndex = 1;
        }

       else if(VibratorIndex == 1)
       {
            CrossSign.SetActive(true);
         
            VibratorIndex = 0;
       }

     
    }
    public void AudioControll()
    {



        if (MusicIndex == 0)
        {

            CrossSignM.SetActive(false);
            MusicIndex = 1;
        }

        else if (MusicIndex == 1)
        {
            CrossSignM.SetActive(true);

            MusicIndex = 0;
        }


    }
}
