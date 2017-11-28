using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaVariables : MonoBehaviour
{
    public enum MapType { Main, Search, undefined };
    [SerializeField]
    private static MapType map;
    private static Vector3 mousePos;
    private static string configPath = "../temp/config.cfg";

    public static MapType mapType {
        get { return map; }
    }

    public static Vector3 mousePosition {
        get { return mousePos; }
        set { mousePos = value; }
    }

    private void Start()
    {
        //map = MapType.undefined;
        map = MapType.Main;
    }

    private static void ReadConfig()
    {
        if (map != MapType.undefined)
            return;


        if (System.IO.File.Exists(configPath))
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(configPath);
            string line = "";
            using (reader)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("#MAPTYPE"))
                    {
                        line = line.Substring(8);
                        print(line);
                        switch (line)
                        {
                            case "main":
                                map = MapType.Main;
                                break;
                            case "search":
                                map = MapType.Search;
                                break;
                        }
                    }
                    else if (line.Contains("#SQL"))
                    {
                        line = line.Substring(4);
                    }
                }
            }
        }
    }
}
