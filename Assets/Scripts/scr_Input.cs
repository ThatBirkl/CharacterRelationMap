using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Input : MonoBehaviour
{
	void Start ()
    {
		
	}

	void Update ()
    {
        //SAVE
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) ||  //LeftControl then S
            (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.LeftControl)) ||  //S then LeftControl
            (Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(KeyCode.S)) || //RightControl then S
            (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.RightControl)))   //S then RightControl
        {
            if (MetaVariables.mapType == MetaVariables.MapType.Main)
            {
                scr_Map.Save();
            }
            else if (MetaVariables.mapType == MetaVariables.MapType.Search)
            {
                scr_SearchMap.Save();
            }
        }
        //NEW NODE
        else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.N)) ||  //LeftControl then N
            (Input.GetKey(KeyCode.N) && Input.GetKeyDown(KeyCode.LeftControl)) ||  //N then LeftControl
            (Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(KeyCode.N)) || //RightControl then N
            (Input.GetKey(KeyCode.N) && Input.GetKeyDown(KeyCode.RightControl)))   //N then RightControl
        {
            if (MetaVariables.mapType == MetaVariables.MapType.Main)
            {
                scr_Map.CreateNode();
            }
        }


	}
}
