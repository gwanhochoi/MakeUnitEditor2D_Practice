using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

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
        jsonUtil = new JsonUtil();
    }


    public List<WearSkinInfo> m_WearSkinInfo { get; set; }

    private void Start()
    {
        //string path = Path.Combine(Application.dataPath + "/UnitSkinJson");
        //DirectoryInfo directoryInfo = new DirectoryInfo(path);
        
        //foreach(FileInfo fileInfo in directoryInfo.GetFiles("*.json"))
        //{
            
        //}

        //m_WearSkinInfo = jsonUtil.Load_Data<List<WearSkinInfo>>(path);
    }



    JsonUtil jsonUtil;

    public GameObject Item_Prefab;


    //private Item[] m_EyesItems;
    //private Item[] m_BodyItems;
    //private Item[] m_HairItems;
    //private Item[] m_MustacheItems;
    //private Item[] m_HelmetItems;
    //private Item[] m_ClothItems;
    //private Item[] m_PantsItems;
    //private Item[] m_ArmorItems;
    //private Item[] m_BackItems;
    //private Item[] m_WeaponRItems;
    //private Item[] m_WeaponLItems;

    public Dictionary<string, Item> m_EyesItems = null;
    public Dictionary<string, Item> m_BodyItems = null;
    public Dictionary<string, Item> m_HairItems = null;
    public Dictionary<string, Item> m_MustacheItems = null;
    public Dictionary<string, Item> m_HelmetItems = null;
    public Dictionary<string, Item> m_ClothItems = null;
    public Dictionary<string, Item> m_PantsItems = null;
    public Dictionary<string, Item> m_ArmorItems = null;
    public Dictionary<string, Item> m_BackItems = null;
    public Dictionary<string, Item> m_WeaponRItems = null;
    public Dictionary<string, Item> m_WeaponLItems = null;

    public Dictionary<string, Item> Get_Items(string part)
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

    

    private Dictionary<string, Item> Create_Items(string part)
    {
        Dictionary<string, Item> items = new Dictionary<string, Item>();

        string o_parts = part;

        if (o_parts == "Weapon_R" || o_parts == "Weapon_L")
            o_parts = "Weapon";

        //Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/" + o_parts);
        Texture2D[] textures = Resources.LoadAll<Texture2D>("Sprites/" + o_parts);

        ITEM_TYPE item_type = StringToItemType(part);

        if (part == "Hair" || part == "Helmet")
            part = "Hair_Helmet";

        //load json
        string path = Path.Combine(Application.dataPath + "/ItemJson/", part + ".json");

        List<WearItemInfo> iteminfo_list = jsonUtil.Load_Data < List < WearItemInfo >> (path);
        Dictionary<string, WearItemInfo> items_dic = new Dictionary<string, WearItemInfo>();

        if (iteminfo_list == null)
        {
            if (part != "Body")
            {
                return null;
            }
            
        }
        else
        {
            foreach (var child in iteminfo_list)
            {
                items_dic[child.texture_name] = child;
            }
        }
            
        
        //items = new Item[sprites.Length];
        //items = new Item[textures.Length];

        for (int i = 0; i < textures.Length; i++)
        {
            GameObject obj = Instantiate(Item_Prefab);
            items[textures[i].name] = obj.GetComponent<Item>();
            items[textures[i].name].Init(textures[i], items_dic.ContainsKey(textures[i].name)? items_dic[textures[i].name]:null,
                item_type);
        }


        if (items.Count == 0)
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
