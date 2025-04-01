using System.Collections;
using UnityEngine;

public class IcicleFlurry : MonoBehaviour
{
    [SerializeField] private IceProjectile iceProjectilePrefab;

    [SerializeField] private float shootSpeed = 5.0f; //투사체 발사 스피드
    [SerializeField] private float damage = 3.0f; //투사체 데미지
    [SerializeField] private float skillCoolDown = 5.0f; //스킬 쿨다운
    [SerializeField] private float projectileSpawndelayTime = 0.2f; //투사체 발사 딜레이
    [SerializeField] private int directionCount = 1; //투사체 방향수
    [SerializeField] private int projectileCount = 3; //발사할 투사체의 개수

    private PlayerSkillHandler skillHandler;

    private void Start()
    {
        skillHandler = GameManager.Instance.Player.SkillHandler;
        InvokeRepeating(nameof(ShootIceInDirections), 0, skillCoolDown);

        GameManager.Instance.Player.OnDeath += CancelInvoke; //플레이어가 죽었을때 invoke 중지
    }

    private void ShootIceInDirections()
    {
        float angleStep = 360f / directionCount;
        float angle = 0f;

        for (int i = 0; i < directionCount; i++)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized; //발사할 방향 정하기
            if (directionCount == 1)
            {
                dir *= skillHandler.GetSkillDirection(); //발사체가 하나일때 플레이어 보는 방향으로 쏘기
            }
            StartCoroutine(IShootIce(dir));
            angle += angleStep;
        }
    }

    private IEnumerator IShootIce(Vector2 dir)
    {
        Vector2 spawnPos = skillHandler.SkillPos.position;

        for (int j = 0; j < projectileCount; j++)
        {
            var ice = ResourceManager.Instance.Instantiate("IceProjectile", null, spawnPos, Vector3.zero);

            //방향에 맞춰 회전하기
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, dir);
            ice.transform.rotation = rot;

            if (ice.TryGetComponent(out IceProjectile iceProjectile))
            {
                iceProjectile.SetData(dir, damage, shootSpeed);
            }

            yield return new WaitForSeconds(projectileSpawndelayTime);
        }
    }
}
