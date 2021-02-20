using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public bool isPressed;
    public float speed;
    LifeCountManager lifeManager;

    private void Awake()
    {
        lifeManager = FindObjectOfType<LifeCountManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Broken Plate"))
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}
