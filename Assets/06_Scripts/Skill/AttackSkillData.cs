using UnityEngine;

public enum AttackCategory
{
    ProjectileFire,
    Rotate,
    Boomerang
}
[CreateAssetMenu(fileName = "new AttackSkillData", menuName = "Skill/SkillDatas/AttackSkillData")]
public class AttackSkillData : SkillData
{
    [SerializeField] protected AttackCategory attackType;
    public AttackCategory AttackType { get { return attackType; } }
    [SerializeField] protected float[] damage;
    public float[] Damage { get { return damage; } }
}
