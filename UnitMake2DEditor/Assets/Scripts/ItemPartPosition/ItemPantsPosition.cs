using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPantsPosition : ItemPartPosition_P
{
    public SpriteRenderer Left_SR;
    public SpriteRenderer Right_SR;

    public override void SaveItemSO()
    {

        if (itemSO == null)
            return;
        foreach (var child in itemSO.SNP_list)
        {
            if (child.name == "Left")
                child.pos = Left_SR.transform.localPosition;
            else if (child.name == "Right")
                child.pos = Right_SR.transform.localPosition;
        }
    }

    public override void SetSprite(ItemSO itemSO)
    {
        this.itemSO = itemSO;

        if (itemSO == null)
        {
            Left_SR.sprite = null;
            Right_SR.sprite = null;
            return;
        }
        foreach (var child in itemSO.SNP_list)
        {
            if (child.name == "Left")
            {
                Left_SR.sprite = child.sprite;
                Left_SR.transform.localPosition = child.pos;
            }
            else if (child.name == "Right")
            {
                Right_SR.sprite = child.sprite;
                Right_SR.transform.localPosition = child.pos;
            }
        }
    }
}
