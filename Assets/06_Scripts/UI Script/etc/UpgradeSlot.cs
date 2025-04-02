using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeLevel;
    [SerializeField] private Image upgradeImage;
    [SerializeField] private TextMeshProUGUI upgradeValue;
    [SerializeField] private Button upgradeButton;

    private UpgradeData data;
    private UpgradeType upgradeType;

    private int typeIndex => (int)upgradeType;
    public void InitSlot(UpgradeData data, UpgradeType type)
    {
        this.data   = data;
        upgradeType = type;

        // 이미지 초기화
        upgradeImage.sprite = data.upgradeDatas[typeIndex].sprite;

        // 업그레이드 버튼 함수 할당
        upgradeButton.onClick.AddListener(UpgradeButton);

        UpdateSlot();
    }

    public void UpdateSlot()
    {
        // 레벨 / 가격 업데이트
        upgradeLevel.text = $"LV {data.upgradeLevels[typeIndex]}";
        upgradeValue.text = $"{data.upgradePrices[typeIndex]}";
    }

    private void UpgradeButton()
    {
        AudioManager.Instance.sfxController.PlayClip(SfxName.ButtonClick);

        int useCoin = data.upgradePrices[typeIndex];
        if(DataManager.Instance.Coin.IsCanUse(useCoin))
        {
            // coin 사용
            DataManager.Instance.Coin.Use(useCoin);

            // 업그레이드 레벨 증가
            data.upgradeLevels[typeIndex]++;

            // 가격 / 수치 증가 배율
            float valueRatio = data.upgradeDatas[typeIndex].valueRatio;
            float priceRatio = data.upgradeDatas[typeIndex].priceRatio;

            // 가격 / 수치 증가
            data.upgradeValues[typeIndex] *= valueRatio;
            data.upgradePrices[typeIndex] = 
                Mathf.RoundToInt(data.upgradePrices[typeIndex] * priceRatio);

            // slot 업데이트
            UpdateSlot();
            AudioManager.Instance.sfxController.PlayClip(SfxName.TaskDone);
            return;
        }
    }
}
