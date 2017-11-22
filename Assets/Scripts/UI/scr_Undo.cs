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
        pos = new Vector2(-125, -25);
        size = new Vector2(65, 40);
    }
}
