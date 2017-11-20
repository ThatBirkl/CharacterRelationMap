﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Camera : MonoBehaviour
{
    private float zoomFactor = 5f;
    private float zoomMoveFactor;
    private float movementSpeed = 120f;
    private float dragFactor_x;
    private float dragFactor_y;
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
        zoomMoveFactor = 8f;
        
    }

 
    void Update()
    {
        movementSpeed *= transform.position.z * (-0.1f);
        Move();
		GetZoom();
    }
	
	void FixedUpdate()
	{
        if (transform.position.z > -5)
        {
            moveTowards.z = -5;
        }
        if (transform.position.z < -100)
        {
            moveTowards.z = -100;
        }
        transform.position = Vector3.MoveTowards(transform.position, moveTowards, Time.deltaTime * movementSpeed);
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
            Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Vector2 mov = (Input.mousePosition - transform.position) * zoomMoveFactor;
            mousePosition = new Vector2(mousePosition.x - 0.5f, mousePosition.y - 0.5f) * 2 * zoomMoveFactor;
	    int x = mousePosition.x;
	    x /= 5;
	    x *= 5;
	    int y = mousePosition.x;
	    y /= 5;
	    y *= 5;
            moveTowards = new Vector3(moveTowards.x + mousePosition.x, moveTowards.y + mousePosition.y, moveTowards.z + zoomFactor);
        }
        else if (Input.mouseScrollDelta.x < 0 || Input.mouseScrollDelta.y < 0)
        {
            moving = true;
            Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Vector2 mov = (Input.mousePosition - transform.position) * zoomMoveFactor;
            mousePosition = new Vector2(mousePosition.x - 0.5f, mousePosition.y - 0.5f) * zoomMoveFactor;
            moveTowards = new Vector3(moveTowards.x /*- mousePosition.x*/, moveTowards.y/* - mousePosition.y*/, moveTowards.z - zoomFactor);
        }
	}


	private void Move()
	{
        dragFactor_x = transform.position.z * (31.5f / (-12030f)) * Screen.width;
        dragFactor_y = dragFactor_x * Screen.height / Screen.width;

        if (Input.GetMouseButtonDown(2))
        {
            moving = true;
            oldPos = moveTowards;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;
            moveTowards = new Vector3(oldPos.x - (pos.x * dragFactor_x),
                                      oldPos.y - (pos.y * dragFactor_y),
                                      moveTowards.z);
        }

        if (Input.GetMouseButtonUp(2))
        {
            moving = false;
        }
    }
}
