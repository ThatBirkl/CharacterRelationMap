using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ContextMenu : MonoBehaviour
{
    private Button newNode;
    private static GameObject newNodeWindow;
    void Start ()
    {
        newNode = transform.GetChild(0).GetComponent<Button>(); //Get the Accept Button
        newNode.onClick.AddListener(NewNode);
        newNodeWindow = Resources.Load<GameObject>("Prefabs/window_NewNode");
    }

    private void NewNode()
    {
        GameObject _newNodeWindow = Instantiate(newNodeWindow, Input.mousePosition, Quaternion.Euler(0, 0, 0));

        GameObject canvas = GameObject.Find("Canvas");
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //mousePos = Camera.main.WorldToScreenPoint(mousePos);
        _newNodeWindow.transform.position = mousePos;

        _newNodeWindow.transform.SetParent(canvas.transform);

        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            if (UTIL.UIElementContains(mousePos, gameObject))
            {
                return;
            }
            
            Destroy(gameObject);
        }
        else if (Input.anyKeyDown)
        {
            Destroy(gameObject);
        }
    }
}
