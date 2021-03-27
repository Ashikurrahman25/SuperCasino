using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject[] plates;
    public GameObject[] powerUps;
    float minTimeToSpawnPower;
    float timer;
    public float minWaitTime;
    public float maxWaitTime;
    public bool spawnPowerUp;
    public float Direction;
    public List<GameObject> SpawnedPlate;
    public float waitTime = 2;
    public PowerUpsController powerUpsController;
    public bool isTop;
    public float powerUpCountDown;
    public float minPowerUpTime;
    
    float wait;
    public bool powerEnabled;
    void Start()
    {
        powerUpsController = FindObjectOfType<PowerUpsController>();
        SpawnPlate();
        minTimeToSpawnPower = Random.Range(minWaitTime,maxWaitTime);
    }

   
    void Update()
    {
        if (powerUpsController.doingPowerup)
        {
            if (!powerEnabled)
            {
                if (powerUpsController.freeze)
                {
                    powerEnabled = true;
                    waitTime = 2;
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

        if (!spawnPowerUp)
        {
            if (timer <= minTimeToSpawnPower) timer += Time.deltaTime;
            else
            {
                spawnPowerUp = true;
            }
        }


        if (!powerUpsController.freeze)
        {
            if (!spawnPowerUp)
            {
                if (wait <= 0)
                {
                    SpawnPlate();
                }
                else
                {
                    wait -= Time.deltaTime;
                }
            }
            else if (spawnPowerUp)
            {
                if (powerUpCountDown <= minPowerUpTime) powerUpCountDown += Time.deltaTime;
                else
                {
                    SpawnPlate();
                }
            }
        }
       
    }

    public void SpawnPlate()
    {

        GameObject plate = null;
        
        if (!spawnPowerUp)
        {
            plate = Instantiate(plates[Random.Range(0, plates.Length)], transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            wait = waitTime;
        }
        else
        {
            plate = Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, Quaternion.identity);
            spawnPowerUp = false;
            timer = 0;
            minTimeToSpawnPower = Random.Range(minWaitTime, maxWaitTime);
            powerUpCountDown = 0;
            wait = waitTime;
        }
        plate.GetComponent<PointPlate>().isTop = isTop;
        plate.GetComponent<PointPlate>().Dir = Direction;
    }
}
