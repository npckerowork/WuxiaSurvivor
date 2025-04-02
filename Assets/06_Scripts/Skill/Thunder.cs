using UnityEngine;

public class Thunder : AttackSkillBase
{
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private float skillCooldown = 3f; //스킬 쿨다운

    private void Start()
    {
        InvokeRepeating(nameof(ExecuteSkill), 0, skillCooldown);
        GameManager.Instance.Player.OnDeath += CancelInvoke; //플레이어가 죽었을때 invoke 중지
    }

    public override void ExecuteSkill()
    {
        transform.position = GetRandomPosition();
        gameObject.SetActive(true);
    }

    public override void Init() 
    {
        base.Init();
    }

    public void ActiveCollider()
    {
        boxCollider.enabled = true;
    }

    public void PassiveCollider()
    {
        boxCollider.enabled = false;
    }

    public void ReturnPool()
    {
        gameObject.SetActive(false);
    }

    //카메라 시야 내 랜덤 위치 반환
    private Vector2 GetRandomPosition()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);

        return new Vector3(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemy))
        {
            //TODO : 데미지 계산 수정
            enemy.StatHandler.Damage(attackSkillData.Damage[attackSkillData.MaxLevel - 1]);
        }
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        skillCooldown *= 0.7f;
    }
}
