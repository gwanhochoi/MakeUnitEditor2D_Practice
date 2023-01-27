using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ITEM_TYPE item_type;

    [HideInInspector]
    public Texture2D texture2d;

    public List<SpriteNamePos> SNP_list;

    public void SetSprites(Object[] objects)
    {

        if (SNP_list != null)
        {
            SNP_list.Clear();
        }
            
        else
            SNP_list = new List<SpriteNamePos>();

        foreach(var child in objects)
        {
            if(child is Sprite)
            {
                SNP_list.Add(new SpriteNamePos((Sprite)child, child.name, new Vector2(0, 0)));
            }
                
        }

    } 
    
}
