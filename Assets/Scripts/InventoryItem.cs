using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private Dictionary<string, int> invData;
    public GameObject playerInventory;
    public GameObject playerEquipment;
    public GameObject playerCrafting;

    public void CraftAction()
    {
        string aElement, bElement, cElement;
<<<<<<< HEAD
         aElement = playerCrafting.transform.Find("slot/a").GetComponent<Image>().sprite.name;
         bElement = playerCrafting.transform.Find("slot/b").GetComponent<Image>().sprite.name;
        // cElement = playerCrafting.transform.Find("slot/c").GetComponent<Image>().sprite.name;
        // aElement = "011104800002";
        // bElement = "011104800002";
=======
        // aElement = playerCrafting.transform.Find("slot/a").GetComponent<Image>().sprite.name;
        // bElement = playerCrafting.transform.Find("slot/b").GetComponent<Image>().sprite.name;
        // cElement = playerCrafting.transform.Find("slot/c").GetComponent<Image>().sprite.name;
        aElement = "011104800002";
        bElement = "011104800002";
>>>>>>> 18693f8... Script_fixing
        cElement = "";
        if(aElement != null && bElement != null && (cElement == null||cElement == ""))
        {
            //cElement
            cElement = CraftSystem.CraftTwoEl(aElement,bElement);
        }
        else
        {
            Debug.Log("Crafting error");
        }
        if(cElement == "")
        {
            Debug.Log("Not found");
        }
        else
        {
            Debug.Log(cElement);
        }
    }

    void syncElementsAction()
    {
        invData = GlobalData.inventoryElements;
        int i = 1;
        Debug.Log(invData.Count);
        Transform tran = playerEquipment.transform.Find("slot/right");
        Image img = tran.GetComponent<Image>();
        img.sprite = Resources.Load("sprites/" + GlobalData.right, typeof(Sprite)) as Sprite;
        foreach(KeyValuePair<string, int> kv in invData)
        {
            tran = playerInventory.transform.Find("slot/" + i.ToString());
            img = tran.GetComponent<Image>();
            img.sprite = Resources.Load("sprites/" + kv.Key, typeof(Sprite)) as Sprite;
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GlobalData.syncElements)
        {
            syncElementsAction();
            GlobalData.syncElements = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
