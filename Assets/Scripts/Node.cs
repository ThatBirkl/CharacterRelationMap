using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Node : MonoBehaviour
{
    int id;
    private scr_Map.NodeData data;
    
    LinkedList<string> TAGS = new LinkedList<string>();

    public void GiveData(scr_Map.NodeData _data)
    {
        this.data = _data;
        gameObject.transform.position = new Vector2(data.POSITION_X, data.POSITION_Y);
    }

    public void Save()
    {

    }
}
