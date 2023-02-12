using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMgr : MonoBehaviour
{
    public GameObject ItemPanel;
    public GameObject ItemPopup;
    public GameObject Color_Popup;

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

    string[] parts_str = { "Body", "Eyes", "Hair", "Mustache", "Helmet", "Cloth", "Pants", "Armor", "Back", "Weapon_R", "Weapon_L" };
    public void ColorPopupOpen(string parts)
    {
        if (!Color_Popup.activeSelf)
            Color_Popup.SetActive(true);

        int index = 0;
        for(int i = 1; i < (int)ITEM_TYPE.End; i++)
        {
            if(parts_str[i] == parts)
            {
                index = i;
                break;
            }
        }
        if(index > 0)
            Color_Popup.GetComponent<Color_Popup>().item_type = ITEM_TYPE.Body + index;
    }

    public void ColorPopupClose()
    {
        if (Color_Popup.activeSelf)
            Color_Popup.SetActive(false);
    }

}
