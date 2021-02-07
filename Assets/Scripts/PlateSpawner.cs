using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject Plate;
    public float Direction;
    public List<GameObject> SpawnedPlate;
    public float waitTime = 2;
    
    float wait;
    void Start()
    {
        wait = waitTime;
        SpawnedPlate.Add(Instantiate(Plate, transform.position, Quaternion.identity));
        SpawnedPlate[SpawnedPlate.Count - 1].GetComponent<PointPlate>().Dir=Direction;
    }

   
    void Update()
    {
        if (wait<=0)
        {
            SpawnedPlate.Add(Instantiate(Plate, transform.position, Quaternion.identity));
            SpawnedPlate[SpawnedPlate.Count - 1].GetComponent<PointPlate>().Dir = Direction;
            wait = waitTime;
        }
        else
        {
            wait -= Time.deltaTime;
        }
    }
}
