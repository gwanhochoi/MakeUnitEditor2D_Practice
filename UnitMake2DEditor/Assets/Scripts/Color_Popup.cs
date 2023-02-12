using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Popup : MonoBehaviour
{
    public ITEM_TYPE item_type;
    

    public void Color_Touch()
    {
        StartCoroutine(Get_Color());
    }

    IEnumerator Get_Color()
    {
        yield return new WaitForEndOfFrame();
        Vector3 pos = Input.mousePosition;
        Texture2D texture2D = new Texture2D(1, 1);
        texture2D.ReadPixels(new Rect(pos.x, pos.y, 1, 1), 0, 0);
        texture2D.Apply();

        Color color = texture2D.GetPixel(0, 0);
        

        yield return new WaitForSecondsRealtime(0.1f);

        //color를 아이템에 적용하자
        EditorMgr.Instance.Change_Item_Color(color, item_type);
    }
}

