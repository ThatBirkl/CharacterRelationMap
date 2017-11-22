using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaVariables : MonoBehaviour
{
    public enum MapType { Main, Search };
    [SerializeField]
    private static MapType map;

    public static MapType mapType {
        get { return map; }
    }
}
