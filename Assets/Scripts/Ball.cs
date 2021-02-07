using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform LimitOfActive;
    public bool isPressed;
    public float speed;
    public bool isActive;
    private void Update()
    {
        if (transform.position.z>LimitOfActive.position.z)
        {
            isActive = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Broken Plate"))
        {
            isActive = true;
        }

        if (collision.collider.CompareTag("Bomb") && !isActive)
        {
            PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
            Destroy(collision.collider.gameObject);               
        }
       
    }
}
