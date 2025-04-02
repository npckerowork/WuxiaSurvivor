using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    private GameManager gameManager;
    // 스킬 데이터 리스트
    [SerializeField] private List<SkillData> totalSkillDataList = new List<SkillData>();
    public List<SkillData> TotalSkillDataList { get { return totalSkillDataList; } }

    private int totalSkillCount;
    public int TotalSKillCount {  get { return totalSkillCount; } }

    protected override void Initialize()
    {
        gameManager = GameManager.Instance;
        totalSkillCount = totalSkillDataList.Count;

        for(int i = 0; i < totalSkillCount; i++)
        {
            totalSkillDataList[i].SkillLevel = 1;
        }
    }

    private void Start()
    {
        AddSkill(totalSkillDataList[0]);
    }

    public void AddSkill(SkillData data)
    {
        if (data.SkillLevel == data.MaxLevel) return;

        PlayerController controller = gameManager.Player;
        string key = data.SkillName;

        if(controller.Skills.ContainsKey(key))
        {
            controller.Skills[key].SkillLevelUp();
        }
        else
        {
            GameObject obj = Instantiate(data.SkillPrefab);
            obj.SetActive(true);
            obj.transform.parent = gameManager.Player.SkillHandler.SkillPos;
            obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<ISkillBehavior>().Init();
            controller.Skills.Add(key, obj.GetComponent<ISkillBehavior>());
        }
    }

    /// <summary>
    /// 최대 레벨이 아닌
    /// 랜덤한 스킬 3개의 skillData를
    /// 반환하는 함수
    /// </summary>
    /// <returns></returns>
    public SkillData[] RandomSkillChoice()
    {
        SkillData[] randomSkills = new SkillData[3];

        for(int i = 0; i < 3; i++)
        {
            bool select = false;
            int repeatCount = 0;

            while(!select)
            {
                int idx = Random.Range(0, totalSkillCount);
                repeatCount++;

                if (totalSkillDataList[idx].SkillLevel != totalSkillDataList[idx].MaxLevel)
                {
                    randomSkills[i] = totalSkillDataList[idx];
                    select = true;
                }
                else if(repeatCount >= 100)
                {
                    randomSkills[i] = null;
                    select = true;
                }
            }
        }

        return randomSkills;
    }
}