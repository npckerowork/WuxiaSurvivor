using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField] private GameObject damagePrefab;

    // 임시 오브젝트 풀링
    private Queue<DamagePopup> pool;

    public void InitDamageUI()
    {
        pool = new Queue<DamagePopup>();
    }

    public void OnDamage(float damage, SpriteRenderer spriteRenderer)
    {
        if (!pool.TryDequeue(out DamagePopup popup))
        {
            // 생성
            GameObject newPopup = Instantiate(damagePrefab, UIManager.Instance.transform);

            //초기화
            popup = newPopup.GetComponent<DamagePopup>();
            popup.InitPopup(this);
        }
        popup.OnDamage(damage, spriteRenderer);
    }

    public void ReturnPopup(DamagePopup popup)
    {
        pool.Enqueue(popup);
    }
}
