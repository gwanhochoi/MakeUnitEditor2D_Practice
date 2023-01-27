using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBackPosition : ItemPartPosition_P
{
    public SpriteRenderer Pants_SR;

    public override void SaveItemSO()
    {
        if (itemSO == null)
            return;

        itemSO.SNP_list[0].pos = Pants_SR.transform.localPosition;
    }

    public override void SetSprite(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        if (itemSO == null)
        {
            Pants_SR.sprite = null;
            return;
        }

        Pants_SR.sprite = itemSO.SNP_list[0].sprite;
        Pants_SR.transform.localPosition = itemSO.SNP_list[0].pos;
    }
}
