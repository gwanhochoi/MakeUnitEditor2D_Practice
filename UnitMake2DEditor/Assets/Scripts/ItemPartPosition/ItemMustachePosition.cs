using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMustachePosition : ItemPartPosition_P
{
    public SpriteRenderer Mustache_SR;

    public override void SaveItemSO()
    {
        if (itemSO == null)
            return;

        itemSO.SNP_list[0].pos = Mustache_SR.transform.localPosition;
    }

    public override void SetSprite(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        if(itemSO == null)
        {
            Mustache_SR.sprite = null;
            return;
        }

        Mustache_SR.sprite = itemSO.SNP_list[0].sprite;
        Mustache_SR.transform.localPosition = itemSO.SNP_list[0].pos;
    }
}
