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

        // 스킬슬롯 생성 및 초기화 ( 3개 )
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
        // 로비씬에서 OnLevelUpEvent 에 이벤트 할당하면 Null Reference 오류
        // 메인씬 넘어갔을때 초기화될수있도록 
        // SceneLoader 를 통해 이벤트 할당

        GameManager.Instance.Player.StatHandler.OnLevelUpEvent += (level) => ShowUI();
    }

    public override void HideUI()
    {
        base.HideUI();

        Time.timeScale = 1;

        // 슬롯 초기화 및 비활성화
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

        // 랜덤 스킬 데이터 가져오기
        SkillData[] data = SkillManager.Instance.RandomSkillChoice();

        int nullCount = 0;
        for (int i = 0; i < data.Length; i++)
        {
            // 데이터 null 예외처리
            if (data[i] == null)
            {
                nullCount++;
                continue;
            }
            
            // 슬롯 데이터 세팅
            slots[i].SetData(data[i]);
        }

        // 데이터가 전부 null일 경우 예외처리
        if (nullCount >= skillCount)
            HideUI();
    }
}
