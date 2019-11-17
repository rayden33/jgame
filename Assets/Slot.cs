using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item {
        get {
            if(transform.GetComponentInChildren<Image>().sprite != null)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop (PointerEventData eventData)
    {
        Debug.Log('h' + JustDragger.itemBeingDragged.transform.GetComponentInChildren<Image>().sprite.name);
        if(item)
        {
            Sprite sp = item.GetComponent<Image>().sprite;
            item.GetComponent<Image>().sprite = JustDragger.itemBeingDragged.transform.GetComponentInChildren<Image>().sprite;
            JustDragger.itemBeingDragged.transform.GetComponentInChildren<Image>().sprite = sp;
        }
        else
        {
            transform.GetComponentInChildren<Image>().sprite = JustDragger.itemBeingDragged.transform.GetComponentInChildren<Image>().sprite;
        }
        // Transform trm = JustDragger.itemBeingDragged.transform;
        // item.transform.SetParent(trm.parent);
        // //item.transform.position = new Vector3 (0,0,0);
        // JustDragger.itemBeingDragged.transform.SetParent (transform);
        // //transform.GetComponentInChildren<Image>().sprite = JustDragger.itemBeingDragged.GetComponent<Image>().sprite;
        // //Debug.Log(JustDragger.itemBeingDragged.GetComponent<Image>().sprite.name);
    }
    
}
