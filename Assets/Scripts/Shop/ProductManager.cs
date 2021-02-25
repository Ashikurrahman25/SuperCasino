using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{

    public AllList allLists;
    public static ProductManager instance;

    public Sprite[] ballSprites;
    public Sprite[] backgroundSprites;
    public Sprite[] powerUpSprites;

    public Sprite[] bgIcons;

    public Sprite[] prizeSprites;

    private void Awake()
    {
        if (instance == null) instance = this; 
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void SaveLists()
    {
        SaveSystem.Save(allLists);

        PlayerPrefs.SetInt("total_powerups", allLists.powerUps.Length);
        PlayerPrefs.SetInt("total_balls", allLists.ballSkins.Length);
        PlayerPrefs.SetInt("total_bg", allLists.backgrounds.Length);

        Debug.Log("Saved List");
    }

    public void LoadList()
    {
        allLists = SaveSystem.Load();
        Debug.Log("Loaded List");
    }

}
