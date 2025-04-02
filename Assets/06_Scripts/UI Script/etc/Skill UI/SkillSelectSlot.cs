using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI skillNameText;
    [SerializeField] private TextMeshProUGUI skillDescriptionText;
    [SerializeField] private Image skillIcon;

    private SkillSelectUI skillSelectUI;
    private SkillData currentData;

    public void InitSlot(SkillSelectUI skillSelectUI)
    {
        this.skillSelectUI = skillSelectUI;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentData == null)
            return;

        SkillManager.Instance.AddSkill(currentData);
        skillSelectUI.HideUI();
    }

    public void SetData(SkillData data)
    {
        currentData = data;

        skillNameText.text = data.SkillName;
        skillDescriptionText.text = data.SkillDescription;
        skillIcon.sprite = data.SkillIcon;

        gameObject.SetActive(true);
    }

    public void ClearData()
    {
        currentData = null;
        gameObject.SetActive(false);
    }
}

