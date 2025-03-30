using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 동작 테스트용
// 다른 부분들과 연결은 고려 안하고 일단 만듬
public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> skillList = new List<GameObject>();
    private int skillListCount = 0;

    void Start()
    {
        skillListCount = skillList.Count;

        for(int i = 0; i < skillListCount; i++)
        {
            skillList[i].GetComponent<ISkillBehavior>().Init();
        }    
    }

    void Update()
    {
        // 테스트
        for(int i = 0; i < skillListCount; i++)
        {
            skillList[i].GetComponent<ISkillBehavior>().ExecuteSkill();
        }
    }
}
