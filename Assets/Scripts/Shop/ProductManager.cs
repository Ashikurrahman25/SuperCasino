using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{

    public AllList allLists;
    public static ProductManager instance;

    public Texture2D[] ballSprites;
    public Sprite[] backgroundSprites;
    public Sprite[] powerUpSprites;

    public Sprite[] prizeSprites;

    private void Awake()
    {
        if (instance != null) Destroy(instance);
        else instance = this;
        DontDestroyOnLoad(this);
    }

    public void SaveLists()
    {
        SaveSystem.Save(allLists);
        Debug.Log("Saved List");
    }

    public void LoadList()
    {
        allLists = SaveSystem.Load();
        Debug.Log("Loaded List");
    }

}
