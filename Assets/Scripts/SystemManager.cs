using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityEngine;
using UnityEditor;

public class SystemManager : MonoBehaviour
{

    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.MouseLook m_MouseLook;
    private bool invPanelAct = false;
    public Canvas inventoryPanel;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            invPanelAct = !invPanelAct;
            inventoryPanel.gameObject.SetActive(invPanelAct);
            m_MouseLook.SetCursorLock(false);
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = !invPanelAct;
            GlobalData.syncElements = false;
        }
    }
}
