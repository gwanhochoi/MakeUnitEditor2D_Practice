using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeaponLPosition : ItemPartPosition_P
{
    public SpriteRenderer WeaponL_SR;

    public override void SaveItemSO()
    {
        if (itemSO == null)
            return;

        itemSO.SNP_list[0].pos = WeaponL_SR.transform.localPosition;
    }

    public override void SetSprite(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        if (itemSO == null)
        {
            WeaponL_SR.sprite = null;
            return;
        }

        WeaponL_SR.sprite = itemSO.SNP_list[0].sprite;
        WeaponL_SR.transform.localPosition = itemSO.SNP_list[0].pos;
    }
}
