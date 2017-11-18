using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Camera : MonoBehaviour
{
    private float zoomFactor = 5f;
    private float zoomMoveFactor = 0.1f;
    private float movementSpeed = 30f;
	private float dragFactor = 3f;
    private Vector3 startPosition; //when scene is loaded
	private Vector3 moveTowards;
	private Vector3 dragOrigin;
    private Vector3 oldPos;
    private bool moving;

	void Start ()
    {
        startPosition = transform.position;
		moveTowards = startPosition;
        moving = false;
        dragFactor = transform.position.z * (-0.1f) * 8f;
	}

 
    void Update()
    {
		Move();
		GetZoom();
    }
	
	void FixedUpdate()
	{
        if (transform.position.z < -5 || (moveTowards.z < -5))
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTowards, Time.deltaTime * movementSpeed);
        } 
    }

    public void ResetCamera()
    {
        gameObject.transform.position = startPosition;
    }
	
	private void GetZoom()
	{
        if ((Input.mouseScrollDelta.x > 0 || Input.mouseScrollDelta.y > 0) && transform.position.z < -5)
        {
            moving = true;
            Vector2 mov = (Input.mousePosition - transform.position) * zoomMoveFactor;
            moveTowards = new Vector3(mov.x, mov.y, moveTowards.z + zoomFactor);
            //transform.position = Vector3.MoveTowards(transform.position, moveTowards, Time.deltaTime * zoomSpeed);
        }
        else if (Input.mouseScrollDelta.x < 0 || Input.mouseScrollDelta.y < 0)
        {
            moving = true;
            moveTowards = new Vector3(moveTowards.x, moveTowards.y, moveTowards.z - zoomFactor);
            //transform.position = Vector3.MoveTowards(transform.position, moveTowards, Time.deltaTime * zoomSpeed);
        }
	}


	private void Move()
	{
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
            oldPos = transform.position;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);//Get the ScreenVector the mouse clicked
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;    //Get the difference between where the mouse clicked and where it moved
            moveTowards = new Vector3(oldPos.x - (pos.x * dragFactor),
                                      oldPos.y - (pos.y * dragFactor),
                                      moveTowards.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            moving = false;
        }
    }
}
