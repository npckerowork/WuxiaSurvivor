using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    #region Inspector
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private LayerMask targetLayer;
    #endregion

    protected Rigidbody2D _rigidbody;
    private float damage;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SetProjectile(float damage, Vector2 targetDirection)
    {
        this.damage = damage;

        var z = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, z);
        _rigidbody.velocity = targetDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject targetObject = collision.gameObject;
        int targetObjectLayer = 1 << targetObject.layer;
        if ((targetObjectLayer & targetLayer) != 0)
        {
            var @base = targetObject.GetComponent<BaseController>();
            if (@base.IsDead)
            {
                return;
            }

            if (@base is PlayerController)
            {
                (@base as PlayerController).StatHandler.Damage(damage);
            }
            else if (@base is EnemyController)
            {
                (@base as EnemyController).StatHandler.Damage(damage);
            }

            Destroy();
        }
    }

    private void Destroy()
    {
        ResourceManager.Instance.Destroy(gameObject);
    }
}