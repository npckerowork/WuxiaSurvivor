using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthUI healthUI;
    private Transform targetObject;
    private EnemyController enemyController;

    [SerializeField] private TextMeshProUGUI enemyNameText;
    [SerializeField] private Image healthFill;
    [SerializeField] private Vector3 healthBarOffset;
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
        if (targetObject.TryGetComponent(out enemyController))
            enemyNameText.text = enemyController.Data.Name;
        else
            enemyNameText.text = Define.PLAYER_NAME;

        enemyNameText.gameObject.SetActive(true);
        MoveHealthBar(target);
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 체력바 게이지 업데이트
    /// </summary>
    /// <param name="maxHp">최대체력</param>
    /// <param name="hp">현재체력</param>
    public void UpdateHealthBar(float maxHp, float hp)
    {
        healthFill.fillAmount = hp / maxHp;
    }

    private void FixedUpdate()
    {
        // 타겟 오브젝트 꺼져있음 ( 죽은 상태 또는 디스폰 )
        if (targetObject == null || targetObject.gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
            healthUI.ReturnHealthBar(targetObject, this);
            return;
        }

        MoveHealthBar(targetObject);
    }

    private void MoveHealthBar(Transform target)
    {
        // 월드 좌표 → 스크린 좌표 변환
        Vector3 pos = Camera.main.WorldToScreenPoint(target.transform.position);
        transform.position = pos + healthBarOffset;
    }
}
