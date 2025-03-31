using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;

    private Queue<HealthBar> pool;
    Dictionary<Transform, HealthBar> useHealthBar;

    public void InitHealthBar()
    {
        pool = new Queue<HealthBar>();
        useHealthBar = new Dictionary<Transform, HealthBar>();
    }

    public void UpdateHealthBar(Transform target, float maxHp, float hp)
    {
        // 사용중인 체력바가 없으면
        if (!useHealthBar.TryGetValue(target, out HealthBar healthBar))
        {
            // 풀에 남아있는 체력바가 없으면
            if (!pool.TryDequeue(out healthBar))
            {
                // 생성
                GameObject newHealthBar = Instantiate(healthBarPrefab, transform);

                // 초기화
                healthBar = newHealthBar.GetComponent<HealthBar>();
                healthBar.InitHealthBar(this);
            }

            useHealthBar.Add(target, healthBar);
            healthBar.RegisterTarget(target);
        }

        healthBar.UpdateHealthBar(maxHp, hp);
    }

    public void ReturnHealthBar(Transform target, HealthBar healthBar)
    {
        useHealthBar.Remove(target);    // 사용중 체력바 제거
        pool.Enqueue(healthBar);        // 체력바 회수
    }
}
