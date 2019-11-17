using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


///// Optional (able)
// 0 - fire {1,0}
// 1 - take {1,0}
// 2 - impact {1,0}
// 3 - shoot {1,0}
// 4 - decrafting {1,0}
///// Variable 
// 5 - mass {1 ... 9}
// 6 - strong lvl {1 ... 9}
// 7 - eat lvl {1 ... 9}
// 8 - HV(Health & Venom) lvl {1 ... 9}
// 9..11 - Element id;

public static class GlobalData
{
    //// Inventory data
    public static Dictionary<string, string> mainElements = new Dictionary<string, string>()
    {
        {"011115800011","rock(small)"},
        {"011104800001","rock(knife)"},
        {"111116500022","stick(large)"},
        {"111103600002","stick"},
        {"111104400003","bambook(large)"},
        {"111104500004","palm_core"},
        {"000013754055","molusk"},
        {"010103363006","fish"},
        {"010103363v06","fish"},
        {"000011226+88","plant(+)"},
        {"000011226-88","plant(-)"},
        {"000011226=88","plant(=)"},
        {"000011226+08","drugs"},
        {"011107800012","axe"},
        {"011109800122","lance"},
        {"000015800099","water(big)"},
        {"000015800s99","water(big,solid)"},
        {"010014000049","water in palm core"},
        {"010014000s49","water solid in palm core"},
        {"010109747007","coco"}
    };

    // public static string[,] crafTable = new string[10,10]{
    //     {"","","","","","","","","",""},
    //     {"","022","","","","","","","",""},
    //     {"","","","","","","","","",""},
    //     {"","","","","","","","","",""},
    //     {"","","","","","","","","",""},
    //     {"","","","","","","","","",""},
    //     {"","","","","","","","","",""},
    //     {"","","","","","","","+88","",""},
    //     {"","","","","","","","","",""},
    //     {"","","","","","","","","",""}
    // };
    public static Dictionary<string, int> inventoryElements = new Dictionary<string, int>();
    public static string right = "";
    public static string left = "";
    public static bool syncElements;
    
    private static string eTag;
    private static GameObject elementGO;

    // functions utils


    // main functions
    static void takeAction(RaycastHit hit)
    {
        right = hit.transform.tag;
        Object.Destroy(hit.transform.gameObject);
    }
    static void takeToInventoryAction(RaycastHit hit)
    {
        string eTag = hit.transform.tag;
        right = "";
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
        if (left == "")
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
                // 
                //newObject.transform.position.Set(x,y,z);
                //newObject.transform.rotation = hit.transform.rotation;
                GameObject.Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            if(left == "111001" && right == left)
            {
                hit.transform.Find("Torch").gameObject.SetActive(true);
                hit.transform.tag = "000005";
            }
        }
    }
    public static void doAction(RaycastHit hit)
    {
        eTag = hit.transform.tag;
        
        if(right == "")
        {
            if(eTag[1] == '1')
            {
                takeAction(hit);
            }
        }
        else
        {
            if(right[2] == '1')
            {
                useAction(hit);
            }
        } 

    }
}