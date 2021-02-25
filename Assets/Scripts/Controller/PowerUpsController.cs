using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsController : MonoBehaviour
{


    public Sprite activateSprite;
    public Sprite deactivateSprite;

    public TextMeshProUGUI bombCount;
    public TextMeshProUGUI megaBombCount;



    [HideInInspector] public bool doingPowerup;
     public bool stopPowerup;
    [HideInInspector] public bool freeze;
    [HideInInspector] public bool speedUp;
    [HideInInspector] public bool slowDown;
    [HideInInspector] public bool doublePoints;

    public float powerUpLength;
    public float elaspedTime;

    PointPlate[] _plates;


    private void Start()
    {
        bombCount.text = PlayerPrefs.GetInt("bomb", 0).ToString("00");
        megaBombCount.text = PlayerPrefs.GetInt("megaBomb", 0).ToString("00");
    }

    private void Update()
    {
        if (doingPowerup)
        {
            if (elaspedTime <= powerUpLength) elaspedTime += Time.deltaTime;
            else
            {
                doingPowerup = false;
                elaspedTime = 0;
                EndPowerUp();
            }
        }
       
    }

    public void EnableFreeze()
    {
        StartPowerUp();
        freeze = true;
    }

    public void EnableSpeed()
    {
        StartPowerUp();
        speedUp = true;
    }

    public void EnableSlow()
    {
        StartPowerUp();
        slowDown = true;
    }

    public void EnableDouble()
    {
        StartPowerUp();
        doublePoints = true;
    }

    void StartPowerUp()
    {
        doingPowerup = true;
        stopPowerup = false;
    }

    public void EndPowerUp()
    {
        doingPowerup = false;
        stopPowerup = true;
        freeze = false;
        speedUp = false;
        slowDown = false;
        doublePoints = false;
    }

    public void DoMegaBomb()
    {
        int count = PlayerPrefs.GetInt("megaBomb", 0);
        if (count == 0) return;

        _plates = FindObjectsOfType<PointPlate>();
        if (_plates.Length != 0)
        {
            for (int i = 0; i < _plates.Length; i++)
            {
                if (!_plates[i].isBomb && !_plates[i].isFreeze && !_plates[i].isFast && !_plates[i].isDouble && !_plates[i].isSlow)
                {
                   _plates[i].Break();
                }

            }
        }
        count--;
        megaBombCount.text = count.ToString("00");
        PlayerPrefs.SetInt("megaBomb", count);
    }

    public void DoBomb()
    {
        int count = PlayerPrefs.GetInt("bomb", 0);
        if (count == 0) return;

        int random = Random.Range(0, 2);

        _plates = FindObjectsOfType<PointPlate>();

        if (_plates.Length != 0)
        {
            for (int i = 0; i < _plates.Length; i++)
            {
                if(!_plates[i].isBomb && !_plates[i].isFreeze &&!_plates[i].isFast && !_plates[i].isDouble && !_plates[i].isSlow)
                {
                    if(random == 0)
                    {
                        if (_plates[i].isTop)
                            _plates[i].Break();
                    }
                    else
                    {
                        if (!_plates[i].isTop)
                            _plates[i].Break();
                    }
                    
                }
                
            }
        }
        count--;

        bombCount.text = count.ToString("00");
        PlayerPrefs.SetInt("bomb", count);
    }
}
