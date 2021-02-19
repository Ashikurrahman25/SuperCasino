using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationMusicControll : MonoBehaviour
{

    public int VibratorIndex;
    public int MusicIndex;

    public Slider musicOn;
    public Slider vibrationOn;
    
    private void Start()
    {
        MusicIndex = PlayerPrefs.GetInt("music");
        VibratorIndex = PlayerPrefs.GetInt("vibrate");

        musicOn.transform.parent.GetComponent<Switch>().OnClickSwitchButton(MusicIndex == 0 ? false : true);
        vibrationOn.transform.parent.GetComponent<Switch>().OnClickSwitchButton(VibratorIndex == 0 ? false : true);
    }


    public void AudioControl()
    {
        if (MusicIndex == 0)
            MusicIndex = 1;
        else
            MusicIndex = 0;

        PlayerPrefs.SetInt("music",MusicIndex);
       // musicOn.GetComponentInParent<Switch>().OnClickSwitchButton(MusicIndex == 0 ? true : false);
    }

    public void VibrateControl()
    {

        if (VibratorIndex == 0)
            VibratorIndex = 1;
        else
            VibratorIndex = 0;

        PlayerPrefs.SetInt("vibrate", VibratorIndex);
        //vibrationOn.GetComponentInParent<Switch>().OnClickSwitchButton(VibratorIndex == 0 ? true:false);
    }

}
