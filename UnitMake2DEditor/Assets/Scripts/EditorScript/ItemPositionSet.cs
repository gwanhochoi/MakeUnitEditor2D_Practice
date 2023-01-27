using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteInEditMode]
public class ItemPositionSet : MonoBehaviour
{

    [HideInInspector]
    public ItemSO[] itemSO_Array = new ItemSO[(int)ITEM_TYPE.End];

    [HideInInspector]
    public ItemPartPosition_P[] itemPart = new ItemPartPosition_P[(int)ITEM_TYPE.End];



    public void Update_Items()
    {
        for(int i = 0; i < itemPart.Length; i++)
        {
            if(itemPart[i] != null)
                itemPart[i].SetSprite(itemSO_Array[i]);
        }
    }

    public void Set_Sprite(ItemSO itemSO)
    {
        itemPart[(int)itemSO.item_type].SetSprite(itemSO);
    }

    public void Set_Items_LocalPosition()
    {
        for(int i = 0; i < itemPart.Length; i++)
        {
            if (itemPart[i] != null)
                itemPart[i].SaveItemSO();
        }

    }

    public void ItemReset()
    {
        for (int i = 0; i < itemPart.Length; i++)
        {
            if (itemPart[i] != null)
            {
                itemSO_Array[i] = null;
                itemPart[i].SetSprite(null);
            }
                
        }
    }
    
    
}

