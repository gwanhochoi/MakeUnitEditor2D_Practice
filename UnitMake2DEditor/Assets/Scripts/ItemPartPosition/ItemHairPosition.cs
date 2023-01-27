using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHairPosition : ItemPartPosition_P
{

    public SpriteRenderer Hair_SR;


    public override void SaveItemSO()
    {
        if (itemSO == null)
            return;
        Debug.Log("saved");
        itemSO.SNP_list[0].pos = Hair_SR.transform.localPosition;
    }

    public override void SetSprite(ItemSO itemSO)
    {
        this.itemSO = itemSO;

        if(itemSO == null)
        {
            Hair_SR.sprite = null;
            return;
        }

        Hair_SR.sprite = itemSO.SNP_list[0].sprite;
        Hair_SR.transform.localPosition = itemSO.SNP_list[0].pos;
    }
}
