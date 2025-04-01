using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyData : EntityData
{
    public float AttackDamage = 5.0f;
    public float AttackDelay = 1.0f;
    public float AttackRange = 1.0f;
}