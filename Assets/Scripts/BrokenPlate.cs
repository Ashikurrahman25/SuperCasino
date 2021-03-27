using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlate : MonoBehaviour
{
    
    Vector3 Force;

    private void Start()
    {
        Force = new Vector3(Random.Range(-0.0001f, 0.0001f), -0.0001f, Random.Range(0.005f, 0.02f));
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(Force * 0.0005f, ForceMode.Force);
        if (!GetComponentInParent<PointPlate>().isBroken)
        {
            GetComponentInParent<PointPlate>().Break();
            GetComponentInParent<PointPlate>().isBroken = true;
        }
    }
 
}
