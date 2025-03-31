using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyData : ScriptableObject
{
    // Sprite Collection
    [HideInInspector] public string Head;
    [HideInInspector] public string Ears;
    [HideInInspector] public string Eyes;
    [HideInInspector] public string Body;
    [HideInInspector] public string Hair;
    [HideInInspector] public string Armor;
    [HideInInspector] public string Helmet;
    [HideInInspector] public string Weapon;
    [HideInInspector] public string Shield;
    [HideInInspector] public string Cape;
    [HideInInspector] public string Back;
    [HideInInspector] public string Mask;
    [HideInInspector] public string Horns;

    // Enemy Stats
    public float MaxHP = 100.0f;
    public float MoveSpeed = 1.0f;
    public float AttackDelay = 1.0f;
    public float AttackRange = 1.0f;
}