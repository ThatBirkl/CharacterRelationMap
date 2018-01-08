using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class scr_Input : MonoBehaviour
{
    //void Update ()
    //   {
    //       //SAVE
    //       if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) ||  //LeftControl then S
    //           (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.LeftControl)) ||  //S then LeftControl
    //           (Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(KeyCode.S)) || //RightControl then S
    //           (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.RightControl)))   //S then RightControl
    //       {
    //           if (MetaVariables.mapType == MetaVariables.MapType.Main)
    //           {
    //               scr_Map.Save();
    //           }
    //           else if (MetaVariables.mapType == MetaVariables.MapType.Search)
    //           {
    //               scr_SearchMap.Save();
    //           }
    //       }

    [MenuItem("HotKey/NewNode _%N")]
    static void NewNode()
    {
        print("input");
        if (MetaVariables.mapType == MetaVariables.MapType.Main)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            scr_Map.CreateNode(mousePos);
        }
    }

    //       //NEW NODE
    //       else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.N)) ||  //LeftControl then N
    //           (Input.GetKey(KeyCode.N) && Input.GetKeyDown(KeyCode.LeftControl)) ||  //N then LeftControl
    //           (Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(KeyCode.N)) || //RightControl then N
    //           (Input.GetKey(KeyCode.N) && Input.GetKeyDown(KeyCode.RightControl)))   //N then RightControl
    //       {
    //           print("get the input");
    //           if (MetaVariables.mapType == MetaVariables.MapType.Main)
    //           {
    //               Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
    //               mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    //               scr_Map.CreateNode(mousePos);
    //           }
    //       }
    //       //Context Menu
    //       else if (Input.GetMouseButtonDown(1))
    //       {
    //           Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
    //           mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    //           scr_Map.ShowContextMenu(mousePos);
    //       }


    //}
}
