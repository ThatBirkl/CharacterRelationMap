using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
