using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_NewNodeAccept : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        string property = "";

        //NAME
        property = transform.GetChild(3).gameObject.GetComponent<Text>().text;
        property = property.Replace(" ", "");
        if (property.Equals(""))
        {
            InvalidInput();
            return;
        }

        scr_Map.NodeData node = new scr_Map.NodeData();
        node.NAME = property;
        node.RACE = transform.GetChild(5).gameObject.GetComponent<Text>().text;
        node.BIRTHDATE = transform.GetChild(7).gameObject.GetComponent<Text>().text;
        node.DEATHDATE = transform.GetChild(9).gameObject.GetComponent<Text>().text;
        node.BEMERKUNG = transform.GetChild(11).gameObject.GetComponent<Text>().text;
        node.TAGS = UTIL.ParseCommaString(transform.GetChild(12).gameObject.GetComponent<Text>().text);
        node.POSITION_X = MetaVariables.mousePosition.x;
        node.POSITION_Y = MetaVariables.mousePosition.y;

        GameObject nodeObject = GameObject.Instantiate(
            Resources.Load<GameObject>("Prefabs/NodePrefab"),
            new Vector3(node.POSITION_X, node.POSITION_Y, 0),
            Quaternion.Euler(0, 0, 0));
        nodeObject.GetComponent<Node>().GiveData(node);
    }

    private void InvalidInput()
    {

    }
}
