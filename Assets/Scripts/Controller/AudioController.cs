using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController audioController;
    public AudioSource sfxAudioS;
    public AudioSource bgAS;

    public AudioClip buttonClick;
    public AudioClip prizeAudio;
    public AudioClip successBuyAudio;
    public AudioClip coinAdded;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (audioController == null)
        {
            audioController = this;
        }
        else
        {
            Destroy(gameObject);
        }


        HandleAudio();
    }

    public void HandleAudio()
    {
        if (PlayerPrefs.GetInt("mute", 0) == 0)
        {
            sfxAudioS.mute = PlayerPrefs.GetInt("sfx", 0) == 0 ? false : true;
            bgAS.mute = PlayerPrefs.GetInt("music", 0) == 0 ? false : true;
        }
        else
        {
            sfxAudioS.mute = true;
            bgAS.mute = true;
        }
    }


    public void PlayButtonAudio()
    {
        sfxAudioS.PlayOneShot(buttonClick);
    }

    public void PlayPrize()
    {
        sfxAudioS.PlayOneShot(prizeAudio);
    }

    public void BuyAudio()
    {
        sfxAudioS.PlayOneShot(successBuyAudio);
    }

    public void CoinAdded()
    {
        sfxAudioS.PlayOneShot(coinAdded);
    }

}
