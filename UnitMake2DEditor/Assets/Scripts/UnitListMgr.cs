using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UnitListMgr : MonoBehaviour
{
    public GameObject PreviewCharacter_Btn;
    public ScrollRect scrollRect;

    private JsonUtil jsonUtil;
    private Dictionary<string, GameObject> PreviewCharacter_dic;

    private void Awake()
    {
        jsonUtil = new JsonUtil();
        PreviewCharacter_dic = new Dictionary<string, GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {

        Update_List();
        
    }

    private void Create_PreviewCharacterButton(string name, List<WearSkinInfo> skin_list)
    {
        if (PreviewCharacter_dic.ContainsKey(name))
            return;

        GameObject obj = Instantiate(PreviewCharacter_Btn);
        obj.transform.SetParent(scrollRect.content.transform);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.GetComponentInChildren<Character_Script>().Wear_Skin(name, skin_list);
        PreviewCharacter_dic.Add(name, obj);
    }

    public void Update_List()
    {
        string filepath = Path.Combine(Application.dataPath + "/UnitSkinJson");
        DirectoryInfo directoryInfo = new DirectoryInfo(filepath);

        foreach (var child in directoryInfo.GetFiles("*.json"))
        {
            //Debug.Log(child.FullName);
            List<WearSkinInfo> skin_list = jsonUtil.Load_Data<List<WearSkinInfo>>(child.FullName);
            Debug.Log(child.Name);
            Create_PreviewCharacterButton(child.Name, skin_list);

        }
    }

    public void Update_Item(string name)
    {
        string filepath = Path.Combine(Application.dataPath + "/UnitSkinJson/" + name);
        
        List<WearSkinInfo> skin_list = jsonUtil.Load_Data<List<WearSkinInfo>>(filepath);
        if(PreviewCharacter_dic.ContainsKey(name))
        {
            PreviewCharacter_dic[name].GetComponentInChildren<Character_Script>().Wear_Skin(name, skin_list);
        }
    }

    public void Delete(string unit_name)
    {
        if(PreviewCharacter_dic.ContainsKey(unit_name))
        {
            GameObject obj = PreviewCharacter_dic[unit_name];
            PreviewCharacter_dic.Remove(unit_name);
            DestroyImmediate(obj);
        }
    }
}
