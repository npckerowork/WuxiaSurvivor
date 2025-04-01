using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI skillText;
    [SerializeField] private Image skillIcon;

    private SkillData currentData;

    public void InitSlot(SkillData data)
    {
        currentData = data;

        skillText.text = data.SkillName;
        //skillIcon.sprite = ; 스킬 데이터 이미지가없음!
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentData == null)
            return;

        SkillManager.Instance.AddSkill(currentData);
    }
}

