using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM_TYPE
{
    Body = 0,
    Eyes,
    Hair,
    Mustache,
    Helmet,
    Cloth,
    Pants,
    Armor,
    Back,
    Weapon_R,
    Weapon_L,
    End

}

//case "Hair": if (m_HairItems == null) m_HairItems = Create_Items(part); return m_HairItems;
//            case "Mustache": if (m_MustacheItems == null) m_MustacheItems = Create_Items(part); return m_MustacheItems;
//            case "Helmet": if (m_HelmetItems == null) m_HelmetItems = Create_Items(part); return m_HelmetItems;
//            case "Cloth": if (m_ClothItems == null) m_ClothItems = Create_Items(part); return m_ClothItems;
//            case "Pants": if (m_PantsItems == null) m_PantsItems = Create_Items(part); return m_PantsItems;
//            case "Armor": if (m_ArmorItems == null) m_ArmorItems = Create_Items(part); return m_ArmorItems;
//            case "Back": if (m_BackItems == null) m_BackItems = Create_Items(part); return m_BackItems;
//            case "Weapon_R": cas
public class EditorMgr : MonoBehaviour
{

    private static EditorMgr m_Instance;
    public GameObject Unit_ShowWindow;

    public static EditorMgr Instance
    {
        get
        {
            if(m_Instance == null)
            {
                return null;
            }
            return m_Instance;
        }
    }

    private void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void Change_Unit_Items(ItemSO itemSO)
    {
        //Unit_ShowWindow.GetComponent<Unit_Script>().Change_Items(itemSO);
        Unit_ShowWindow.GetComponent<ItemPositionSet>().Set_Sprite(itemSO);
    }
}
