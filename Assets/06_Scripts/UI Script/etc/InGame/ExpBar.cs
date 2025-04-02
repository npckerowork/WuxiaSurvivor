using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Slider expSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    /// <summary>
    /// 초기화
    /// </summary>
    /// 
    public void InitUI()
    {
        InitExpGauge();
        SceneLoader.Instance.AddAction(SceneType.Main, InitExpGauge);


    }

    private void InitExpGauge()
    {
        expSlider.value = 0;
        levelText.text = $"Lv. {0}";
    }

    /// <summary>
    /// ExpBar 최신화
    /// </summary>
    /// <param name="current">현재 수치</param>
    /// <param name="max">최대 수치</param>
    public void UpdateExp(float current, float max, int level)
    {
        float newValue = current / max;
        expSlider.DOValue(newValue, 0.5f).SetUpdate(true);

        levelText.text = $"Lv. {level}";
    }
}
