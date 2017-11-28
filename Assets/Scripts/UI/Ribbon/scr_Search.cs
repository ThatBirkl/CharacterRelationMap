using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Search : scr_RibbonButton
{
    public override void OnClick()
    {

    }

    protected override void StartAdditionals()
    {
        pos = new Vector2(297.5f, -15f);
        size = new Vector2(45, 20);
    }
}
