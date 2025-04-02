using System.Collections;
using UnityEngine;

public class Shuriken : AttackSkillBase
{
    [SerializeField] private float MoveSpeed = 20.0f; //이동 속도
    [SerializeField] private float returnDelay = 1.0f; //수리검을 되돌리는 시간
    [SerializeField] private float skillCooldown = 5f; //스킬 쿨다운

    private PlayerController player;
    private PlayerSkillHandler skillController;

    private void Start()
    {
        GameManager.Instance.Player.OnDeath += CancelInvoke; //플레이어가 죽었을때 invoke 중지
    }

    public override void ExecuteSkill()
    {
        transform.position = skillController.SkillPos.position;
        gameObject.SetActive(true);
        StartCoroutine(IExcuteSkill());
    }

    private IEnumerator IExcuteSkill()
    {
        float time = 0;

        while (time < returnDelay)
        {
            transform.position += Vector3.right * skillController.GetSkillDirection() * MoveSpeed * Time.deltaTime;
            time += Time.deltaTime;
            yield return null;
        }

        while (true)
        {
            Vector3 toPlayer = (skillController.SkillPos.position - transform.position).normalized;
            transform.position += toPlayer * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, skillController.SkillPos.position) < 0.1f)
                break;

            yield return null;
        }

        //TODO: 풀로 되돌려놓기
        gameObject.SetActive(false);
    }

    public override void Init()
    {
        base.Init();
        player = GameManager.Instance.Player;
        skillController = player.SkillHandler;
        InvokeRepeating(nameof(ExecuteSkill), 0, skillCooldown);
        transform.position = skillController.SkillPos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyController enemy))
        {
            //TODO : 데미지 계산 수정
            enemy.StatHandler.Damage(attackSkillData.Damage[attackSkillData.SkillLevel - 1]);
        }
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        skillCooldown *= 0.7f;
    }
}
