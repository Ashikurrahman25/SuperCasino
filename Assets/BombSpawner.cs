using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject Bomb;
    public List<GameObject> SpawnedBomb;
    float WaitTime=5;
    [SerializeField]
    Vector2 Force;
    void Start()
    {
        PlayerPrefs.SetInt("Lives", 3);
        Force = new Vector2(Random.Range(-3, 3), Random.Range(11, 13));
        SpawnedBomb.Add(Instantiate(Bomb, transform.position, Quaternion.identity));
        SpawnedBomb[SpawnedBomb.Count - 1].GetComponent<Rigidbody>().AddForce(Force, ForceMode.Impulse);
    }

    
    void Update()
    {
        if (WaitTime<=0)
        {

            Force = new Vector2(Random.Range(-3, 3), Random.Range(11, 13));
            SpawnedBomb.Add(Instantiate(Bomb, transform.position, Quaternion.identity));
            SpawnedBomb[SpawnedBomb.Count - 1].GetComponent<Rigidbody>().AddForce(Force, ForceMode.Impulse) ;
            WaitTime = Random.Range(1, 5);

        }
        else
        {
            WaitTime -= Time.deltaTime;
        }

        if (SpawnedBomb.Count>0)
        {
            Destroy(SpawnedBomb[SpawnedBomb.Count - 1], 4);
        }
       
    }
}
