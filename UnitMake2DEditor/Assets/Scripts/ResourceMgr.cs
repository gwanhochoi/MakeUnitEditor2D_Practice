using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceMgr : MonoBehaviour
{

    //필요한때 맞는 sprite를 읽어올것.
    //미리 읽지 않는다


    private static ResourceMgr m_Instance;
    public static ResourceMgr Instance
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
        if (null == m_Instance)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject Item_Prefab;

    public List<ItemBundleSO> m_hairbundleSO_List;

    private Item[] m_EyesItems;
    private Item[] m_BodyItems;
    private Item[] m_HairItems;
    private Item[] m_MustacheItems;
    private Item[] m_HelmetItems;
    private Item[] m_ClothItems;
    private Item[] m_PantsItems;
    private Item[] m_ArmorItems;
    private Item[] m_BackItems;
    private Item[] m_WeaponRItems;
    private Item[] m_WeaponLItems;

    public Item[] Get_Items(string part)
    {
        switch (part)
        {
            case "Eyes": if (m_EyesItems == null) m_EyesItems = Create_Items(part); return m_EyesItems;
            case "Body": if (m_BodyItems == null) m_BodyItems = Create_Items(part); return m_BodyItems;
            case "Hair": if (m_HairItems == null) m_HairItems = Create_Items(part); return m_HairItems;
            case "Mustache": if (m_MustacheItems == null) m_MustacheItems = Create_Items(part); return m_MustacheItems;
            case "Helmet": if (m_HelmetItems == null) m_HelmetItems = Create_Items(part); return m_HelmetItems;
            case "Cloth": if (m_ClothItems == null) m_ClothItems = Create_Items(part); return m_ClothItems;
            case "Pants": if (m_PantsItems == null) m_PantsItems = Create_Items(part); return m_PantsItems;
            case "Armor": if (m_ArmorItems == null) m_ArmorItems = Create_Items(part); return m_ArmorItems;
            case "Back": if (m_BackItems == null) m_BackItems = Create_Items(part); return m_BackItems;
            case "Weapon_R": if (m_WeaponRItems == null) m_WeaponRItems = Create_Items(part); return m_WeaponRItems;
            case "Weapon_L": if (m_WeaponLItems == null) m_WeaponLItems = Create_Items(part); return m_WeaponLItems;

            default: return null;
        }
    }


    private Item[] Create_Items(string part)
    {
        Item[] items;

        //Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/" + part);

        //items = new Item[sprites.Length];

        //for(int i = 0; i < sprites.Length; i++)
        //{
        //    GameObject obj = Instantiate(Item_Prefab);
        //    items[i] = obj.GetComponent<Item>();
        //    items[i].Init(sprites[i], StringToItemType(part));
        //}

        int index = (int)StringToItemType(part);
        int count = m_hairbundleSO_List[index].ItemList.Count;
        items = new Item[m_hairbundleSO_List[index].ItemList.Count];

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(Item_Prefab);
            items[i] = obj.GetComponent<Item>();
            items[i].Init(m_hairbundleSO_List[index].ItemList[i]);
        }

        if (items.Length == 0)
            return null;

        return items;
        
    }

    private ITEM_TYPE StringToItemType(string part)
    {
        switch (part)
        {
            case "Eyes": return ITEM_TYPE.Eyes;
            case "Body": return ITEM_TYPE.Body;
            case "Hair": return ITEM_TYPE.Hair;
            case "Mustache": return ITEM_TYPE.Mustache;
            case "Helmet": return ITEM_TYPE.Helmet;
            case "Cloth": return ITEM_TYPE.Cloth;
            case "Pants": return ITEM_TYPE.Pants;
            case "Armor": return ITEM_TYPE.Armor;
            case "Back": return ITEM_TYPE.Back;
            case "Weapon_R": return ITEM_TYPE.Weapon_R;
            case "Weapon_L": return ITEM_TYPE.Weapon_L;

            default: return ITEM_TYPE.End;
        }
    }


}
