using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] allBalls;
    public Transform SpawnPos;

   
    void Start()
    {
        StartCoroutine(SpawnNewBall(1));
    }


    public IEnumerator SpawnNewBall(float Time)
    {
        yield return new WaitForSeconds(Time);
        Instantiate(allBalls[GlobalData.selectedBall], SpawnPos.position, Quaternion.identity);
    }


}
