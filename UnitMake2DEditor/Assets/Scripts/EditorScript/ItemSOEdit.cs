using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ItemSO))]
public class ItemSOEdit : Editor
{
    ItemSO itemSO;
    private void OnEnable()
    {
        itemSO = (ItemSO)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUI.BeginChangeCheck();

        string field_name;
        Texture2D texture2D = itemSO.texture2d == null ? null : itemSO.texture2d;

        field_name = texture2D == null ? "none" : texture2D.name;


        itemSO.texture2d = (Texture2D)EditorGUILayout.ObjectField(field_name
            , itemSO.texture2d, typeof(Texture2D), true);


        if (EditorGUI.EndChangeCheck())
        {

            Undo.RecordObject(itemSO, "ItemSO Changed");
            if (texture2D != itemSO.texture2d)
            {
                string texturePath = AssetDatabase.GetAssetPath(itemSO.texture2d);
                Object[] objects = AssetDatabase.LoadAllAssetsAtPath(texturePath);
                
                itemSO.SetSprites(objects);
            }




        }
    }
}
