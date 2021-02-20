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



    [HideInInspector] public bool doingPowerup;
    [HideInInspector] public bool canUsePower;
    [HideInInspector] public bool freeze;
    [HideInInspector] public bool speedUp;
    [HideInInspector] public bool slowDown;
    [HideInInspector] public bool doublePoints;


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
}
