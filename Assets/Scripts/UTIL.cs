using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class UTIL : MonoBehaviour
{
    public static string[] CHARACTER_PARAMS = { "NAME", "RACE", "AGE", "BIRTHDATE", "DEATHDATE", "BEMERKUNG" };
    public static string[] RELATION_PARAMS = { };

    public static void NewID(out string id)
    {
        id = "string";
        id += System.DateTime.Now.GetHashCode();
        id += "xxx";
        id += Time.frameCount;
        id = Base64Encode(id);
    }

    public static void NewID(out int id)
    {
        id = System.DateTime.Now.GetHashCode();
        id += Time.frameCount;
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static LinkedList<string> ParseCommaString(string s)
    {
        List<string> list = new List<string>();

        list = s.Split(',').ToList<string>();

        LinkedList<string> ret = new LinkedList<string>(list);

        return ret;
    }

    public static void SplitNameStringAndGetFontSize(string name, out string retName, out float fontSize)
    {
        retName = name.Replace(" ", "\n");
        fontSize = 0.03f;
        if (name.Length <= 6)
        {

        }
        else if (name.Length <= 12)
        {
            fontSize = 0.025f;
        }
        else if (name.Length <= 24)
        {
            fontSize = 0.02f;
        }
        else if (name.Length <= 24)
        {
            fontSize = 0.015f;
        }
    }

    public static bool UIElementContains(Vector2 coords, GameObject gameObj)
    {
        Vector2 localPos = gameObj.transform.InverseTransformPoint(coords);
        return ((RectTransform)gameObj.transform).rect.Contains(localPos);
    }

    public static void ParseQueryToSQL(string query, out string sql)
    {
        //character: tag = "", name = "", birthdate = "" -> [tag, name, birthate], ["", "", ""]
        sql = "";
        string sqlSelect = "SELECT * ";
        string sqlFrom = "FROM ";
        string sqlWhere = "WHERE ";
        bool character = false;
        bool error = false;

        string[] qArr = query.Split(':');
        qArr[0] = qArr[0].Replace(" ", "");
        qArr[0] = qArr[0].Replace(":", "");
        qArr[0] = qArr[0].ToLower();

        if (qArr[0].Equals("character"))
        {
            sqlFrom += "CHARACTER ";
            character = true;
        }
        else if (qArr[0].Equals("relation"))
        {
            sqlFrom += "RELATION ";
        }
        else
        {
            error = true;
            sql = "SQL ERROR: 1"; //replace with something better later
        }

        if (error)
            return;

        qArr = qArr[1].Split(','); // => ["tag = """, "name = """, "birthdate = """]
        string[][] subArr = new string[qArr.Length][];
        string[] pars = new string[qArr.Length];
        string[]vals = new string[qArr.Length];
        for (int i = 0; i < qArr.Length; i++)
        {
            qArr[i].Replace(",", "");
            subArr[i] = qArr[i].Split('=');
            subArr[i][0] = subArr[i][0].Replace("=", "");
            subArr[i][0] = subArr[i][0].Replace(" ", "");
            subArr[i][1] = subArr[i][1].Replace("=", "");
            subArr[i][1] = subArr[i][1].Replace(" ", ""); // => [[tag, ""], [name, ""], [birthdate, ""]]
            vals[i] = subArr[i][1];
            pars[i] = subArr[i][0]; // => [tag, name, birthdate], ["", "", ""]

            if ((!CHARACTER_PARAMS.Contains<string>(pars[i]) && character) || (!RELATION_PARAMS.Contains<string>(pars[i]) && !character))
            {
                sql = "SQL ERROR: 2";
                error = true;
                return;
            }
        }

        if (error)
            return;

        Array.Sort<string, string>(vals, pars); //both arrays are sorted so that I can check if the user wants two differen values for the same param so I can use a OR instead of AND
        print(pars);

        ////sqlWhere += subArr[0] + " LIKE '%" + subArr[1] + "%' ";

        ////if (i < qArr.Length - 1)
        ////{
        ////    sqlWhere += "AND ";
        ////}
        sql = sqlSelect + sqlFrom + sqlWhere;
    }
}
