using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPartPosition_P : MonoBehaviour
{
    protected ItemSO itemSO;
    abstract public void SetSprite(ItemSO itemSO);
    abstract public void SaveItemSO();

}
