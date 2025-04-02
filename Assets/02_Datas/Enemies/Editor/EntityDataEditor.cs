using Assets.PixelFantasy.PixelHeroes.Common.Scripts.CollectionScripts;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntityData), true)]
public class EntityDataEditor : Editor
{
    private EntityData entityData;

    private int index;
    private string[] selectedValue;

    public override void OnInspectorGUI()
    {
        entityData = (EntityData)target;

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
            EditorUtility.SetDirty(entityData);
        }
    }

    private ref int GetIndex(int layerIndex)
    {
        switch (layerIndex)
        {
            case 0:
                return ref entityData.CapeIndex;
            case 1:
                return ref entityData.BackIndex;
            case 2:
                return ref entityData.ShieldIndex;
            case 3:
                return ref entityData.BodyIndex;
            case 4:
                return ref entityData.ArmorIndex;
            case 5:
                return ref entityData.HeadIndex;
            case 6:
                return ref entityData.HornsIndex;
            case 7:
                return ref entityData.EyesIndex;
            case 8:
                return ref entityData.MaskIndex;
            case 9:
                return ref entityData.HairIndex;
            case 10:
                return ref entityData.EarsIndex;
            case 11:
                return ref entityData.HelmetIndex;
            case 14:
                return ref entityData.WeaponIndex;
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
                entityData.Cape = selectedValue;
                break;
            case 1:
                entityData.Back = selectedValue;
                break;
            case 2:
                entityData.Shield = selectedValue;
                break;
            case 3:
                entityData.Body = selectedValue;
                break;
            case 4:
                entityData.Armor = selectedValue;
                break;
            case 5:
                entityData.Head = selectedValue;
                break;
            case 6:
                entityData.Horns = selectedValue;
                break;
            case 7:
                entityData.Eyes = selectedValue;
                break;
            case 8:
                entityData.Mask = selectedValue;
                break;
            case 9:
                entityData.Hair = selectedValue;
                break;
            case 10:
                entityData.Ears = selectedValue;
                break;
            case 11:
                entityData.Helmet = selectedValue;
                break;
            case 14:
                entityData.Weapon = selectedValue;
                break;
        }
    }
}