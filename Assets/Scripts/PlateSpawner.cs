using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject Plate;
    public float Direction;
    public List<GameObject> SpawnedPlate;
    public float waitTime = 2;
    public PowerUpsController powerUpsController;
    
    float wait;
    public bool powerEnabled;
    void Start()
    {
        powerUpsController = FindObjectOfType<PowerUpsController>();
        wait = waitTime;
        SpawnedPlate.Add(Instantiate(Plate, transform.position, Quaternion.identity));
        SpawnedPlate[SpawnedPlate.Count - 1].GetComponent<PointPlate>().Dir=Direction;
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
