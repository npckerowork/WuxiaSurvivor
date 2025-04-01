using UnityEditor.Experimental.Rendering;
using UnityEngine;

public enum SkillCategory
{
    Attack,
    Defense,
    Support
}

public class SkillData : ScriptableObject
{
    [SerializeField] protected string skillName;
    public string SkillName { get { return skillName; } }
    [SerializeField] protected SkillCategory category;
    public SkillCategory Category { get { return category; } }
}
