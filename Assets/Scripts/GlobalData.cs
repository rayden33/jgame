using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static Dictionary<string, int> inventoryElements = new Dictionary<string, int>();
    
    private static string actionCode;

    // functions std
    public static string get_action_code(string elementTag)
    {
        return string.Concat(elementTag[0], elementTag[1]);
    }
    public static string get_element_code(string elementTag)
    {
        return string.Concat(elementTag[2], elementTag[3],elementTag[4]);
    }
    public static void doAction(RaycastHit hit)
    {
        actionCode = get_action_code(hit.transform.tag);
    }
}
