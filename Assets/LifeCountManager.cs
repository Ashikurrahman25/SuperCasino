using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCountManager : MonoBehaviour
{
    public GameObject[] lives;
    public bool isGameOver;
    public int Lives;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Lives = PlayerPrefs.GetInt("Lives");
        if (PlayerPrefs.GetInt("Lives")==2)
        {
            
            lives[2].SetActive(false);      
               
        }
        else if (PlayerPrefs.GetInt("Lives") == 1)
        {
            lives[1].SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Lives")==0)
        {
            isGameOver = true;
        }
           
       
    }
}
