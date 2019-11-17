using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CraftSystem
{
    public static string CraftTwoEl(string a, string b)
    {
        Dictionary<string,string> dic = GlobalData.mainElements;
        string result="";
        string elementCode;
        char r1 = a[a.Length-1];
        char r2 = b[b.Length-1];
        string resCode = "0" + r1 + r2;
        foreach(KeyValuePair<string,string> kp in dic)
        {
            elementCode = kp.Key;
            elementCode = elementCode.Substring(elementCode.Length - 3);
            if(elementCode == resCode)
            {
                result = kp.Key;
            }
        }
        //Debug.Log();
        return result;
    }
}
