using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    private bool isInitialized = false;

    private float attackDamage;
    private float shootSpeed;
    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, 1.0f); // 자동 제거
    }

    public void SetData(Vector3 dir,float damage, float moveSpeed)
    {
        direction = dir.normalized;
        attackDamage = damage;
        shootSpeed = moveSpeed;
        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized) return;
        transform.position += (Vector3)direction  * shootSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyController enemy))
        {
            //TODO : 데미지 계산 
            enemy.StatHandler.Damage(attackDamage);
            ResourceManager.Instance.Destroy(gameObject); //풀로 되돌리기
        }
    }
}
