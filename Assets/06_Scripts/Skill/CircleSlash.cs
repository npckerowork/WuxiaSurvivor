using UnityEngine;

public class CircleSlash : AttackSkillBase
{
    [SerializeField] private float skillCooldown = 3f; //스킬 쿨다운
    [SerializeField] private float damage = 10f; //임시값
    [SerializeField] private float scale = 1f; //스킬 범위(스킬 크기)

    private void Start()
    {
        //생성 할때 스킬 생성위치 하위로 배치
        //TODO: 생성할때 이 코드 작성
        //transform.SetParent(GameManager.Instance.Player.SkillHandler.SkillPos); 
        InvokeRepeating(nameof(Slash),0, skillCooldown);
        GameManager.Instance.Player.OnDeath += CancelInvoke; //플레이어가 죽었을때 invoke 중지
    }

    public override void Init()
    {
        base.Init();

    }

    private void Slash()
    {
        transform.localScale = new Vector2(scale, scale);
        gameObject.SetActive(true);
    }

    //애니메이션에서 호출
    public void Passive()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyController enemy))
        {
            //TODO : 데미지 계산 
            enemy.StatHandler.Damage(damage);
        }
    }
}
