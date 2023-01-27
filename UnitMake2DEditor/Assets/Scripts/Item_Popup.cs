using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Popup : MonoBehaviour
{

    public ScrollRect scrollRect;

    public void Update_ItemList(string part)
    {

        //기존 아이템들은 모두 제거하고 넣어야함
        for(int i = 0; i < scrollRect.content.childCount; i++)
        {
            scrollRect.content.GetChild(i).gameObject.SetActive(false);
        }
        

        //리소스매니저에서 오브젝 가져오자
        Item[] items = ResourceMgr.Instance.Get_Items(part);

        if(items == null)
        {
            Debug.Log("no item");
            return;
        }

        foreach (var child in items)
        {
            if (!child.gameObject.activeSelf)
                child.gameObject.SetActive(true);
            child.transform.SetParent(scrollRect.content.transform);
            child.transform.localScale = new Vector3(1, 1, 1);
        }
    }


}
