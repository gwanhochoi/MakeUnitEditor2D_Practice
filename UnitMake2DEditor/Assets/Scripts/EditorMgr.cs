using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public UnitListMgr unitListMgr;
    JsonUtil jsonUtil;

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

        jsonUtil = new JsonUtil();
    }


    public void Change_Unit_Items(WearItemInfo itemInfo, ITEM_TYPE item_type)
    {
        string[] parts_str = { "Body", "Eyes", "Hair", "Mustache", "Helmet", "Cloth", "Pants", "Armor", "Back", "Weapon", "Weapon" };

        
        Unit_ShowWindow.GetComponent<Character_Script>().Change_parts(item_type, parts_str[(int)item_type], itemInfo);
    }

    public void Change_Unit_Skins(List<WearSkinInfo> skin_list, string unit_name)
    {
        Unit_ShowWindow.GetComponent<Character_Script>().Wear_Skin(unit_name, skin_list);
    }

    public void Change_Item_Color(Color color, ITEM_TYPE item_type)
    {
        Unit_ShowWindow.GetComponent<Character_Script>().Change_Item_Color(item_type, color);
    }

    

    public void Save_Unit_Skin()
    {

        string filepath = Path.Combine(Application.dataPath + "/UnitSkinJson");
        DirectoryInfo directoryInfo = new DirectoryInfo(filepath);

        int index = directoryInfo.GetFiles("*.json").Length + 1;

        string path = Path.Combine(Application.dataPath + "/UnitSkinJson/", "unitskininfo_"+ index +".json");

        while(File.Exists(path))
        {
            index++;
            path = Path.Combine(Application.dataPath + "/UnitSkinJson/", "unitskininfo_" + index + ".json");
        }
        jsonUtil.Save_Data(path, Unit_ShowWindow.GetComponent<Character_Script>().Get_WearSkin_Info());

        unitListMgr.Update_List();

    }

    public void Delete_Unit(string unit_name)
    {
        unitListMgr.Delete(unit_name);
        string path = Path.Combine(Application.dataPath + "/UnitSkinJson/", unit_name);
        if(File.Exists(path))
        {
            File.Delete(path);
            File.Delete(path + ".meta");
        }
            
    }

    IEnumerator Update_Unit_List_Cor()
    {
        yield return new WaitForSecondsRealtime(0.3f);


    }
}
