using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ResetCamera : scr_Button
{
    public override void OnClick()
    {
        Camera.main.GetComponent<scr_Camera>().ResetCamera();
    }

    protected override void StartAdditionals()
    {
        pos = new Vector2(-205, -25);
        size = new Vector2(65, 40);
    }
}
