using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteNP
{
    public string spr_name;
    public float x;
    public float y;

    public SpriteNP(string spr_name, float x, float y)
    {
        this.spr_name = spr_name;
        this.x = x;
        this.y = y;
    }
}