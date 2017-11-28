using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //types:
    private enum State {
        inactive,
        hover,
        active, //always move towards mouse
        editing };

    //variables
    private int maxCharsProLine = 15; //will count that far, then end the word and set a \n after that
    public int id;
    private scr_Map.NodeData data;
    private string displayName;
    private Color originalColor;
    private State state;
    private Vector2 moveTowards;
    private Vector2 offset;
    private float movementSpeed = 120f;
    private float distance;

    private void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "Nodes";
        originalColor = GetComponent<SpriteRenderer>().color;
        state = State.inactive;
        moveTowards = transform.position;
        distance = 10;
    }

    private void Update()
    {
        Move();
        distance = -1 * Camera.main.transform.position.z;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTowards, Time.deltaTime * movementSpeed);
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
        if (state == State.inactive)
        {
            state = State.hover;
        }

        GetComponent<SpriteRenderer>().color = new Color(originalColor.r + 0.30f, originalColor.g + 0.30f,
                                                        originalColor.b + 0.40f, originalColor.a);
    }

    private void OnMouseExit()
    {
        if (state == State.hover)
        {
            state = State.inactive;
        }
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    private void Move()
    {
        if (state == State.hover && Input.GetMouseButtonDown(0))
        {
            state = State.active;
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            offset = transform.position - mousePos;
        }
        else if (state == State.active && Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (mousePosition.x <= transform.position.x + GetComponent<SpriteRenderer>().sprite.border.z &&
                mousePosition.x >= transform.position.x - GetComponent<SpriteRenderer>().sprite.border.x &&
                mousePosition.y <= transform.position.y + GetComponent<SpriteRenderer>().sprite.border.w &&
                mousePosition.y >= transform.position.y - GetComponent<SpriteRenderer>().sprite.border.y)
            {
                state = State.hover;
            }
            else
            {
                state = State.inactive;
            }
        }

        if (state == State.active) //move the object
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            moveTowards = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0);
        }
    }
}
