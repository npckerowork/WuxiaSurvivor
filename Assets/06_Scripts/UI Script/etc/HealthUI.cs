using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;

    private Queue<HealthBar> pool;
    Dictionary<Transform, HealthBar> useHealthBar;

    public void InitUI()
    {
        pool = new Queue<HealthBar>();
        useHealthBar = new Dictionary<Transform, HealthBar>();
    }

    public void UpdateHealthBar(Transform target, float maxHp, float hp)
    {
        if (!useHealthBar.TryGetValue(target, out HealthBar healthBar))
        {
            if (!pool.TryDequeue(out healthBar))
            {
                GameObject newHealthBar = Instantiate(healthBarPrefab, transform);

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
