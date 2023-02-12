using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public enum EditFlag
{
    NONE = 0,
    SAVE
}

public class CharacterEditorWindow : EditorWindow
{
    

    [MenuItem("Window/MakeUnitEditor")]
    static void Open()
    {
        GetWindow<CharacterEditorWindow>();
    }


    Character_Script character;
    
    string[] parts_str = { "Body", "Eyes", "Hair", "Mustache", "Helmet", "Cloth", "Pants", "Armor", "Back", "Weapon_R", "Weapon_L" };

    int selected_parts = -1;
    int prev_selected_parts = -1;

    Vector2 scrollPosition;
    int selected_item = -1;
    int prev_selected_item = -1;

    Texture2D []textures;
    Texture2D[] resizingTextures;
    string parts_name = "";


    EditFlag editFlag = EditFlag.NONE;

    private void OnGUI()
    {

        EditorGUI.BeginChangeCheck();

        character = (Character_Script)EditorGUILayout.ObjectField("human obj", character, typeof(Character_Script), true);


        if (GUILayout.Button("Save Items Position"))
        {
            if (character != null)
                Save();
            editFlag = EditFlag.SAVE;
        }

        if (GUILayout.Button("Reset Sprites"))
        {
            if (character != null)
                character.Reset_Sprites();
        }


        selected_parts = GUILayout.SelectionGrid(selected_parts, parts_str, 6);
        
        if (selected_parts != prev_selected_parts)
        {
            
            parts_name = parts_str[selected_parts];
            if (parts_name == "Weapon_R" || parts_name == "Weapon_L")
                parts_name = "Weapon";
            textures = Resources.LoadAll<Texture2D>("Sprites/" + parts_name);
            resizingTextures = new Texture2D[textures.Length];

            string current_texture_name = "";
            if (character != null)
                current_texture_name = character.Get_CurrentItemName(ITEM_TYPE.Body + selected_parts);

            bool search_item = false;

            for (int i = 0; i < textures.Length; i++)
            {
                if(current_texture_name == textures[i].name)
                {
                    selected_item = i;
                    prev_selected_item = i;
                    search_item = true;
                }
                resizingTextures[i] = Resize(textures[i], textures[i].width * 2, textures[i].height * 2);
            }


            if(!search_item)
            {
                selected_item = -1;
                prev_selected_item = -1;
            }
            

        }

        
        if(resizingTextures != null)
        {
            using (EditorGUILayout.ScrollViewScope scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scrollView.scrollPosition;
                selected_item = GUILayout.SelectionGrid(selected_item, resizingTextures, 4, 
                    GUILayout.Width(position.width - 20),
                        GUILayout.Height((position.width - 20) / 4 * Mathf.CeilToInt((float)resizingTextures.Length / 4)));

                
            }
        }

        

        if(EditorGUI.EndChangeCheck())
        {

            if(editFlag != EditFlag.SAVE)
            {
                if (selected_parts == prev_selected_parts)
                {
                    if (selected_item > -1 && selected_item == prev_selected_item)
                    {
                        //remove sprite
                        if (character != null)
                        {
                            character.Underess(ITEM_TYPE.Body + selected_parts);
                            selected_item = -1;
                            prev_selected_item = -1;
                        }
                    }

                    else if (selected_item > -1 && selected_item != prev_selected_item)
                    {
                        prev_selected_item = selected_item;
                        if (character != null)
                            character.Change_parts(ITEM_TYPE.Body + selected_parts, parts_name,
                                Get_ItemInfo(ITEM_TYPE.Body + selected_parts, textures[selected_item].name));

                    }
                }
            }

            if(selected_parts != prev_selected_parts)
                prev_selected_parts = selected_parts;

        }

        editFlag = EditFlag.NONE;
    }

    private WearItemInfo Get_ItemInfo(ITEM_TYPE item_type, string name)
    {
        //"Body", "Eyes", "Hair", "Mustache", "Helmet", "Cloth", "Pants", "Armor", "Back", "Weapon_R", "Weapon_L"
        WearItemInfo wearItem = null;
        switch(item_type)
        {
            case ITEM_TYPE.Eyes: wearItem = items_dic[0].ContainsKey(name) ? items_dic[0][name] : null; break;
            case ITEM_TYPE.Hair: case ITEM_TYPE.Helmet: wearItem = items_dic[1].ContainsKey(name) ? items_dic[1][name] : null; break;
            case ITEM_TYPE.Mustache: wearItem = items_dic[2].ContainsKey(name) ? items_dic[2][name] : null; break;
            case ITEM_TYPE.Cloth: wearItem = items_dic[3].ContainsKey(name) ? items_dic[3][name] : null; break;
            case ITEM_TYPE.Pants: wearItem = items_dic[4].ContainsKey(name) ? items_dic[4][name] : null; break;
            case ITEM_TYPE.Armor: wearItem = items_dic[5].ContainsKey(name) ? items_dic[5][name] : null; break;
            case ITEM_TYPE.Back: wearItem = items_dic[6].ContainsKey(name) ? items_dic[6][name] : null; break;
            case ITEM_TYPE.Weapon_R: wearItem = items_dic[7].ContainsKey(name) ? items_dic[7][name] : null; break;
            case ITEM_TYPE.Weapon_L: wearItem = items_dic[8].ContainsKey(name) ? items_dic[8][name] : null; break;
        }

        if (wearItem == null)
        {
            wearItem = new WearItemInfo(name);
        }
        return wearItem;
    }


