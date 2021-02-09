using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject Ball;
    public Transform SpawnPos;

    public Texture2D texture;
   
    void Start()
    {
        //texture = ProductManager.instance.ballSprites[GlobalData.selectedBall];
        StartCoroutine(SpawnNewBall(1));
    }


    public IEnumerator SpawnNewBall(float Time)
    {
        yield return new WaitForSeconds(Time);
        GameObject go = Instantiate(Ball, SpawnPos.position, Quaternion.identity);
        //go.GetComponent<MeshRenderer>().material.mainTexture = texture;
    }


}
