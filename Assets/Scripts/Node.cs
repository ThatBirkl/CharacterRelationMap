using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private int maxCharsProLine = 15; //will count that far, then end the word and set a \n after that
    public int id;
    private scr_Map.NodeData data;
    private string displayName;
    private Color originalColor;

    private void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "Nodes";
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    /*
     * Will be called as soon as a new Node is created
     */
    public void GiveData(scr_Map.NodeData _data)
    {
        data = _data;
        gameObject.transform.position = new Vector2(data.POSITION_X, data.POSITION_Y);
        FormatName();
        gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = displayName;
    }

    public void Save()
    {

    }

    public scr_Map.NodeData GetData()
    {
        return data;
    }

    private void FormatName()
    {
        int counter = 0;
        foreach (char c in data.NAME)
        {
            if (counter >= maxCharsProLine &&
                (c.Equals("-") || c.Equals(" ")))
            {
                counter = 0;
                displayName += "\n";
            }
            else
            {
                displayName += c;
            }
        }
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color(originalColor.r + 0.30f, originalColor.g + 0.30f,
                                                        originalColor.b + 0.40f, originalColor.a);
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}
