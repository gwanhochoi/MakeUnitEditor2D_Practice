using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHelmetPosition : ItemPartPosition_P
{
    public SpriteRenderer Helmet_SR;

    public override void SaveItemSO()
    {
        if (itemSO == null)
            return;

        itemSO.SNP_list[0].pos = Helmet_SR.transform.localPosition;
    }

    public override void SetSprite(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        if (itemSO == null)
        {
            Helmet_SR.sprite = null;
            return;
        }

        Helmet_SR.sprite = itemSO.SNP_list[0].sprite;
        Helmet_SR.transform.localPosition = itemSO.SNP_list[0].pos;
    }
}
