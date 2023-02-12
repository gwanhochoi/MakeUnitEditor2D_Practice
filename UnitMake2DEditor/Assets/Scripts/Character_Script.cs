using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character_Script : MonoBehaviour
{

    public string unit_name { get; set; }
    public List<WearSkinInfo> skin_list;

    public SpriteRenderer Head_SR;
    public SpriteRenderer Body_SR;
    public SpriteRenderer Arm_R_SR;
    public SpriteRenderer Arm_L_SR;
    public SpriteRenderer Leg_R_SR;
    public SpriteRenderer Leg_L_SR;

    public SpriteRenderer Eye_R_Back_SR;
    public SpriteRenderer Eye_R_Front_SR;
    public SpriteRenderer Eye_L_Back_SR;
    public SpriteRenderer Eye_L_Front_SR;

    public SpriteRenderer Hair_Helmet_SR;
    public SpriteRenderer Mustache_SR;
    public SpriteRenderer Cloth_Body_SR;
    public SpriteRenderer Cloth_R_SR;
    public SpriteRenderer Cloth_L_SR;
    public SpriteRenderer Pants_R_SR;
    public SpriteRenderer Pants_L_SR;
    public SpriteRenderer Armor_Body_SR;
    public SpriteRenderer Armor_R_SR;
    public SpriteRenderer Armor_L_SR;
    public SpriteRenderer Back_SR;
    public SpriteRenderer Weapon_R_SR;
    public SpriteRenderer Weapon_L_SR;
    public SpriteRenderer Shield_R_SR;
    public SpriteRenderer Shield_L_SR;


    public void Change_Item_Color(ITEM_TYPE item_type, Color color)
    {

        
        switch (item_type)
        {
            
            case ITEM_TYPE.Eyes: Eye_R_Front_SR.color = color; Eye_L_Front_SR.color = color; break;
            case ITEM_TYPE.Hair: case ITEM_TYPE.Helmet: Hair_Helmet_SR.color = color; break;
            case ITEM_TYPE.Mustache: Mustache_SR.color = color; break;
            case ITEM_TYPE.Cloth: Cloth_Body_SR.color = color; Cloth_R_SR.color = color; Cloth_L_SR.color = color; break;
            case ITEM_TYPE.Pants: Pants_R_SR.color = color; Pants_L_SR.color = color; break;
            case ITEM_TYPE.Armor: Armor_Body_SR.color = color; Armor_R_SR.color = color; Armor_L_SR.color = color; break;
            case ITEM_TYPE.Back: Back_SR.color = color; break;
            case ITEM_TYPE.Weapon_R:
                if(Weapon_R_SR.sprite != null)
                {
                    Weapon_R_SR.color = color;
                }
                if(Shield_R_SR.sprite != null)
                {
                    Shield_R_SR.color = color;
                }
                break;
            case ITEM_TYPE.Weapon_L:
                if (Weapon_L_SR.sprite != null)
                {
                    Weapon_L_SR.color = color;
                }
                if (Shield_L_SR.sprite != null)
                {
                    Shield_L_SR.color = color;
                }
                break;
        }
    }

    public void Change_parts(ITEM_TYPE item_type, string parts_name, WearItemInfo item)
    {

        //Hair_Helmet_SR.sprite = Resources.Load<Sprite>("Sprites/" + parts_name +"/" + item_name);
        
        Object[] objects = Resources.LoadAll<Object>("Sprites/" + parts_name + "/" + item.texture_name);
        
        
        switch (item_type)
        {
            case ITEM_TYPE.Body: Change_Body_Sprite(objects); break;
            case ITEM_TYPE.Eyes: Change_Eyes_Sprite(objects, item); break;
            case ITEM_TYPE.Hair: case ITEM_TYPE.Helmet: Change_Hair_Helmet_Sprite(objects, item); break;
            case ITEM_TYPE.Mustache: Change_Mustache_Sprite(objects, item); break;
            case ITEM_TYPE.Cloth: Change_Cloth_Sprite(objects, item); break;
            case ITEM_TYPE.Pants: Change_Pants_Sprite(objects, item); break;
            case ITEM_TYPE.Armor: Change_Armor_Sprite(objects, item); break;
            case ITEM_TYPE.Back: Change_Back_Sprite(objects, item); break;
            case ITEM_TYPE.Weapon_R: Change_Weapon_R_Sprite(objects, item); break;
            case ITEM_TYPE.Weapon_L: Change_Weapon_L_Sprite(objects, item); break;
        }

    }

    public string Get_CurrentItemName(ITEM_TYPE item_type)
    {
        switch (item_type)
        {
            case ITEM_TYPE.Body: return Body_SR.sprite != null?Body_SR.sprite.texture.name:"";
            case ITEM_TYPE.Eyes: return Eye_L_Back_SR.sprite != null?Eye_L_Back_SR.sprite.texture.name:"";
            case ITEM_TYPE.Hair: case ITEM_TYPE.Helmet: return Hair_Helmet_SR.sprite != null?Hair_Helmet_SR.sprite.texture.name:"";
            case ITEM_TYPE.Mustache: return Mustache_SR.sprite != null?Mustache_SR.sprite.texture.name:"";
            case ITEM_TYPE.Cloth: return Cloth_Body_SR.sprite != null ? Cloth_Body_SR.sprite.texture.name : "";
            case ITEM_TYPE.Pants: return Pants_L_SR.sprite != null ? Pants_L_SR.sprite.texture.name : "";
            case ITEM_TYPE.Armor: return Armor_Body_SR.sprite != null ? Armor_Body_SR.sprite.texture.name : "";
            case ITEM_TYPE.Back: return Back_SR.sprite != null ? Back_SR.sprite.texture.name : "";
            case ITEM_TYPE.Weapon_R: return Weapon_R_SR.sprite != null ? Weapon_R_SR.sprite.texture.name :
                    Shield_R_SR.sprite != null ? Shield_R_SR.sprite.texture.name : "";
            case ITEM_TYPE.Weapon_L: return Weapon_L_SR.sprite != null ? Weapon_L_SR.sprite.texture.name :
                    Shield_L_SR.sprite != null ? Shield_L_SR.sprite.texture.name : "";
            default: return "none";
        }
    }

    public void Undress_Parts(string parts)
    {
        switch(parts)
        {
            case "Eyes": Eye_R_Back_SR.sprite = null; Eye_R_Front_SR.sprite = null;
                Eye_L_Back_SR.sprite = null; Eye_L_Front_SR.sprite = null; break;
            case "Hair": case "Helmet": Hair_Helmet_SR.sprite = null; break;
            case "Mustache": Mustache_SR.sprite = null; break;
            case "Cloth": Cloth_Body_SR.sprite = null; Cloth_R_SR.sprite = null; Cloth_L_SR.sprite = null; break;
            case "Pants": Pants_R_SR.sprite = null; Pants_L_SR.sprite = null; break;
            case "Armor": Armor_Body_SR.sprite = null; Armor_R_SR.sprite = null; Armor_L_SR.sprite = null; break;
            case "Back": Back_SR.sprite = null; break;
            case "Weapon_R": Weapon_R_SR.sprite = null; Shield_R_SR.sprite = null; break;
            case "Weapon_L": Weapon_L_SR.sprite = null; Shield_L_SR.sprite = null; break;
        }
    }

    public void Underess(ITEM_TYPE item_type)
    {
        switch (item_type)
        {

            case ITEM_TYPE.Hair: case ITEM_TYPE.Helmet: Hair_Helmet_SR.sprite = null; break;
            case ITEM_TYPE.Mustache: Mustache_SR.sprite = null; break;
            case ITEM_TYPE.Cloth: Cloth_Body_SR.sprite = null; Cloth_R_SR.sprite = null; Cloth_L_SR.sprite = null; break;
            case ITEM_TYPE.Pants: Pants_R_SR.sprite = null; Pants_L_SR.sprite = null; break;
            case ITEM_TYPE.Armor: Armor_Body_SR.sprite = null; Armor_R_SR.sprite = null; Armor_L_SR.sprite = null; break;
            case ITEM_TYPE.Back: Back_SR.sprite = null; break;
            case ITEM_TYPE.Weapon_R: if (Weapon_R_SR.sprite != null) Weapon_R_SR.sprite = null;
                else {
                    if (Shield_R_SR.sprite != null)
                        Shield_R_SR.sprite = null;
                }
                break;
            case ITEM_TYPE.Weapon_L:
                if (Weapon_L_SR.sprite != null) Weapon_L_SR.sprite = null;
                else
                {
                    if (Shield_L_SR.sprite != null)
                        Shield_L_SR.sprite = null;
                }
                break;

        }
    }

    private void Change_Body_Sprite(Object[] objects)
    {
        foreach(var child in objects)
        {
            if(child is Sprite)
            {
                switch(child.name)
                {
                    case "Head": Head_SR.sprite = (Sprite)child; break;
                    case "Body": Body_SR.sprite = (Sprite)child; break;
                    case "Arm_R": Arm_R_SR.sprite = (Sprite)child; break;
                    case "Arm_L": Arm_L_SR.sprite = (Sprite)child; break;
                    case "Leg_R": Leg_R_SR.sprite = (Sprite)child; break;
                    case "Leg_L": Leg_L_SR.sprite = (Sprite)child; break;
                }
            }
        }
    }

    private void Change_Eyes_Sprite(Object[] objects, WearItemInfo item)
    {
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                switch (child.name)
                {
                    case "Front": Eye_R_Front_SR.sprite = (Sprite)child; Eye_L_Front_SR.sprite = (Sprite)child; break;
                    case "Back": Eye_R_Back_SR.sprite = (Sprite)child; Eye_L_Back_SR.sprite = (Sprite)child; break;
                }
            }
        }

        if(item.list.Count > 0)
        {
            foreach(var child in item.list)
            {
                if(child.spr_name == "Back")
                {
                    Eye_R_Back_SR.transform.localPosition = new Vector3(child.x, child.y);
                    Eye_L_Back_SR.transform.localPosition = new Vector3(child.x, child.y);
                }
                else
                {
                    //Front
                    Eye_R_Front_SR.transform.localPosition = new Vector3(child.x, child.y);
                    Eye_L_Front_SR.transform.localPosition = new Vector3(child.x, child.y);
                }
            }
        }

        
    }

    private void Change_Hair_Helmet_Sprite(Object[] objects, WearItemInfo item)
    {
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                
                Hair_Helmet_SR.sprite = (Sprite)child;
                if (item.list.Count != 0)
                {
                    Hair_Helmet_SR.transform.localPosition = new Vector3(item.list[0].x, item.list[0].y);
                }
                break;
            }
                
        }
            
    }

    private void Change_Mustache_Sprite(Object[] objects, WearItemInfo item)
    {
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                Mustache_SR.sprite = (Sprite)child;
                if (item.list.Count != 0)
                {
                    Mustache_SR.transform.localPosition = new Vector3(item.list[0].x, item.list[0].y);
                }
                break;
            }

        }
    }

    private void Change_Cloth_Sprite(Object[] objects, WearItemInfo item)
    {

        Cloth_R_SR.sprite = null;
        Cloth_L_SR.sprite = null;
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                switch (child.name)
                {
                    case "Body": Cloth_Body_SR.sprite = (Sprite)child; break;
                    case "Right": Cloth_R_SR.sprite = (Sprite)child; break;
                    case "Left": Cloth_L_SR.sprite = (Sprite)child; break;
                }
            }

        }

        if(item.list.Count > 0)
        {
            foreach(var child in item.list)
            {
                if (child.spr_name == "Body")
                    Cloth_Body_SR.transform.localPosition = new Vector3(child.x, child.y);
                else if (child.spr_name == "Right")
                    Cloth_R_SR.transform.localPosition = new Vector3(child.x, child.y);
                else //left
                    Cloth_L_SR.transform.localPosition = new Vector3(child.x, child.y);
            }
        }
    }

    private void Change_Pants_Sprite(Object[] objects, WearItemInfo item)
    {
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                switch (child.name)
                {
                    case "Right": Pants_R_SR.sprite = (Sprite)child; break;
                    case "Left": Pants_L_SR.sprite = (Sprite)child; break;
                }
            }

        }

        if (item.list.Count > 0)
        {
            foreach (var child in item.list)
            {
                if (child.spr_name == "Right")
                    Pants_R_SR.transform.localPosition = new Vector3(child.x, child.y);
                else //left
                    Pants_L_SR.transform.localPosition = new Vector3(child.x, child.y);
            }
        }
    }

    private void Change_Armor_Sprite(Object[] objects, WearItemInfo item)
    {
        Armor_R_SR.sprite = null;
        Armor_L_SR.sprite = null;
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                switch (child.name)
                {
                    case "Body": Armor_Body_SR.sprite = (Sprite)child; break;
                    case "Right": Armor_R_SR.sprite = (Sprite)child; break;
                    case "Left": Armor_L_SR.sprite = (Sprite)child; break;
                }
            }

        }

        if (item.list.Count > 0)
        {
            foreach (var child in item.list)
            {
                if (child.spr_name == "Body")
                    Armor_Body_SR.transform.localPosition = new Vector3(child.x, child.y);
                else if (child.spr_name == "Right")
                    Armor_R_SR.transform.localPosition = new Vector3(child.x, child.y);
                else //left
                    Armor_L_SR.transform.localPosition = new Vector3(child.x, child.y);
            }
        }
    }

    private void Change_Back_Sprite(Object[] objects, WearItemInfo item)
    {
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                Back_SR.sprite = (Sprite)child;
                if(item.list.Count != 0)
                {
                    Back_SR.transform.localPosition = new Vector3(item.list[0].x, item.list[0].y);
                }
                break;
            }
        }


    }

    private void Change_Weapon_R_Sprite(Object[] objects, WearItemInfo item)
    {
        
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                if(child.name.Contains("Shield"))
                {
                    Shield_R_SR.sprite = (Sprite)child;
                    Weapon_R_SR.sprite = null;
                    if (item.list.Count != 0)
                    {
                        Shield_R_SR.transform.localPosition = new Vector3(item.list[0].x, item.list[0].y);
                    }
                }
                else
                {
                    Shield_R_SR.sprite = null;
                    Weapon_R_SR.sprite = (Sprite)child;
                    if (item.list.Count != 0)
                    {
                        Weapon_R_SR.transform.localPosition = new Vector3(item.list[0].x, item.list[0].y);
                    }
                }
                    
                break;
            }

        }
    }

    private void Change_Weapon_L_Sprite(Object[] objects, WearItemInfo item)
    {
        foreach (var child in objects)
        {
            if (child is Sprite)
            {
                if (child.name.Contains("Shield"))
                {
                    Shield_L_SR.sprite = (Sprite)child;
                    Weapon_L_SR.sprite = null;
                    if (item.list.Count != 0)
                    {
                        Shield_L_SR.transform.localPosition = new Vector3(item.list[0].x, item.list[0].y);
                    }
                }
                else
                {
                    Shield_L_SR.sprite = null;
                    Weapon_L_SR.sprite = (Sprite)child;
                    if (item.list.Count != 0)
                    {
                        Weapon_L_SR.transform.localPosition = new Vector3(item.list[0].x, item.list[0].y);
                    }
                }
                    
                break;
            }

        }
    }

    public List<WearSkinInfo> Get_WearSkin_Info()
    {

        List<WearSkinInfo> wearSkinInfo_List = new List<WearSkinInfo>();

        if(Body_SR.sprite != null)
        {
            WearSkinInfo bodySkinInfo = new WearSkinInfo("Body", Body_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Body_SR.color)) ;
            wearSkinInfo_List.Add(bodySkinInfo);
        }

        if (Eye_L_Front_SR.sprite != null)
        {
            WearSkinInfo eyesSkinInfo = new WearSkinInfo("Eyes", Eye_L_Front_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Eye_L_Front_SR.color));
            wearSkinInfo_List.Add(eyesSkinInfo);
        }

        if (Hair_Helmet_SR.sprite != null)
        {
            WearSkinInfo hairHelmetSkinInfo = new WearSkinInfo("Hair_Helmet", Hair_Helmet_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Hair_Helmet_SR.color));
            wearSkinInfo_List.Add(hairHelmetSkinInfo);
        }

        if (Mustache_SR.sprite != null)
        {
            WearSkinInfo mustacheSkinInfo = new WearSkinInfo("Mustache", Mustache_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Mustache_SR.color));
            wearSkinInfo_List.Add(mustacheSkinInfo);
        }

        if (Cloth_Body_SR.sprite != null)
        {
            WearSkinInfo clothSkinInfo = new WearSkinInfo("Cloth", Cloth_Body_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Cloth_Body_SR.color));
            wearSkinInfo_List.Add(clothSkinInfo);
        }

        if (Pants_R_SR.sprite != null)
        {
            WearSkinInfo pantsSkinInfo = new WearSkinInfo("Pants", Pants_R_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Pants_R_SR.color));
            wearSkinInfo_List.Add(pantsSkinInfo);
        }

        if (Armor_Body_SR.sprite != null)
        {
            WearSkinInfo armorSkinInfo = new WearSkinInfo("Armor", Armor_Body_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Armor_Body_SR.color));
            wearSkinInfo_List.Add(armorSkinInfo);
        }

        if (Back_SR.sprite != null)
        {
            WearSkinInfo backSkinInfo = new WearSkinInfo("Back", Back_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Back_SR.color));
            wearSkinInfo_List.Add(backSkinInfo);
        }

        if (Weapon_R_SR.sprite != null)
        {
            WearSkinInfo weapon_R_SkinInfo = new WearSkinInfo("Weapon_R", Weapon_R_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Weapon_R_SR.color));
            wearSkinInfo_List.Add(weapon_R_SkinInfo);
        }

        if (Weapon_L_SR.sprite != null)
        {
            WearSkinInfo weapon_L_SkinInfo = new WearSkinInfo("Weapon_L", Weapon_L_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Weapon_L_SR.color));
            wearSkinInfo_List.Add(weapon_L_SkinInfo);
        }

        if (Shield_R_SR.sprite != null)
        {
            WearSkinInfo shield_R_SkinInfo = new WearSkinInfo("Weapon_R", Shield_R_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Shield_R_SR.color));
            wearSkinInfo_List.Add(shield_R_SkinInfo);
        }

        if (Shield_L_SR.sprite != null)
        {
            WearSkinInfo shield_L_SkinInfo = new WearSkinInfo("Weapon_L", Shield_L_SR.sprite.texture.name,
                ColorUtility.ToHtmlStringRGBA(Shield_L_SR.color));
            wearSkinInfo_List.Add(shield_L_SkinInfo);
        }

        return wearSkinInfo_List;
    }

    public Dictionary<string, WearItemInfo> Get_WearItem_Info()
    {
        //현재 장착된 아이템들의 정보를 리턴
        Dictionary<string, WearItemInfo> wear_dic = new Dictionary<string, WearItemInfo>();

        if(Eye_L_Back_SR.sprite != null)
        {
            WearItemInfo eye_Info = new WearItemInfo(Eye_L_Back_SR.sprite.texture.name);
            eye_Info.Add_SpriteNP(new SpriteNP(Eye_L_Back_SR.sprite.name,
                Eye_L_Back_SR.transform.localPosition.x, Eye_L_Back_SR.transform.localPosition.y));
            eye_Info.Add_SpriteNP(new SpriteNP(Eye_L_Front_SR.sprite.name,
                Eye_L_Front_SR.transform.localPosition.x, Eye_L_Front_SR.transform.localPosition.y));

            wear_dic.Add("Eyes", eye_Info);


        }

        if(Hair_Helmet_SR.sprite != null)
        {
            WearItemInfo hair_helmet_info = new WearItemInfo(Hair_Helmet_SR.sprite.texture.name);
            hair_helmet_info.Add_SpriteNP(new SpriteNP(Hair_Helmet_SR.sprite.name,
                Hair_Helmet_SR.transform.localPosition.x, Hair_Helmet_SR.transform.localPosition.y));

            wear_dic.Add("Hair_Helmet", hair_helmet_info);
        }

        if(Mustache_SR.sprite != null)
        {
            WearItemInfo mustache_info = new WearItemInfo(Mustache_SR.sprite.texture.name);
            mustache_info.Add_SpriteNP(new SpriteNP(Mustache_SR.sprite.name,
                Mustache_SR.transform.localPosition.x, Mustache_SR.transform.localPosition.y));

            wear_dic.Add("Mustache", mustache_info);
        }


        if (Cloth_Body_SR.sprite != null)
        {
            WearItemInfo cloth_info = new WearItemInfo(Cloth_Body_SR.sprite.texture.name);
            cloth_info.Add_SpriteNP(new SpriteNP(Cloth_Body_SR.sprite.name,
                Cloth_Body_SR.transform.localPosition.x, Cloth_Body_SR.transform.localPosition.y));
            cloth_info.Add_SpriteNP(new SpriteNP(Cloth_R_SR.sprite.name,
                Cloth_R_SR.transform.localPosition.x, Cloth_R_SR.transform.localPosition.y));
            cloth_info.Add_SpriteNP(new SpriteNP(Cloth_L_SR.sprite.name,
                Cloth_L_SR.transform.localPosition.x, Cloth_L_SR.transform.localPosition.y));

            wear_dic.Add("Cloth", cloth_info);
        }

        if (Pants_R_SR.sprite != null)
        {
            WearItemInfo pants_info = new WearItemInfo(Pants_R_SR.sprite.texture.name);
            pants_info.Add_SpriteNP(new SpriteNP(Pants_R_SR.sprite.name,
                Pants_R_SR.transform.localPosition.x, Pants_R_SR.transform.localPosition.y));
            pants_info.Add_SpriteNP(new SpriteNP(Pants_L_SR.sprite.name,
                Pants_L_SR.transform.localPosition.x, Pants_L_SR.transform.localPosition.y));

            wear_dic.Add("Pants", pants_info);
        }

        if (Armor_Body_SR.sprite != null)
        {
            WearItemInfo armor_info = new WearItemInfo(Armor_Body_SR.sprite.texture.name);
            armor_info.Add_SpriteNP(new SpriteNP(Armor_Body_SR.sprite.name,
                Armor_Body_SR.transform.localPosition.x, Armor_Body_SR.transform.localPosition.y));
            if(Armor_R_SR.sprite != null)
                armor_info.Add_SpriteNP(new SpriteNP(Armor_R_SR.sprite.name,
                Armor_R_SR.transform.localPosition.x, Armor_R_SR.transform.localPosition.y));
            if (Armor_L_SR.sprite != null)
                armor_info.Add_SpriteNP(new SpriteNP(Armor_L_SR.sprite.name,
                Armor_L_SR.transform.localPosition.x, Armor_L_SR.transform.localPosition.y));

            wear_dic.Add("Armor", armor_info);
        }

        if (Back_SR.sprite != null)
        {
            WearItemInfo back_info = new WearItemInfo(Back_SR.sprite.texture.name);
            back_info.Add_SpriteNP(new SpriteNP(Back_SR.sprite.name,
                Back_SR.transform.localPosition.x, Back_SR.transform.localPosition.y));

            wear_dic.Add("Back", back_info);
        }

        if(Weapon_R_SR.sprite != null)
        {
            WearItemInfo weapon_info = new WearItemInfo(Weapon_R_SR.sprite.texture.name);
            weapon_info.Add_SpriteNP(new SpriteNP(Weapon_R_SR.sprite.name,
                Weapon_R_SR.transform.localPosition.x, Weapon_R_SR.transform.localPosition.y));

            wear_dic.Add("Weapon_R", weapon_info);
        }

        if (Weapon_L_SR.sprite != null)
        {
            WearItemInfo weapon_info = new WearItemInfo(Weapon_L_SR.sprite.texture.name);
            weapon_info.Add_SpriteNP(new SpriteNP(Weapon_L_SR.sprite.name,
                Weapon_L_SR.transform.localPosition.x, Weapon_L_SR.transform.localPosition.y));

            wear_dic.Add("Weapon_L", weapon_info);
        }

        if (Shield_R_SR.sprite != null)
        {
            WearItemInfo shield_info = new WearItemInfo(Shield_R_SR.sprite.texture.name);
            shield_info.Add_SpriteNP(new SpriteNP(Shield_R_SR.sprite.name,
                Shield_R_SR.transform.localPosition.x, Shield_R_SR.transform.localPosition.y));

            wear_dic.Add("Weapon_R", shield_info);
        }

        if (Shield_L_SR.sprite != null)
        {
            WearItemInfo shield_info = new WearItemInfo(Shield_L_SR.sprite.texture.name);
            shield_info.Add_SpriteNP(new SpriteNP(Shield_L_SR.sprite.name,
                Shield_L_SR.transform.localPosition.x, Shield_L_SR.transform.localPosition.y));

            wear_dic.Add("Weapon_L", shield_info);
        }

        return wear_dic;
    }

    public void Wear_Skin(string unit_name, List<WearSkinInfo> skin_list)
    {
        Reset_Sprites();
        this.unit_name = unit_name;
        this.skin_list = skin_list;

        foreach (var child in skin_list)
        {
            if(child.part == "Hair_Helmet")
            {
                if(ResourceMgr.Instance.Get_Items("Hair").ContainsKey(child.name))
                {
                    child.part = "Hair";
                }
                else if(ResourceMgr.Instance.Get_Items("Helmet").ContainsKey(child.name))
                {
                    child.part = "Helmet";
                }
            }


            if(ResourceMgr.Instance.Get_Items(child.part) == null)
            {
                Debug.Log("nullllll");
                return;
            }
            

            WearItemInfo wearItemInfo = ResourceMgr.Instance.Get_Items(child.part)[child.name].itemInfo;
            string part = child.part;
            if (child.part == "Weapon_R" || child.part == "Weapon_L")
                part = "Weapon";
            Object[] objects = Resources.LoadAll<Object>("Sprites/" + part + "/" + child.name);
            Color color;
            ColorUtility.TryParseHtmlString("#" + child.color, out color);
            switch (child.part)
            {
                case "Body": Change_Body_Sprite(objects);  break;
                case "Eyes": Change_Eyes_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Eyes, color); break;
                case "Hair": case "Helmet": Change_Hair_Helmet_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Hair, color); break;
                case "Mustache": Change_Mustache_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Mustache, color); break;
                case "Cloth": Change_Cloth_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Cloth, color); break;
                case "Pants": Change_Pants_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Pants, color); break;
                case "Armor": Change_Armor_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Armor, color); break;
                case "Back": Change_Back_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Back, color); break;
                case "Weapon_R": Change_Weapon_R_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Weapon_R, color); break;
                case "Weapon_L": Change_Weapon_L_Sprite(objects, wearItemInfo); Change_Item_Color(ITEM_TYPE.Weapon_L, color); break;
            }
        }
    }

    public void Change_ShowWindow_Character()
    {
        
        EditorMgr.Instance.Change_Unit_Skins(skin_list, unit_name);
    }

    public void Delete()
    {
        EditorMgr.Instance.Delete_Unit(unit_name);
        
    }

    public void Reset_Sprites()
    {

        Eye_R_Back_SR.sprite = null;
        Eye_R_Front_SR.sprite = null;
        Eye_L_Back_SR.sprite = null;
        Eye_L_Front_SR.sprite = null;

        Hair_Helmet_SR.sprite = null;
        Mustache_SR.sprite = null;
        Cloth_Body_SR.sprite = null;
        Cloth_R_SR.sprite = null;
        Cloth_L_SR.sprite = null;
        Pants_R_SR.sprite = null;
        Pants_L_SR.sprite = null;
        Armor_Body_SR.sprite = null;
        Armor_R_SR.sprite = null;
        Armor_L_SR.sprite = null;
        Back_SR.sprite = null;
        Weapon_R_SR.sprite = null;
        Weapon_L_SR.sprite = null;
        Shield_R_SR.sprite = null;
        Shield_L_SR.sprite = null;

    }


    
}
