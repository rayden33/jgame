using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAction : MonoBehaviour
{
    public float actionRange = 5f;

    private string actionCode;
    private string elementCode;
    private Dictionary<string, int> inventoryElements = GlobalData.inventoryElements;

    string get_action_code(string elementTag)
    {
        return string.Concat(elementTag[0], elementTag[1]);
    }
    string get_element_code(string elementTag)
    {
        return string.Concat(elementTag[2], elementTag[3],elementTag[4]);
    }
    // actions with elemnts
    void take(RaycastHit hit)
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit, actionRange))
                 if (hit.transform != null) {
                     actionCode = get_action_code(hit.transform.tag);
                     Debug.Log(actionCode);
                     if (actionCode == "00")   // elemnts for inventory
                     {
                         take(hit);
                         foreach(KeyValuePair<string,int> p in inventoryElements)
                         {
                             Debug.Log(p.Key + '-' + p.Value);
                         }
                     }
                 }
         }
    }
}
