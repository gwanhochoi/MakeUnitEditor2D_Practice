using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterEditorWindow : EditorWindow
{
    

    [MenuItem("Window/MakeUnitEditor")]
    static void Open()
    {
        //GetWindow<CharacterEditorWindow>(typeof(SceneView));
        GetWindow<CharacterEditorWindow>();
    }

    Character_Script character;
    
    string[] parts_str = { "Body", "Eyes", "Hair", "Mustache", "Helmet", "Cloth", "Pants", "Armor", "Back", "Weapon_R", "Weapon_L" };

    int selected_parts = -1;
    int prev_selected_parts = -1;

    Vector2 scrollPosition;
    int selected_item = -1;
    int prev_selected_item = -1;

    Texture2D []textures;
    Texture2D[] resizingTextures;
    string parts_name = "";

    private void OnGUI()
    {

        EditorGUI.BeginChangeCheck();

        character = (Character_Script)EditorGUILayout.ObjectField("human obj", character, typeof(Character_Script), true);

        if(GUILayout.Button("open"))
        {
            //human prefab 열리면 각 부위별 스프라이트 로드

            if (!AssetDatabase.OpenAsset(character))
                return;
            
        }
        

        selected_parts = GUILayout.SelectionGrid(selected_parts, parts_str, 6);
        
        if (selected_parts != prev_selected_parts)
        {
            prev_selected_parts = selected_parts;
            parts_name = parts_str[selected_parts];
            if (parts_name == "Weapon_R" || parts_name == "Weapon_L")
                parts_name = "Weapon";
            textures = Resources.LoadAll<Texture2D>("Sprites/" + parts_name);
            resizingTextures = new Texture2D[textures.Length];

            for (int i = 0; i < textures.Length; i++)
            {
                resizingTextures[i] = Resize(textures[i], textures[i].width * 2, textures[i].height * 2);
            }
            selected_item = -1;
            prev_selected_item = -1;

        }

        
        if(resizingTextures != null)
        {
            using (EditorGUILayout.ScrollViewScope scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scrollView.scrollPosition;
                selected_item = GUILayout.SelectionGrid(selected_item, resizingTextures, 4, 
                    GUILayout.Width(position.width - 20),
                        GUILayout.Height((position.width - 20) / 4 * Mathf.CeilToInt((float)resizingTextures.Length / 4)));
                

            }
        }

        if(EditorGUI.EndChangeCheck())
        {
            if(selected_item > -1 && selected_item != prev_selected_item)
            {
                //Debug.Log("texture name = "+textures[selected_item].name);
                prev_selected_item = selected_item;
                if(character != null)
                    character.Change_parts(ITEM_TYPE.Body + selected_parts, parts_name,textures[selected_item].name);
                    //character.Change_parts(textures[selected_item]);
            }
        }

    }

    Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture rt = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);
        Texture2D result = new Texture2D(targetX, targetY);
        result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        result.Apply();
        return result;
    }
}
