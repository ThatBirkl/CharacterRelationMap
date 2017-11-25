using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ResetCamera : scr_RibbonButton
{
    public override void OnClick()
    {
        Camera.main.GetComponent<scr_Camera>().ResetCamera();
    }

    protected override void StartAdditionals()
    {
        pos = new Vector2(-242f, -15f);
        size = new Vector2(45, 20);
    }
}
