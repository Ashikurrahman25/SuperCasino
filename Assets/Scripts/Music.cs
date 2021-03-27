using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource TapAudioSource;
   
    int MusicPlayIndex;
    

    private void Update()
    {
       MusicPlayIndex = PlayerPrefs.GetInt("Music");
    }
  
    public void PlayTap()
    {
        if (MusicPlayIndex==1)
        {
            TapAudioSource.Play();
        }
    }
}
