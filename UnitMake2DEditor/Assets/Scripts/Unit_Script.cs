using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Script : MonoBehaviour
{
    //캐릭터 각 부위 Skin : body, head, leg, arm
    //각 부위별 아이템도!

    //아이템과 Skin 교체 작업

    public SpriteRenderer m_HairSpriteRenderer;

    public void Change_Items(ItemSO itemSO)
    {

        //Body랑 Eye는 다른 파트랑 다름
        switch(itemSO.item_type)
        {
            case ITEM_TYPE.Body: break;
            case ITEM_TYPE.Eyes: break;
            case ITEM_TYPE.Hair:
                m_HairSpriteRenderer.sprite = (Sprite)itemSO.SNP_list[0].sprite;
                //m_HairSpriteRenderer.transform.localPosition = itemSO.localPosition;
                break;
            case ITEM_TYPE.Mustache: break;
            case ITEM_TYPE.Helmet: break;
            case ITEM_TYPE.Cloth: break;
            case ITEM_TYPE.Pants: break;
            case ITEM_TYPE.Armor: break;
            case ITEM_TYPE.Back: break;
            case ITEM_TYPE.Weapon_R: break;
            case ITEM_TYPE.Weapon_L: break;

        }
    }

    

}
