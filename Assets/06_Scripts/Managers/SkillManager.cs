using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    private GameManager gameManager;
    // 스킬 데이터 리스트
    [SerializeField] private List<SkillData> totalSkillDataList = new List<SkillData>();

    private int totalSkillCount;
    public int TotalSKillCount {  get { return totalSkillCount; } }
    public List<SkillData> TotalSkillDataList { get { return totalSkillDataList; } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddSkill(SkillData data)
    {
        
    }

    protected override void Initialize()
    {
        gameManager = GameManager.Instance;
        totalSkillCount = totalSkillDataList.Count;
        AddSkill(totalSkillDataList[0]);
    }
}
