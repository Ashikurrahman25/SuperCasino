using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCountManager : MonoBehaviour
{
    public GameObject[] lives;
    public int lifeCount;
    WinningManager winningManager;

    private void Start()
    {
        lifeCount = lives.Length;
        winningManager = FindObjectOfType<WinningManager>();
    }

    public void HandleLifeDecrease()
    {
        lifeCount--;
        lives[lifeCount].SetActive(false);

        if (lifeCount <= 0)
        {
            winningManager.HandleWin();
        }

    }
}
