using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class scr_SearchMap : scr_Map
{
    /*
     * In der SearchMap wird im Prinzip nur die SuchAnfrage gespeichert;
     * Nur in der MainMap kann das Projekt gespeichert werden.
     * Wenn in die SearchMap gewechselt wird, wird voerher gefragt, ob gespeichert werden soll.
     */
    new public static void Save()
    {
        saved = true;
    }
}
