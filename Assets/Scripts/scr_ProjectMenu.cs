using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ProjectMenu : MonoBehaviour
{
	void Start ()
    {
        //Vector2 pos = new Vector2(50.88f, -80f);
        ////Vector2 scale = new Vector2(166.68f, 110f);

        //float x = pos.x * Screen.width / 660;
        //float y = pos.y * Screen.height / 354;
        //float positionFactor_y = 10 * Screen.height / 354;
        //pos = new Vector3(x, y + positionFactor_y, 0);

        ////x = scale.x * Screen.width / 660;
        ////y = scale.y * Screen.height / 354;
        ////scale = new Vector2(x, y);

        //GetComponent<RectTransform>().localPosition = pos;
        ////GetComponent<RectTransform>().sizeDelta = scale;

        ////ScaleButtons();
    }

    private void ScaleButtons()
    {
        GameObject button;
        GameObject label;
        GameObject shortcut;
        Vector2 pos;
        // scale;
        int i = 0;

        while (i < 5)
        {
            button = gameObject.transform.GetChild(i).gameObject;
            label = button.transform.GetChild(0).gameObject;
            shortcut = button.transform.GetChild(1).gameObject;

            pos = button.GetComponent<RectTransform>().localPosition; //new Vector2(0.35f, 42.56994f);
            //scale = button.GetComponent<RectTransform>().sizeDelta;

            pos.x *= Screen.width / 660f;
            pos.y *= Screen.height / 354f;
            float b = 50f / 119f;
            float a = -17700f / 119f;
            float x = a + b * Screen.height;
            pos.y -= x;
            print(x);
            //scale.x *= Screen.width / 660f;
            //scale.y *= Screen.height / 354f;
            button.GetComponent<RectTransform>().localPosition = pos;
            //button.GetComponent<RectTransform>().sizeDelta = scale;
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
