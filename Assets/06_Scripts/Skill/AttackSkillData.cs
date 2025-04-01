using UnityEngine;

[CreateAssetMenu(fileName = "new AttackSkillData", menuName = "Skill/SkillDatas/AttackSkillData")]
public class AttackSkillData : SkillData
{
    [SerializeField] protected float[] damage;
    public float[] Damage { get { return damage; } }
}
