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
    // 스킬 아이콘
    [SerializeField] private Sprite skillIcon;
    public Sprite SkillIcon {  get { return skillIcon; } }
    // 스킬 프리팹
    [SerializeField] protected GameObject skillPrefab;
    public GameObject SkillPrefab { get { return skillPrefab; } }
    // 스킬 이름
    [SerializeField] protected string skillName;
    public string SkillName { get { return skillName; } }
    // 스킬 설명
    [SerializeField] protected string skillDescription;
    public string SkillDescription { get {  return skillDescription; } }
    // 스킬 종류
    [SerializeField] protected SkillCategory category;
    public SkillCategory Category { get { return category; } }
    [SerializeField] private int maxLevel;
    public int MaxLevel { get { return maxLevel; } }
    protected int skillLevel = 1;
    public int SkillLevel
    {
        get {  return skillLevel; }
        set { skillLevel = value; }
    }
}
