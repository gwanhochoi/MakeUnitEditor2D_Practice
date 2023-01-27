using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMgr : MonoBehaviour
{
    public GameObject ItemPanel;
    public GameObject ItemPopup;

    public void ItemPopupOpen(string name)
    {

        if(!ItemPanel.activeSelf)
        {
            ItemPanel.SetActive(true);
            
        }
        ItemPopup.GetComponent<Item_Popup>().Update_ItemList(name);
    }

    public void ItemPopupClose()
    {
        if (ItemPanel.activeSelf)
        {
            ItemPanel.SetActive(false);

        }
    }

}
