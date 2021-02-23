using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationMusicControll : MonoBehaviour
{

    public int VibratorIndex;
    public int MusicIndex;
    public int muteIndex;
    public int sfxIndex;

    public Slider musicOn;
    public Slider vibrationOn;
    public Slider sfxSlider;
    public Slider muteSlider;
    
    private void Start()
    {
        MusicIndex = PlayerPrefs.GetInt("music");
        VibratorIndex = PlayerPrefs.GetInt("vibrate");
        sfxIndex = PlayerPrefs.GetInt("sfx");
        muteIndex = PlayerPrefs.GetInt("mute");

        musicOn.transform.parent.GetComponent<Switch>().OnClickSwitchButton(MusicIndex == 0 ? false : true);
        vibrationOn.transform.parent.GetComponent<Switch>().OnClickSwitchButton(VibratorIndex == 0 ? false : true);
        sfxSlider.transform.parent.GetComponent<Switch>().OnClickSwitchButton(sfxIndex == 0 ? false : true);
        muteSlider.transform.parent.GetComponent<Switch>().OnClickSwitchButton(muteIndex == 0 ? true : false);
    }


    public void AudioControl()
    {
        ControlPlayerpref(MusicIndex, "music");
    }

    public void ControlVibrate()
    {
        ControlPlayerpref(VibratorIndex, "vibrate");
    }

    public void ControlSFX()
    {
        ControlPlayerpref(sfxIndex, "sfx");
    }

    public void ControlMute()
    {
        ControlPlayerpref(muteIndex, "mute");
    }

    public void ControlPlayerpref(int index, string key)
    {

        if (index == 0)
            index = 1;
        else
            index = 0;

        PlayerPrefs.SetInt(key, index);
        AudioController.audioController.PlayButtonAudio();
    }

}
