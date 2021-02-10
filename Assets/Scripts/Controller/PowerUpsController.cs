using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsController : MonoBehaviour
{
    public Button freezeButton;
    public Button speedButton;
    public Button slowButton;
    public Button doubleButton;

    public Sprite activateSprite;
    public Sprite deactivateSprite;

    public TextMeshProUGUI freezeCount;
    public TextMeshProUGUI speedCount;
    public TextMeshProUGUI slowCount;
    public TextMeshProUGUI doubleCount;

    public float minTimeToEnablePowerup;
    [HideInInspector] public float elapsedTime;

    [HideInInspector] public bool doingPowerup;
    [HideInInspector] public bool canUsePower;
    [HideInInspector] public bool freeze;
    [HideInInspector] public bool speedUp;
    [HideInInspector] public bool slowDown;
    [HideInInspector] public bool doublePoints;


    private void Start()
    {
        UpdatePowerUpCount();
    }

    private void Update()
    {
        if (!doingPowerup)
        {
            if (elapsedTime <= minTimeToEnablePowerup)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                if (!canUsePower)
                {
                    canUsePower = true;
                    elapsedTime = 0;
                    EnableDisablePower(true);

                    Debug.Log("Enabling powerups");
                }
            }
        }
    }

    public void EnableFreeze()
    {
        GlobalData.freezeCount--;
        StartPowerUp();
        freeze = true;
        Debug.Log("Doing freeze....");
    }

    public void EnableSpeed()
    {
        GlobalData.speedCount--;
        StartPowerUp();
        speedUp = true;
        Debug.Log("Doing speeding....");
    }

    public void EnableSlow()
    {
        GlobalData.slowCount--;
        StartPowerUp();
        slowDown = true;
        Debug.Log("Doing slowing....");
    }

    public void EnableDouble()
    {
        GlobalData.doubleCount--;
        StartPowerUp();
        doublePoints = true;
        Debug.Log("Doing Double Points....");
    }

    void StartPowerUp()
    {
        UpdatePowerUpCount();
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

    public void UpdatePowerUpCount()
    {
        freezeCount.text = GlobalData.freezeCount.ToString();
        speedCount.text = GlobalData.speedCount.ToString();
        slowCount.text = GlobalData.slowCount.ToString();
        doubleCount.text = GlobalData.doubleCount.ToString();

        PlayerPrefs.SetInt("freeze", GlobalData.freezeCount);
        PlayerPrefs.SetInt("speed", GlobalData.speedCount);
        PlayerPrefs.SetInt("slow", GlobalData.slowCount);
        PlayerPrefs.SetInt("double", GlobalData.doubleCount);
    }

    void EnableDisablePower(bool status)
    {
        if(status)
        {
            if (GlobalData.freezeCount > 0)
                freezeButton.interactable = true;

            if (GlobalData.speedCount > 0)
                speedButton.interactable = true;

            if (GlobalData.slowCount > 0)
                slowButton.interactable = true;

            if (GlobalData.doubleCount > 0)
                doubleButton.interactable = true;
        }
        else
        {
            freezeButton.interactable = false;
            speedButton.interactable = false;
            slowButton.interactable = false;
            doubleButton.interactable = false;
        }
    }
}
