using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointPlate : MonoBehaviour
{

    public float Speed=1;
    public float Dir=1;
    public GameObject[] BrokenPlate;
    public bool isBroken;
    public GameObject Scores;
    public List<GameObject> ScoredObj;
    
    Vector3 iniPos, Force, ScoringPos;
    
    public ScoreManager scoreManager;
   



    private void Start()
    {
    
        Force = new Vector3(Random.Range(-0.0001f, 0.0001f), -0.0001f, Random.Range(-0.001f, 0.01f));
        scoreManager = FindObjectOfType<ScoreManager>();
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
        ScoredObj.Add(Instantiate(Scores, ScoringPos, Quaternion.identity));      
        for (int i = 0; i < BrokenPlate.Length; i++)
        {
            BrokenPlate[i].GetComponent<Rigidbody>().isKinematic = false;
            BrokenPlate[i].GetComponent<Rigidbody>().AddForce(Force*Random.Range(-0.001f,0.09f) * Time.deltaTime, ForceMode.Force);
        
        }
        scoreManager.IncreasePoint();
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
