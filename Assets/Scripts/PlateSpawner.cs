using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject[] plates;
    public float Direction;
    public List<GameObject> SpawnedPlate;
    public float waitTime = 2;
    public PowerUpsController powerUpsController;
    
    float wait;
    public bool powerEnabled;
    void Start()
    {
        powerUpsController = FindObjectOfType<PowerUpsController>();
        SpawnPlate();

    }

   
    void Update()
    {
        if (powerUpsController.doingPowerup)
        {
            if (!powerEnabled)
            {
                if (powerUpsController.freeze)
                {
                    //powerEnabled = true;
                    return;
                }

                else if (powerUpsController.speedUp)
                {
                    waitTime = waitTime / 2;
                    powerEnabled = true;

                }
                else if (powerUpsController.slowDown)
                {
                    waitTime = waitTime * 2;
                    powerEnabled = true;

                }
            }

        }
        else 
        {
            if (powerEnabled)
            {
                waitTime = 2;
                powerEnabled = false;
            }
        }
       

        if (wait<=0)
        {
            SpawnPlate();
        }
        else
        {
            wait -= Time.deltaTime;
        }
    }

    public void SpawnPlate()
    {
        wait = waitTime;
        GameObject plate = Instantiate(plates[Random.Range(0, plates.Length)], transform.position, Quaternion.identity);
        SpawnedPlate.Add(plate);
        SpawnedPlate[SpawnedPlate.Count - 1].GetComponent<PointPlate>().Dir = Direction;
    }
}
