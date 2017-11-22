using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Project : scr_Button
{
    GameObject menu;
    bool active;
    public override void OnClick()
    {
        if (!active)
        {
            Vector2 pos = new Vector2(-208.33f, -105.1f);
            Vector2 scale = new Vector2(243.34f, 110f);

            float x = pos.x * Screen.width / 660;
            float y = pos.y * Screen.height / 354;
            pos = new Vector3(x, y + 25, 0);

            x = size.x * Screen.width / 660;
            y = size.y * Screen.height / 354;
            size = new Vector2(x, y);

            menu = Resources.Load<GameObject>("Prefabs/Project_Menu");
            GameObject.Instantiate(menu, transform);
            menu.GetComponent<RectTransform>().localPosition = pos;
            menu.GetComponent<RectTransform>().sizeDelta = size;
        }
        else
        {
            Destroy(menu);
        }
    }

    protected override void StartAdditionals()
    {
        pos = new Vector2(-285, -25);
        size = new Vector2(65, 40);
    }
}
