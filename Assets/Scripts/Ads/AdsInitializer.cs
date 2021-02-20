using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour
{
    public string gameId = "";
    bool testMode = true;



    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
  
}
