using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Connection : MonoBehaviour
{
    private scr_Map.ConnectionData data;
    public int id;

    public void GiveData(scr_Map.ConnectionData _data)
    {
        data = _data;
        Connect();
    }

    private void Connect()
    {
        //Calculate, which corners are closest together
        //Draws a line between those 2 corners
    }

    private void OnMouseOver()
    {
        
    }
}
