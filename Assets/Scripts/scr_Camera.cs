using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Camera : MonoBehaviour
{
    private float zoomFactor = 30f;
    private float zoomSpeed = 30f;
    private Vector3 startPosition;

	void Start ()
    {
        startPosition = transform.position;
	}

 
    void Update()
    {
        if (Input.mouseScrollDelta.x > 0 || Input.mouseScrollDelta.y > 0)
        {
            print(">0");
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + zoomFactor);
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * zoomSpeed);
            //Camera.main.or
        }
        else if (Input.mouseScrollDelta.x < 0 || Input.mouseScrollDelta.y < 0)
        {
            print("<0");
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - zoomFactor);
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * zoomSpeed);
        }
    }

    public void ResetCamera()
    {
        gameObject.transform.position = startPosition;
    }
}
