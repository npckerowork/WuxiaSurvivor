using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    private float damage;
    private LayerMask enemyLayer;

    public void Init(float damage, LayerMask layer)
    {
        this.damage = damage;
        enemyLayer = layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == Mathf.Log(enemyLayer.value, 2))
        {
            Debug.Log("충돌!!");
            collision.GetComponent<EnemyStatHandler>().Damage(damage);
        }
    }
}