    JsonUtil jsonUtil;

    Dictionary<string, WearItemInfo>[] items_dic;

    private void OnEnable()
    {
        items_dic = new Dictionary<string, WearItemInfo>[parts_save_str.Length];
        for (int i = 0; i < parts_save_str.Length; i++)
            items_dic[i] = new Dictionary<string, WearItemInfo>();

        Load_JsonData();
    }



    string[] parts_save_str = { "Eyes", "Hair_Helmet", "Mustache", "Cloth", "Pants", "Armor", "Back", "Weapon_R", "Weapon_L" };

    private void Save()
    {

        Dictionary<string, WearItemInfo> wearItemInfo =  character.Get_WearItem_Info();

        for(int i = 0; i < parts_save_str.Length; i++)
        {
            if(wearItemInfo.ContainsKey(parts_save_str[i]))
            {
                Save(i, ref wearItemInfo);
            }
        }


    }

    private void Save(int index, ref Dictionary<string, WearItemInfo> wearItemInfo)
    {
        items_dic[index][wearItemInfo[parts_save_str[index]].texture_name] = wearItemInfo[parts_save_str[index]];
        List<WearItemInfo> item_list = new List<WearItemInfo>();

        foreach (var child in items_dic[index])
        {
            item_list.Add(child.Value);
        }

        string path = Path.Combine(Application.dataPath + "/ItemJson/", parts_save_str[index] + ".json");
        jsonUtil.Save_Data(path, item_list);
    }

    private void Load_JsonData()
    {
        //load
        jsonUtil = new JsonUtil();

        string path = Path.Combine(Application.dataPath + "/ItemJson/", "Eyes" + ".json");
        List<WearItemInfo> eyes_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Hair_Helmet" + ".json");
        List<WearItemInfo> hair_helmet_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Mustache" + ".json");
        List<WearItemInfo> mustache_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Cloth" + ".json");
        List<WearItemInfo> cloth_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Pants" + ".json");
        List<WearItemInfo> pants_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Armor" + ".json");
        List<WearItemInfo> armor_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Back" + ".json");
        List<WearItemInfo> back_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Weapon_R" + ".json");
        List<WearItemInfo> weapon_r_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);
        path = Path.Combine(Application.dataPath + "/ItemJson/", "Weapon_L" + ".json");
        List<WearItemInfo> weapon_l_list = jsonUtil.Load_Data<List<WearItemInfo>>(path);

        // "Eyes", "Hair_Helmet", "Mustache", "Cloth", "Pants", "Armor", "Back", "Weapon_L", "Weapon_R" };
        WearItemList_To_Dictionary(ref eyes_list, ref items_dic[0]);
        WearItemList_To_Dictionary(ref hair_helmet_list, ref items_dic[1]);
        WearItemList_To_Dictionary(ref mustache_list, ref items_dic[2]);
        WearItemList_To_Dictionary(ref cloth_list, ref items_dic[3]);
        WearItemList_To_Dictionary(ref pants_list, ref items_dic[4]);
        WearItemList_To_Dictionary(ref armor_list, ref items_dic[5]);
        WearItemList_To_Dictionary(ref back_list, ref items_dic[6]);
        WearItemList_To_Dictionary(ref weapon_r_list, ref items_dic[7]);
        WearItemList_To_Dictionary(ref weapon_l_list, ref items_dic[8]);


    }

    private void WearItemList_To_Dictionary(ref List<WearItemInfo> item_list, ref Dictionary<string, WearItemInfo> item_dic)
    {
        if(item_list != null)
        {
            foreach(var child in item_list)
            {
                item_dic.Add(child.texture_name, child);
            }
        }
    }

    Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture rt = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);
        Texture2D result = new Texture2D(targetX, targetY);
        result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        result.Apply();
        return result;
    }

}
