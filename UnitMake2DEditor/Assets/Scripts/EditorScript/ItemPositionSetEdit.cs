using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ItemPositionSet))]
public class ItemPositionSetEdit : Editor
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUI.BeginChangeCheck();


        ItemPositionSet itemPositionSet = (ItemPositionSet)target;

        if (GUILayout.Button("Sprite Position Set"))
        {
            itemPositionSet.Set_Items_LocalPosition();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Item Reset"))
        {
            itemPositionSet.ItemReset();
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("ItemSO Field");


        for (int i = 0; i < itemPositionSet.itemSO_Array.Length; i++)
        {
            itemPositionSet.itemSO_Array[i] = (ItemSO)EditorGUILayout.ObjectField((ITEM_TYPE.Body + i).ToString(),
                itemPositionSet.itemSO_Array[i], typeof(ItemSO), true);
        }


        EditorGUILayout.Space();
        EditorGUILayout.LabelField("ItemPart Obj");

        for (int i = 0; i < itemPositionSet.itemPart.Length; i++)
        {
            itemPositionSet.itemPart[i] = (ItemPartPosition_P)EditorGUILayout.ObjectField(
                (ITEM_TYPE.Body + i).ToString(), itemPositionSet.itemPart[i], typeof(ItemPartPosition_P), true);
        }


  
        if (EditorGUI.EndChangeCheck())
        {
            itemPositionSet.Update_Items();
        }
    }
}
