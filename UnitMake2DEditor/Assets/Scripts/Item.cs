using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image image;
    private ItemSO itemSO;

    public void Init(ItemSO itemSO)
    {
        //sprite 원본 사이즈 비율 맞춰서 이미지 해상도 정할것
        //스케일 2배 적용 해뒀고 128크기는 안넘는게 좋을듯
        this.itemSO = itemSO;
        Sprite sprite = Sprite.Create(itemSO.texture2d, new Rect(0, 0, itemSO.texture2d.width, itemSO.texture2d.height),
            new Vector2(0.5f, 0.5f));
        image.rectTransform.sizeDelta = new Vector2(sprite.rect.width * 2, sprite.rect.height * 2);
        image.sprite = sprite;
    }

    public void Selected_Item()
    {
        EditorMgr.Instance.Change_Unit_Items(itemSO);
    }
}
