using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GlobalData
{
    //// Inventory data
    public static Dictionary<string, int> inventoryElements = new Dictionary<string, int>();
    public static string rightHand = "";
    public static string leftHand = "111001";
    
    private static string actionCode;
    private static GameObject elementGO;

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
    static void takeAction(RaycastHit hit)
    {
        rightHand = hit.transform.tag;
        Object.Destroy(hit.transform.gameObject);
    }
    static void takeToInventoryAction(RaycastHit hit)
    {
        string eTag = hit.transform.tag;
        rightHand = "";
        try {
            inventoryElements[eTag]+=1;
        }
        catch {
            inventoryElements.Add(eTag,1);
        }
    }
    static void useAction(RaycastHit hit)
    {
        string eTag = hit.transform.tag;
        if (leftHand == "")
        {
            if(eTag[3] == '1')
            {
                float x, y, z;
                x = hit.transform.position.x;
                y = hit.transform.position.y;
                z = hit.transform.position.z;
                GameObject newObject,tmp;
                tmp = (GameObject)Resources.Load("prefabs/11100" + eTag[5], typeof(GameObject));
                newObject = GameObject.Instantiate(tmp);
                newObject.transform.position+= new Vector3(x,y,z-0.3f);
                newObject = GameObject.Instantiate(tmp);
                newObject.transform.position+= new Vector3(x,y,z+0.3f);
                //newObject = (GameObject)Resources.Load("prefabs/11100" + eTag[5], typeof(GameObject));
                // newObject = GameObject.Instantiate(GameObject.FindGameObjectWithTag("11100" + eTag[5]));
                // newObject.transform.position = hit.transform.position;
                // newObject = GameObject.Instantiate(GameObject.FindGameObjectWithTag("11100" + eTag[5]));
                // ///
                Debug.Log(x.ToString() + "-" + y.ToString() + "-" + z.ToString());
                //newObject.transform.position.Set(x,y,z);
                //newObject.transform.rotation = hit.transform.rotation;
                GameObject.Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            if(leftHand == "111001" && rightHand == leftHand)
            {
                Debug.Log(rightHand);
                hit.transform.Find("Torch").gameObject.SetActive(true);
                hit.transform.tag = "000005";
            }
        }
    }
    public static void doAction(RaycastHit hit)
    {
        actionCode = get_action_code(hit.transform.tag);
        
        if(rightHand == "")
        {
            if(actionCode[0] == '1')
            {
                takeAction(hit);
            }
        }
        else
        {
            Debug.Log("asd");
            if(rightHand[1] == '1')
            {
                Debug.Log('1');
                useAction(hit);
            }
        } 

    }
}