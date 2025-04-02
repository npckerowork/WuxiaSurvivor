using UnityEngine;

public abstract class EntityData : ScriptableObject
{
    #region SpriteCollection
    [HideInInspector] public int HeadIndex;
    [HideInInspector] public string Head;

    [HideInInspector] public int EarsIndex;
    [HideInInspector] public string Ears;

    [HideInInspector] public int EyesIndex;
    [HideInInspector] public string Eyes;

    [HideInInspector] public int BodyIndex;
    [HideInInspector] public string Body;

    [HideInInspector] public int HairIndex;
    [HideInInspector] public string Hair;

    [HideInInspector] public int ArmorIndex;
    [HideInInspector] public string Armor;

    [HideInInspector] public int HelmetIndex;
    [HideInInspector] public string Helmet;

    [HideInInspector] public int WeaponIndex;
    [HideInInspector] public string Weapon;

    [HideInInspector] public int ShieldIndex;
    [HideInInspector] public string Shield;

    [HideInInspector] public int CapeIndex;
    [HideInInspector] public string Cape;

    [HideInInspector] public int BackIndex;
    [HideInInspector] public string Back;

    [HideInInspector] public int MaskIndex;
    [HideInInspector] public string Mask;

    [HideInInspector] public int HornsIndex;
    [HideInInspector] public string Horns;
    #endregion

    public float MaxHP = 100.0f;
    public float MoveSpeed = 1.0f;
}