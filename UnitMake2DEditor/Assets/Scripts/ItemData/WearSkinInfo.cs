using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WearSkinInfo
{
    public string part;
    public string name;
    public string color;

    public WearSkinInfo(string part, string name, string color)
    {
        this.part = part;
        this.name = name;
        this.color = color;
    }
}
