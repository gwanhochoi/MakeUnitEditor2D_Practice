using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeaponRPosition : ItemPartPosition_P
{
    public SpriteRenderer WeaponR_SR;

    public override void SaveItemSO()
    {
        if (itemSO == null)
            return;

        itemSO.SNP_list[0].pos = WeaponR_SR.transform.localPosition;
    }

    public override void SetSprite(ItemSO itemSO)
    {
        this.itemSO = itemSO;
        if (itemSO == null)
        {
            WeaponR_SR.sprite = null;
            return;
        }

        WeaponR_SR.sprite = itemSO.SNP_list[0].sprite;
        WeaponR_SR.transform.localPosition = itemSO.SNP_list[0].pos;
    }
}
