using UnityEngine;

public class EnemyProjectileHandler : MonoBehaviour
{
    #region Inspector
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField, Range(0.0f, 360.0f)] private float spreadAngle = 15.0f;
    [SerializeField] private int projectileCount = 1;
    #endregion

    private EnemyStatHandler statHandler;

    private void Awake()
    {
        statHandler = GetComponent<EnemyStatHandler>();
    }

    public void Shot(Vector2 startPosition, Vector2 targetDirection)
    {
        float minAngle = (projectileCount - 1) * -0.5f * spreadAngle;
        for (int j = 0; j < projectileCount; j++)
        {
            float angle = minAngle + (spreadAngle * j);
            Vector2 bulletDirection = Quaternion.Euler(0.0f, 0.0f, angle) * targetDirection;

            string key = projectilePrefab.name;
            GameObject projectile = ResourceManager.Instance.Instantiate(key, null, startPosition, targetDirection);
            projectile.GetComponent<ProjectileController>().SetProjectile(statHandler.AttackDamage, bulletDirection);
        }
    }
}