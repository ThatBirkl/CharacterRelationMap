using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Undo : scr_Button
{
    public override void OnClick()
    {

    }

    protected override void StartAdditionals()
    {
        pos = new Vector2(-187.54f, -15f);
        size = new Vector2(45, 20);
    }
}
