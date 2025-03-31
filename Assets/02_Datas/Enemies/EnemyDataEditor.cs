using Assets.PixelFantasy.PixelHeroes.Common.Scripts.CollectionScripts;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyData))]
public class EnemyDataEditor : Editor
{
    private SpriteCollection spriteCollection;
    private EnemyData enemyData;

    private int[] selectedIndex;
    private string[] selectedValue;

    public override void OnInspectorGUI()
    {
        if (spriteCollection == null)
        {
            spriteCollection = Resources.Load<SpriteCollection>(nameof(SpriteCollection));
            selectedIndex = new int[spriteCollection.Layers.Count + 1];
        }

        if (enemyData == null)
        {
            enemyData = (EnemyData)target;
        }

        EditorGUILayout.LabelField(nameof(SpriteCollection), EditorStyles.boldLabel);

        var layers = spriteCollection.Layers;
        for (int i = 0; i < layers.Count - 1; i++)
        {
            if (i == 12 || i == 13)
            {
                continue;
            }

            string[] textureNames = spriteCollection.Layers[i].Textures.Select(texture => texture.name).ToArray();
            selectedValue = new string[textureNames.Length + 1];

            selectedValue[0] = "Empty";
            Array.Copy(textureNames, 0, selectedValue, 1, textureNames.Length);

            selectedIndex[i] = EditorGUILayout.Popup(layers[i].Name, selectedIndex[i], selectedValue);
            SetValue(i, selectedIndex[i]);
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField(nameof(StatHandler), EditorStyles.boldLabel);
        DrawDefaultInspector();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(enemyData);
        }
    }

    private void SetValue(int layerIndex, int selectedIndex)
    {
        string selectedValue = this.selectedValue[selectedIndex];
        if (selectedValue == "Empty") selectedValue = string.Empty;

        switch (layerIndex)
        {
            case 0:
                enemyData.Cape = selectedValue;
                break;
            case 1:
                enemyData.Back = selectedValue;
                break;
            case 2:
                enemyData.Shield = selectedValue;
                break;
            case 3:
                enemyData.Body = selectedValue;
                break;
            case 4:
                enemyData.Armor = selectedValue;
                break;
            case 5:
                enemyData.Head = selectedValue;
                break;
            case 6:
                enemyData.Horns = selectedValue;
                break;
            case 7:
                enemyData.Eyes = selectedValue;
                break;
            case 8:
                enemyData.Mask = selectedValue;
                break;
            case 9:
                enemyData.Hair = selectedValue;
                break;
            case 10:
                enemyData.Ears = selectedValue;
                break;
            case 11:
                enemyData.Helmet = selectedValue;
                break;
            case 12:
                enemyData.Weapon = selectedValue;
                break;
        }
    }
}