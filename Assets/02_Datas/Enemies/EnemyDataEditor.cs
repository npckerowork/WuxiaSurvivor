using Assets.PixelFantasy.PixelHeroes.Common.Scripts.CollectionScripts;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyData))]
public class EnemyDataEditor : Editor
{
    private EnemyData enemyData;

    private int index;
    private string[] selectedValue;

    public override void OnInspectorGUI()
    {
        enemyData = (EnemyData)target;

        SpriteCollection spriteCollection = Resources.Load<SpriteCollection>(nameof(SpriteCollection));
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

            selectedValue[0] = nameof(string.Empty);
            Array.Copy(textureNames, 0, selectedValue, 1, textureNames.Length);

            GetIndex(i) = EditorGUILayout.Popup(layers[i].Name, GetIndex(i), selectedValue);
            SetValue(i, GetIndex(i));
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField(nameof(StatHandler), EditorStyles.boldLabel);
        DrawDefaultInspector();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(enemyData);
        }
    }

    private ref int GetIndex(int layerIndex)
    {
        switch (layerIndex)
        {
            case 0:
                return ref enemyData.CapeIndex;
            case 1:
                return ref enemyData.BackIndex;
            case 2:
                return ref enemyData.ShieldIndex;
            case 3:
                return ref enemyData.BodyIndex;
            case 4:
                return ref enemyData.ArmorIndex;
            case 5:
                return ref enemyData.HeadIndex;
            case 6:
                return ref enemyData.HornsIndex;
            case 7:
                return ref enemyData.EyesIndex;
            case 8:
                return ref enemyData.MaskIndex;
            case 9:
                return ref enemyData.HairIndex;
            case 10:
                return ref enemyData.EarsIndex;
            case 11:
                return ref enemyData.HelmetIndex;
            case 14:
                return ref enemyData.WeaponIndex;
            default:
                return ref index;
        }
    }

    private void SetValue(int layerIndex, int selectedIndex)
    {
        string selectedValue = this.selectedValue[selectedIndex];
        if (selectedValue == nameof(string.Empty)) selectedValue = string.Empty;

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
            case 14:
                enemyData.Weapon = selectedValue;
                break;
        }
    }
}