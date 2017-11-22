using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Button : MonoBehaviour
{
    public Vector2 pos;
    public Vector2 size;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        StartAdditionals();
        Resize();
    }

    /*
     * Resizes the button and moves it to the right location
     */
    public virtual void Resize()
    {
        //jede node muss quasi nach dem selben prinzip wie das ribbon gescaled werden
        //position: Project muss nach meiner Formel 10 vom Rand entfernt sein
        //das nächste dann von dieser position 20 + breite von Project

        float x = pos.x * Screen.width / 660;
        float y = pos.y * Screen.height / 354;
        pos = new Vector3(x, y + 25, 0);

        x = size.x * Screen.width / 660;
        y = size.y * Screen.height / 354;
        size = new Vector2(x, y);

        transform.GetChild(0).GetComponent<Text>().fontSize = 14 * Screen.width / 660;

        GetComponent<RectTransform>().localPosition = pos;
        GetComponent<RectTransform>().sizeDelta = size;
    }

    protected virtual void StartAdditionals()
    {

    }

    public virtual void OnClick()
    {

    }
}
