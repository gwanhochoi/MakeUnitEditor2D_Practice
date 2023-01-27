using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteNamePos
{
    public Sprite sprite;
    public string name;
    public Vector2 pos;
    

    public SpriteNamePos(Sprite sprite, string name, Vector2 pos)
    {
        this.sprite = sprite;
        this.name = name;
        this.pos = pos;
    }
}
