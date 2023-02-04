using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WearItemInfo
{
    public string texture_name;
    public List<SpriteNP> list;

    public WearItemInfo(string name)
    {
        this.texture_name = name;
        list = new List<SpriteNP>();
    }

    public void Add_SpriteNP(SpriteNP spriteNP)
    {
        list.Add(spriteNP);
    }
}
