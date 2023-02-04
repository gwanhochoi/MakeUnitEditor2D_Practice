using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image image;
    public WearItemInfo itemInfo { get; set; }
    public ITEM_TYPE item_type { get; set; }

    public void Init(Texture2D texture, WearItemInfo itemInfo, ITEM_TYPE item_type)
    {
        //sprite 원본 사이즈 비율 맞춰서 이미지 해상도 정할것
        //스케일 2배 적용 해뒀고 128크기는 안넘는게 좋을듯
        //this.itemSO = itemSO;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));

        image.rectTransform.sizeDelta = new Vector2(sprite.rect.width * 2, sprite.rect.height * 2);
        image.sprite = sprite;
        if (itemInfo == null)
        {
            itemInfo = new WearItemInfo(sprite.name);
        }
        
        this.itemInfo = itemInfo;
        
        this.item_type = item_type;
    }

    public void Selected_Item()
    {
        EditorMgr.Instance.Change_Unit_Items(itemInfo, item_type);
    }
}
