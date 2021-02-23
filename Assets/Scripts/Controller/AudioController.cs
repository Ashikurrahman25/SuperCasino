using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController audioController;
    public AudioSource sfxAudioS;

    public AudioClip buttonClick;
    public AudioClip prizeAudio;
    public AudioClip successBuyAudio;
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
}
