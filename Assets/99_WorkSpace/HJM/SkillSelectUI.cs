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
        slots = new List<SkillSelectSlot>();

        // 스킬슬롯 미리 생성해두기
        for (int i = 0; i < skillCount; i++)
        {
            GameObject slotObject = Instantiate(slotPrefab, slotParent);
            SkillSelectSlot slot = slotObject.GetComponent<SkillSelectSlot>();
            slot.InitSlot(this);
            slots.Add(slot);

            slotObject.SetActive(false);
        }

        SceneLoader.Instance.AddAction(SceneType.Main, LevelUpEvent);
    }

    private void LevelUpEvent()
    {
        GameManager.Instance.Player.StatHandler.OnLevelUpEvent += (level) => ShowUI();
    }

    public override void HideUI()
    {
        base.HideUI();

        Time.timeScale = 1;

        foreach(SkillSelectSlot slot in slots)
        {
            slot?.ClearData();
        }
    }

    // 레벨업했을때 호출해주기
    public override void ShowUI()
    {
        base.ShowUI();

        Time.timeScale = 0;

        //// 가져올 데이터가없으면 UI 다시 끄기
        //if (!GetRandomSkillData(out List<SkillData> data))
        //    HideUI();

        //for(int i = 0; i < data.Count; i++)
        //{
        //    slots[i].SetData(data[i]);
        //}
    }
}
