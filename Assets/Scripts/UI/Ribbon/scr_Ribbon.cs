using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Ribbon : MonoBehaviour
{

	void Start ()
    {
        Resize();
    }
	
	
	void Update ()
    {
		
	}

    private void Resize()
    {
        //set size to fit the screen
        //float height = /*GetComponent<RectTransform>().sizeDelta.y*/ 30 * Screen.height / 354;
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, 30);
    }
}
