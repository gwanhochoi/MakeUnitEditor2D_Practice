using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemBundleSO", menuName = "ItemSO/ItemBundleSo")]
public class ItemBundleSO : ScriptableObject
{
    [SerializeField]
    private List<ItemSO> m_ItemList;
    public List<ItemSO> ItemList
    {
        get { return m_ItemList; }

        set { m_ItemList = value; }
    }


}
