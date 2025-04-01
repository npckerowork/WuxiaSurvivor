using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSelectUI : BaseUI
{
    private const int skillCount = 3;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<SkillSelectSlot> slots;
    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        // 스킬슬롯 미리 생성해두기
        for (int i = 0; i < skillCount; i++)
        {
            GameObject slotObject = Instantiate(slotPrefab, slotParent);
            SkillSelectSlot slot = slotObject.GetComponent<SkillSelectSlot>();
            slots.Add(slot);

            slotObject.SetActive(false);
        }
    }

    public override void HideUI()
    {
        base.HideUI();

        Time.timeScale = 1;
    }

    // 레벨업했을때 호출해주기
    public override void ShowUI()
    {
        base.ShowUI();

        Time.timeScale = 0;

        // 가져올 데이터가없으면 UI 다시 끄기
        if (!GetRandomSkillData(out SkillData[] data))
            HideUI();

        for(int i = 0; i < data.Length; i++)
        {
            slots[i].InitSlot(data[i]);
        }
    }

    public bool GetRandomSkillData(out SkillData[] resultData)
    {
        resultData = new SkillData[skillCount];
        List<SkillData> datas = SkillManager.Instance.TotalSkillDataList;
        int[] randomIndex = GetRandomIndexes(datas.Count, skillCount);

        if (randomIndex.Length > 0)
            return false;

        for(int i = 0; i < randomIndex.Length; i++)
        {
            resultData[i] = datas[randomIndex[i]];
        }

        return true;
    }


    // 고마워 따봉GPT야!
    public int[] GetRandomIndexes(int maxNumber, int pickCount)
    {
        pickCount = Mathf.Min(maxNumber, pickCount);

        HashSet<int> randomIndexes = new HashSet<int>();
        while (randomIndexes.Count < pickCount)
        {
            randomIndexes.Add(Random.Range(0, maxNumber));
        }
        return randomIndexes.ToArray();
    }
}
