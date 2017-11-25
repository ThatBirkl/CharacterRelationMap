using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ProjectMenu : MonoBehaviour
{
	void Start ()
    {
        Vector2 pos = new Vector2(50.88f, -80f);
        Vector2 scale = new Vector2(166.68f, 110f);

        float x = pos.x * Screen.width / 660;
        float y = pos.y * Screen.height / 354;
        float positionFactor_y = 10 * Screen.height / 354;
        pos = new Vector3(x, y + positionFactor_y, 0);

        x = scale.x * Screen.width / 660;
        y = scale.y * Screen.height / 354;
        scale = new Vector2(x, y);

        GetComponent<RectTransform>().localPosition = pos;
        GetComponent<RectTransform>().sizeDelta = scale;

        ScaleButtons();
    }

    private void ScaleButtons()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
