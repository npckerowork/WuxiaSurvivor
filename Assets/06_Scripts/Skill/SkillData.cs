using System.Collections.Generic;
using UnityEngine;

public enum SkillCategory
{
    Attack,
    Defense,
    Support
}

[CreateAssetMenu(fileName = "new AttackSkillData", menuName = "Skill/SkillDatas/AttackSkillData")]
public class AttackSkillData : SkillData
{
    [SerializeField] protected int[] damage;
    public int[] Damage { get { return damage; } }
}

public class SkillData : ScriptableObject
{
    [SerializeField] protected string skillName;
    public string SkillName { get { return skillName; } }
    [SerializeField] protected SkillCategory category;
    public SkillCategory Category { get { return category; } }
}
