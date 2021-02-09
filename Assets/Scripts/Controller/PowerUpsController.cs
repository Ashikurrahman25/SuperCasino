using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsController : MonoBehaviour
{
    public GameObject[] powerUps;

    public Sprite activateSprite;
    public Sprite deactivateSprite;

    public float minTimeToEnablePowerup;
    public float elapsedTime;

    public bool doingPowerup;
    public bool canUsePower;

    public bool freeze;
    public bool speedUp;
    public bool slowDown;
    public bool doublePoints;

    private void Update()
    {
        if (!doingPowerup)
        {
            if (elapsedTime <= minTimeToEnablePowerup && !canUsePower)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                canUsePower = true;
                elapsedTime = 0;
                EnableDisablePower(true);
            }
        }
    }

    public void EnableFreeze()
    {
        StartPowerUp();
        freeze = true;
        Debug.Log("Doing freeze....");
    }

    public void EnableSpeed()
    {
        StartPowerUp();
        speedUp = true;
        Debug.Log("Doing speeding....");
    }

    public void EnableSlow()
    {
        StartPowerUp();
        slowDown = true;
        Debug.Log("Doing slowing....");
    }

    public void EnableDouble()
    {
        StartPowerUp();
        doublePoints = true;
        Debug.Log("Doing Double Points....");
    }

    void StartPowerUp()
    {
        EnableDisablePower(false);
        doingPowerup = true;
        canUsePower = false;
    }

    public void EndPowerUp()
    {
        doingPowerup = false;

        freeze = false;
        speedUp = false;
        slowDown = false;
        doublePoints = false;
    }

    void EnableDisablePower(bool status)
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            powerUps[i].GetComponent<Button>().interactable = status;
        }
    }
}
