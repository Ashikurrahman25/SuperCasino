using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    public Transform[] Spawnpos;
    public float waitingTime;
    public List<GameObject> SpawnedCoin;
    float wait;
    void Start()
    {
        SpawnedCoin.Add(Instantiate(Coin, Spawnpos[4].position, Quaternion.identity));
        waitingTime = Random.Range(6, 10);
        wait = waitingTime;
    }

   
    void Update()
    {
        if (wait<=0)
        {
            int random = Random.Range(0, Spawnpos.Length);
            SpawnedCoin.Add(Instantiate(Coin, Spawnpos[random].position, Quaternion.identity));
            wait = waitingTime;
        }
        else
        {
            wait -= Time.deltaTime;
        }
    }
}
