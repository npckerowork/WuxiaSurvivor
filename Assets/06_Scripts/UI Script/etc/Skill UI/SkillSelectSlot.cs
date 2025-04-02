using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI skillNameText;         // 스킬 이름 
    [SerializeField] private TextMeshProUGUI skillDescriptionText;  // 스킬 설명
    [SerializeField] private Image skillIcon;                       // 스킬 아이콘

    private SkillSelectUI skillSelectUI;    // 스킬 선택 UI
    private SkillData currentData;          // 슬롯에 선택된 스킬데이터

    public void InitSlot(SkillSelectUI skillSelectUI)
    {
        this.skillSelectUI = skillSelectUI;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 예외처리
        if (currentData == null)
            return;

        // 클릭시 SkillManager의 AddSkill을 통해
        // 현재 할당된 스킬 데이터의 스킬을 추가
        SkillManager.Instance.AddSkill(currentData);

        // 스킬 선택 UI 종료
        skillSelectUI.HideUI();
    }

    public void SetData(SkillData data)
    {
        // 현재 슬롯의 스킬데이터 할당
        currentData = data;

        // 데이터 UI
        skillNameText.text = data.SkillName;
        skillDescriptionText.text = data.SkillDescription;
        skillIcon.sprite = data.SkillIcon;

        // 슬롯 활성화
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 슬롯 초기화
    /// </summary>
    public void ClearData()
    {
        currentData = null;
        gameObject.SetActive(false);
    }
}

