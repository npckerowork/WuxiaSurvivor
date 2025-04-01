using UnityEngine;

[CreateAssetMenu(fileName = "new AttackSkillData", menuName = "Skill/SkillDatas/AttackSkillData")]
public class AttackSkillData : SkillData
{
    [SerializeField] protected int[] damage;
    public int[] Damage { get { return damage; } }
}
