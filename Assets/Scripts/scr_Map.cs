using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class scr_Map : MonoBehaviour
{
    //##### static variables for all other classes to access #####
#if UNITY_EDITOR
	static string databasePath = "URI=file:" + Application.dataPath + "/Database/TestDB.db";
#else
	static string databasePath = "URI=file:" + Application.dataPath + "/Database/CharacterRelation.db";
#endif
    

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
        public LinkedList<string> TAGS;
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
    public bool saved = true;

    
    

    private void Start()
    {
        nodeCount = 0;
        dbconn = (IDbConnection)new SqliteConnection(databasePath); //set connection to database
        nodePrefab = Resources.Load<GameObject>("Prefabs/NodePrefab");
        connectionPrefab = Resources.Load<GameObject>("Prefabs/ConnectionPrefab");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F))
        {
            Save();
        }
    }

    void CreateNode()
    {
        saved = false;
    }

    public void CreateRelation()
    {
        saved = false;
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
        string sqlName = "";
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

            //name
            sqlName = "SELECT VALUE FROM NAME WHERE CHARACTER_ID = " + nodeData.CHARACTERID
                        + " ORDER BY POSITION ASC";
            dbcmdName.CommandText = sqlName;
            readerN = dbcmdName.ExecuteReader();
            while (readerN.Read())
            {
                name += readerN.GetString(0) + " ";
            }
            nodeData.NAME = name;

            //tags
            sqlName = "SELECT VALUE FROM TAG WHERE CHARACTER_ID = " + nodeData.CHARACTERID;
            dbcmdName.CommandText = sqlName;
            readerN = dbcmdName.ExecuteReader();
            nodeData.TAGS = new LinkedList<string>();
            while (readerN.Read())
            {
                nodeData.TAGS.AddLast(readerN.GetString(0));
            }
            
            GameObject node = Instantiate(nodePrefab, new Vector2(0, 0), transform.rotation);
            node.GetComponent<Node>().GiveData(nodeData);
            node.GetComponent<Node>().id = nodeCount;
            nodeCount++;
            nodeList.AddLast(node.GetComponent<Node>());
        }

        //load all the relations
        ConnectionData connectionData = new ConnectionData();
        sqlStr = "SELECT * FROM RELATION";
        dbcmd.CommandText = sqlStr;
        readerC = dbcmd.ExecuteReader();
        string c1 = "";
        string c2 = "";

        while (readerC.Read())
        {
            c1 = readerC.GetString(1);
            c2 = readerC.GetString(2);

            LinkedList<Node>.Enumerator e = nodeList.GetEnumerator();
            bool w1 = true;
            bool w2 = true;

            while (w1 || w2)
            {
                e.MoveNext();
                if (e.Current.GetData().CHARACTERID.Equals(c1))
                {
                    w1 = false;
                    connectionData.nodeA = e.Current;
                }
                else if (e.Current.GetData().CHARACTERID.Equals(c2))
                {
                    w2 = false;
                    connectionData.nodeB = e.Current;
                }
            }
            connectionData.RELATIONID = readerC.GetString(0);
            connectionData.BEMERKUNG = readerC.GetString(3);
            connectionData.BESCHRIFTUNG = readerC.GetString(4);

            GameObject connection = Instantiate(connectionPrefab, new Vector2(0, 0), transform.rotation);
            connection.GetComponent<Connection>().GiveData(connectionData);
            connection.GetComponent<Connection>().id = connectionCount;
            connectionCount++;
            connectionList.AddLast(connection.GetComponent<Connection>());
        }
    }

    public void Save()
    {
        saved = true;
    }

    public void End()
    {
        if (saved)
        {

        }
        else
        {

        }
    }

    public void Find()
    {

    }
}
