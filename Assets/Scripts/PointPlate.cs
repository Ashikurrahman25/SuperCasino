﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointPlate : MonoBehaviour
{
    public float normalSpeed  = 1;
    public float Speed;
    public float Dir=1;
    public GameObject[] BrokenPlate;
    public bool isBroken;
    public GameObject Scores;
    public List<GameObject> ScoredObj;
    
    Vector3 iniPos, Force, ScoringPos;   
    public ScoreManager scoreManager;

    public bool powerUpEnabled;

    public float powerUpLength;
    public float elapsedTime;
    public PowerUpsController powerupsController;

    public int scoreToAdd;

    private void Start()
    {
        Speed = normalSpeed;
        Force = new Vector3(Random.Range(-0.0001f, 0.0001f), -0.0001f, Random.Range(-0.001f, 0.01f));
        scoreManager = FindObjectOfType<ScoreManager>();
        powerupsController = FindObjectOfType<PowerUpsController>();
        iniPos = transform.position;
    }
    void Update()
    {

        if (Vector3.Distance(iniPos,transform.position)>25)
        {
            Destroy(gameObject);
        }
        if (!isBroken)
        {
          transform.position += Vector3.right * Dir * Speed * Time.deltaTime;
     
        }
        if (ScoredObj.Count>0)
        {
            for (int i = 0; i < ScoredObj.Count; i++)
            {
                ScoredObj[i].transform.position = new Vector3(ScoredObj[i].transform.position.x,ScoredObj[i].transform.position.y+0.5f*Time.deltaTime,ScoredObj[i].transform.position.z);
            }
         
        }

        HandlePowerUp();
      
    }

    public void HandlePowerUp()
    {

        if (!powerUpEnabled)
        {
            if (powerupsController.freeze)
            {
                Speed = 0;
                powerUpEnabled = true;

            }

            else if (powerupsController.speedUp)
            {
                Speed = normalSpeed * 2;
                powerUpEnabled = true;

            }

            else if (powerupsController.slowDown)
            {
                Speed = normalSpeed / 2;
                powerUpEnabled = true;

            }

            else if (powerupsController.doublePoints)
            {
                scoreManager.doubleScore = true;
                powerUpEnabled = true;

            }


        }

        else if (powerUpEnabled)
        {
            if (elapsedTime <= powerUpLength) elapsedTime += Time.deltaTime;
            else
            {
                elapsedTime = 0;
                powerUpEnabled = false;
                Speed = normalSpeed;
                scoreManager.doubleScore = false;
                powerupsController.EndPowerUp();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !isBroken)
        {
            isBroken = true;
            ScoringPos = other.transform.position;
            Break();
        }
      
    }


    public void Break()
    {
        StartCoroutine(DestroyingScore());
        GameObject ScorePopup = Instantiate(Scores, ScoringPos, Quaternion.identity);
        ScoredObj.Add(ScorePopup);

        if (scoreManager.doubleScore)
            ScorePopup.GetComponent<TextMeshPro>().text = $"+{scoreToAdd * 2}";
        else
            ScorePopup.GetComponent<TextMeshPro>().text = $"+{scoreToAdd}";

        for (int i = 0; i < BrokenPlate.Length; i++)
        {
            BrokenPlate[i].GetComponent<Rigidbody>().isKinematic = false;
            BrokenPlate[i].GetComponent<Rigidbody>().AddForce(Force*Random.Range(-0.001f,0.09f) * Time.deltaTime, ForceMode.Force);
        
        }
        scoreManager.IncreasePoint(scoreToAdd);
        GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 3);
    }
   


   IEnumerator DestroyingScore()
    {
        yield return new WaitForSeconds(2);
        Destroy(ScoredObj[ScoredObj.Count - 1]);
        ScoredObj.RemoveAt(ScoredObj.Count - 1);
    }

}
