using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UTIL : MonoBehaviour
{
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
}
