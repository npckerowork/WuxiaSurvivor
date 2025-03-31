using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Slider expSlider;

    /// <summary>
    /// 초기화
    /// </summary>
    public void InitExpBar()
    {
        expSlider.value = 0;
    }

    /// <summary>
    /// ExpBar 최신화
    /// </summary>
    /// <param name="current">현재 수치</param>
    /// <param name="max">최대 수치</param>
    public void UpdateExp(float current, float max)
    {
        expSlider.value = current / max;
    }
}
