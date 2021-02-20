using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour 
{


	[SerializeField]
	Vector2 startPos, endPos, direction;
	

	[SerializeField]
	float throwForceInXandY = 1f;

	[SerializeField]
	float throwForceInZ = 50f;

	public bool Thrown;
	Rigidbody rb;   
    WinningManager winningManager;

	void Start()
	{
        winningManager = FindObjectOfType<WinningManager>();
		rb = GetComponent<Rigidbody> ();
	}


	void Update () {

        if (winningManager.isGameOver) return;

        #region Mobile  
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {


           
            startPos = Input.GetTouch(0).position;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !Thrown)
        {


         


            endPos = Input.GetTouch(0).position;


            direction = startPos - endPos;
            if (direction.magnitude > 50)
            {
                Vector2 Speed;
                Speed = new Vector2(direction.x, Mathf.Clamp(direction.y, -500, 300)) * (-1);
                rb.isKinematic = false;
                rb.AddForce(Speed.x, Speed.y * 1.1f, throwForceInZ * Speed.y * 0.5f);

                Thrown = true;
                StartCoroutine(FindObjectOfType<BallSpawner>().SpawnNewBall(0.4f));
                Destroy(gameObject, 3f);
            }

       


        }

        #endregion

        #region PC
        if (Input.GetMouseButtonDown(0))
        {


            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && !Thrown)
        {



            endPos = Input.mousePosition;
            direction = (startPos - endPos);

            if (direction.magnitude > 50)
            {

                Vector2 Speed;
                Speed = new Vector2(direction.x, Mathf.Clamp(direction.y, -500, 300)) * (-1);
                rb.isKinematic = false;
                rb.AddForce(Speed.x, Speed.y * 1.1f, throwForceInZ * Speed.y * 0.5f);

                Thrown = true;
                StartCoroutine(FindObjectOfType<BallSpawner>().SpawnNewBall(0.4f));
                Destroy(gameObject, 3f);
            }


        }
        #endregion

    }

}


