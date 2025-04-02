using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : BaseUI
{
    [Header("Slot")]
    [SerializeField] private GameObject upgradeSlotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("Button")]
    [SerializeField] private Button backButton;

    private List<UpgradeSlot> slots;
    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        backButton.onClick.AddListener(HideUI);

        // 업그레이드 슬롯 세팅
        slots = new List<UpgradeSlot>();
        UpgradeData upgradeData = DataManager.Instance.UpgradeData;
        foreach (UpgradeScriptable data in upgradeData.upgradeDatas)
        {
            UpgradeSlot slot = Instantiate(upgradeSlotPrefab, slotParent).GetComponent<UpgradeSlot>();

            slot.InitSlot(upgradeData, data.type);
            slots.Add(slot);
        }
    }

    public override void ShowUI()
    {
        base.ShowUI();
        foreach(UpgradeSlot slot in slots)
        {
            slot?.UpdateSlot();
        }
    }

    public override void HideUI()
    {
        base.HideUI();
        sfxController.PlayClip(SfxName.ButtonClick);

        uiManager[UIType.Lobby].ShowUI();
    }
}
