using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_NewNodeAccept : MonoBehaviour
{
    private Button buttonAccept;

    private void Start()
    {
        buttonAccept = transform.GetChild(1).GetComponent<Button>(); //Get the Accept Button
        buttonAccept.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Enter"))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        string property = "";
        int c = 1;

        //NAME
        if (transform.GetChild(3).gameObject.transform.childCount == 3) //To compensate for the new object that appears when you give input
            c = 2;

        property = transform.GetChild(3).gameObject.transform.GetChild(c).GetComponent<Text>().text;
        //property = property.Replace(" ", "");

        if (property.Equals(""))
        {
            InvalidInput();
            return;
        }

        scr_Map.NodeData node = new scr_Map.NodeData();
        float size = 0;
        UTIL.SplitNameStringAndGetFontSize(property, out node.NAME, out size);

        //RACE
        if (transform.GetChild(5).gameObject.transform.childCount == 3)
            c = 2;
        else
            c = 1;
        node.RACE = transform.GetChild(5).gameObject.transform.GetChild(c).GetComponent<Text>().text;

        //BIRTHDATE
        if (transform.GetChild(7).gameObject.transform.childCount == 3)
            c = 2;
        else
            c = 1;
        node.BIRTHDATE = transform.GetChild(7).gameObject.transform.GetChild(c).GetComponent<Text>().text;

        //DEATHDATE
        if (transform.GetChild(9).gameObject.transform.childCount == 3)
            c = 2;
        else
            c = 1;
        node.DEATHDATE = transform.GetChild(9).gameObject.transform.GetChild(c).GetComponent<Text>().text;

        //BEMERKUNG
        if (transform.GetChild(11).gameObject.transform.childCount == 3)
            c = 2;
        else
            c = 1;
        node.BEMERKUNG = transform.GetChild(11).gameObject.transform.GetChild(c).GetComponent<Text>().text;

        //TAGS
        if (transform.GetChild(12).gameObject.transform.childCount == 3)
            c = 2;
        else
            c = 1;
        node.TAGS = UTIL.ParseCommaString(transform.GetChild(12).gameObject.transform.GetChild(c).GetComponent<Text>().text);


        node.POSITION_X = MetaVariables.mousePosition.x;
        node.POSITION_Y = MetaVariables.mousePosition.y;

        GameObject nodeObject = GameObject.Instantiate(
            Resources.Load<GameObject>("Prefabs/NodePrefab"),
            new Vector3(node.POSITION_X, node.POSITION_Y, 0),
            Quaternion.Euler(0, 0, 0));
        nodeObject.GetComponent<Node>().GiveData(node);
        nodeObject.transform.GetChild(0).GetComponent<TextMesh>().characterSize = size;

        scr_Map.AddNode(nodeObject.GetComponent<Node>(), false);

        Destroy(gameObject);
    }

    private void InvalidInput()
    {

    }
}
