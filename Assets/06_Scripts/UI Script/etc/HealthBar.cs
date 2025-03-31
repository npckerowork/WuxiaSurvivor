using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthUI healthUI;
    private Transform targetObject;

    [SerializeField] private Image healthFill;

    /// <summary>
    /// 체력바 초기화
    /// </summary>
    /// <param name="healthUI"></param>
    public void InitHealthBar(HealthUI healthUI)
    {
        this.healthUI = healthUI;
    }

    /// <summary>
    /// 체력바 켜기
    /// </summary>
    /// <param name="target">체력바 타겟</param>
    public void RegisterTarget(Transform target)
    {
        targetObject = target;
        gameObject.SetActive(true);
    }

    public void UpdateHealthBar(float maxHp, float hp)
    {
        healthFill.fillAmount = hp / maxHp;
    }

    private void Update()
    {
        // 타겟 오브젝트 꺼져있음 ( 죽은 상태 또는 디스폰 )
        if (targetObject.gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
            healthUI.ReturnHealthBar(targetObject, this);
            return;
        }

        // 월드 좌표 → 스크린 좌표 변환
        Vector3 pos = Camera.main.WorldToScreenPoint(targetObject.transform.position);
        transform.position = pos;
    }
}
