using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Ribbon : MonoBehaviour
{

	void Start ()
    {
        //set size to fit the screen
        float height = GetComponent<RectTransform>().sizeDelta.y * Screen.height / 441;
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, height);
    }
	
	
	void Update ()
    {
		
	}
}
