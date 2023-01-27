using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Script : MonoBehaviour
{
    public SpriteRenderer Head_SR;
    public SpriteRenderer Body_SR;
    public SpriteRenderer Arm_R_SR;
    public SpriteRenderer Arm_L_SR;
    public SpriteRenderer Leg_R_SR;
    public SpriteRenderer Leg_L_SR;

    public SpriteRenderer Eye_R_SR;
    public SpriteRenderer Eye_L_SR;

    public SpriteRenderer Hair_Helmet_SR;
    public SpriteRenderer Mustache_SR;
    public SpriteRenderer Cloth_Body_SR;
    public SpriteRenderer Cloth_R_SR;
    public SpriteRenderer Cloth_L_SR;
    public SpriteRenderer Pants_R_SR;
    public SpriteRenderer Pants_L_SR;
    public SpriteRenderer Armor_Body_SR;
    public SpriteRenderer Armor_R_SR;
    public SpriteRenderer Armor_L_SR;
    public SpriteRenderer Back_SR;
    public SpriteRenderer Weapon_R_SR;
    public SpriteRenderer Weapon_L_SR;
   

    public void Change_parts(ITEM_TYPE item_type, string parts_name, string item_name)
    {
        //Hair_Helmet_SR.sprite = Resources.Load<Sprite>("Sprites/" + parts_name +"/" + item_name);
        Object[] objects = Resources.LoadAll<Object>("Sprites/" + parts_name + "/" + item_name);
        
        switch(item_type)
        {
            case ITEM_TYPE.Body: Change_Body_Sprite(objects); break;
            case ITEM_TYPE.Eyes: Change_Eyes_Sprite(objects); break;
            case ITEM_TYPE.Hair: case ITEM_TYPE.Helmet: Change_Hair_Helmet_Sprite(objects); break;
            case ITEM_TYPE.Mustache: Change_Mustache_Sprite(objects); break;
            case ITEM_TYPE.Cloth: Change_Cloth_Sprite(objects); break;
            case ITEM_TYPE.Pants: Change_Pants_Sprite(objects); break;
            case ITEM_TYPE.Armor: Change_Armor_Sprite(objects); break;
            case ITEM_TYPE.Back: Change_Back_Sprite(objects); break;
            case ITEM_TYPE.Weapon_R: Change_Weapon_R_Sprite(objects); break;
            case ITEM_TYPE.Weapon_L: Change_Weapon_L_Sprite(objects); break;
        }

    }

    private void Change_Body_Sprite(Object[] objects)
    {
        Debug.Log("Body Change Called.");
        foreach(var child in objects)
        {
            if(child is Sprite)
            {
                switch(child.name)
                {
                    case "Head": Head_SR.sprite = (Sprite)child; break;
                    case "Body": Body_SR.sprite = (Sprite)child; break;
                    case "Arm_R": Arm_R_SR.sprite = (Sprite)child; break;
                    case "Arm_L": Arm_L_SR.sprite = (Sprite)child; break;
                    case "Leg_R": Leg_R_SR.sprite = (Sprite)child; break;
                    case "Leg_L": Leg_L_SR.sprite = (Sprite)child; break;
                }
            }
        }
    }

    private void Change_Eyes_Sprite(Object[] objects)
    {

    }

    private void Change_Hair_Helmet_Sprite(Object[] objects)
    {

    }

    private void Change_Mustache_Sprite(Object[] objects)
    {

    }

    private void Change_Cloth_Sprite(Object[] objects)
    {

    }

    private void Change_Pants_Sprite(Object[] objects)
    {

    }

    private void Change_Armor_Sprite(Object[] objects)
    {

    }

    private void Change_Back_Sprite(Object[] objects)
    {

    }

    private void Change_Weapon_R_Sprite(Object[] objects)
    {

    }

    private void Change_Weapon_L_Sprite(Object[] objects)
    {

    }
}
