using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class scr_Map : MonoBehaviour
{
    //##### static variables for all other classes to access #####
    static string databasePath = "URI=file:" + Application.dataPath + "/Database/CharacterRelation.db";

    //##### classes and structs for all other classes to access #####
    public class NodeData {
        public string CHARACTERID;
        public string NAME;
        public int AGE;
        public string BIRTHDATE;
        public string DEATHDATE;
        public string RACE;
        public string BEMERKUNG;
        public float POSITION_X;
        public float POSITION_Y;
    };
    public class ConnectionData {
        public string RELATIONID;
        public Node nodeA;
        public Node nodeB;
        public string BEMERKUNG;
        public string BESCHRIFTUNG;
    };

    //##### normal variables #####
    public LinkedList<Node> nodeList = new LinkedList<Node>();
    public LinkedList<Connection> connectionList = new LinkedList<Connection>();
    private int nodeCount;
    private int connectionCount;
    IDbConnection dbconn;
    GameObject nodePrefab;
    GameObject connectionPrefab;

    
    

    private void Start()
    {
        nodeCount = 0;
        dbconn = (IDbConnection)new SqliteConnection(databasePath); //set connection to database
        nodePrefab = Resources.Load<GameObject>("Prefabs/NodePrefab");
        connectionPrefab = Resources.Load<GameObject>("Prefabs/ConnectionPrefab");
    }

    void CreateNode()
    {

    }

    public void CreateRelation(Node a, Node b)
    {

    }

    public void Load()
    {
        //load all the nodes
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlStr = "SELECT * FROM CHARACTER";
        dbcmd.CommandText = sqlStr;
        IDataReader readerC = dbcmd.ExecuteReader();

        NodeData nodeData = new NodeData();
        string sqlName = "SELECT VALUE FROM NAME WHERE CHARACTER_ID = " + nodeData.CHARACTERID
                        + " ORDER BY POSITION ASC";
        IDbCommand dbcmdName = dbconn.CreateCommand();
        IDataReader readerN;
        string name;

        //create the node from the data in the db
        while (readerC.Read())
        {
            name = "";
            nodeData.CHARACTERID = readerC.GetString(0);
            nodeData.BIRTHDATE = readerC.GetString(2) + "."
                                + readerC.GetString(3) + "."
                                + readerC.GetString(4);
            nodeData.DEATHDATE = readerC.GetString(5) + "."
                                + readerC.GetString(6) + "."
                                + readerC.GetString(7);
            nodeData.RACE = readerC.GetString(8);
            nodeData.BEMERKUNG = readerC.GetString(9);
            nodeData.POSITION_X = readerC.GetFloat(10);
            nodeData.POSITION_Y = readerC.GetFloat(11);
            nodeData.AGE = readerC.GetInt32(12);

            dbcmdName.CommandText = sqlName;
            readerN = dbcmdName.ExecuteReader();
            while (readerN.Read())
            {
                name += readerN.GetString(0) + " ";
            }

            nodeData.NAME = name;

            //Hier müssen die NodePrefabs hin
            GameObject node = Instantiate(nodePrefab, new Vector2(0, 0), transform.rotation);
            node.GetComponent<Node>().GiveData(nodeData);
            nodeList.AddLast(node.GetComponent<Node>());
        }

        //load all the relations
    }

    public void Save()
    {

    }
}
