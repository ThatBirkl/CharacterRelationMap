using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Project : scr_RibbonButton
{
    GameObject menu;
    bool active;
    public override void OnClick()
    {
        if (!active)
        {
            active = true;
            menu = Resources.Load<GameObject>("Prefabs/window_ProjectMenu");
            GameObject.Instantiate(menu, transform);
        }
        else
        {
            active = false;
            Destroy(transform.GetChild(1).gameObject);
        }
    }

    protected override void StartAdditionals()
    {
        pos = new Vector2(-297.54f, -15f);
        size = new Vector2(45, 20);
    }
}
