using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static Dictionary<string, int> inventoryElements = new Dictionary<string, int>();
    
    private static string actionCode;

    // functions utils
    public static string get_action_code(string elementTag)
    {
        return string.Concat(elementTag[0], elementTag[1]);
    }
    public static string get_element_code(string elementTag)
    {
        return string.Concat(elementTag[2], elementTag[3],elementTag[4]);
    }

    // main functions
    static void take(RaycastHit hit)
    {
        string eCode = get_element_code(hit.transform.tag);
        Object.Destroy(hit.transform.gameObject);
        try {
            inventoryElements[eCode]+=1;
        }
        catch {
            inventoryElements.Add(eCode,1);
        }
    }
    static void shoot(RaycastHit hit)
    {
        string eCode = get_element_code(hit.transform.tag);
        Object.Destroy(hit.transform.gameObject);
        try {
            inventoryElements[eCode]+=1;
        }
        catch {
            inventoryElements.Add(eCode,1);
        }
    }
    public static void doAction(RaycastHit hit)
    {
        actionCode = get_action_code(hit.transform.tag);
        Debug.Log(actionCode);
        switch(actionCode)
        {
            case "00": take(hit);
            break;
            case "01": shoot(hit);
            break;
        }
    }
}
