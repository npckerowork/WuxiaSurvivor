using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private GameManager gameManager;
    // 스킬 데이터 리스트
    [SerializeField] private List<SkillData> totalSkillDataList = new List<SkillData>();

    private int totalSkillCount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Init()
    {
        gameManager = GameManager.Instance;
        totalSkillCount = totalSkillDataList.Count;
        AddSkill(totalSkillDataList[0]);
    }

    public void AddSkill(SkillData data)
    {
        
    }
}
