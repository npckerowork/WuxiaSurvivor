using System.Collections.Generic;
using UnityEngine;

public interface ISkillBehavior
{
    public void Init();
    public void ExecuteSkill();
}

public interface ICoolTimeCount
{
    public bool CheckCoolTime();
}

public class ProjectileFireSkill : MonoBehaviour, ISkillBehavior
{
    // 동작 구현부터
    // 스킬 데이터
    [SerializeField] private AttackSkillData attackSkillData;
    // 투사체 프리팹
    [SerializeField] private GameObject projectileObj;
    // 몬스터를 탐지하고 공격하는 범위
    [SerializeField] private float attackRange;
    // 쿨타임
    [SerializeField] private float baseCoolTime;
    // 마지막으로 스킬을 쓴 시간
    private float lastUseSkillCoolTime;
    // 생성할 투사체 프리팹 갯수
    [SerializeField] private int countObj;
    // 몬스터 레이어
    [SerializeField] private LayerMask layerMask;
    // 플레이어 Transform
    private Transform playerTrs;
    private List<Projectile> projectileList = new List<Projectile>();
    private Collider2D[] hits = null;
    // 스킬 레벨
    private int skillLevel = 1;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        ExecuteSkill();
    }

    public void Init()
    {
        playerTrs = GameManager.Instance.Player.transform;

        for(int i = 0; i < countObj; i++)
        {
            GameObject obj = Instantiate(projectileObj);
            projectileList.Add(obj.GetComponent<Projectile>());
            projectileList[i].MonsterLayer = layerMask;
            projectileList[i].Init();
            projectileList[i].Damage = attackSkillData.Damage[skillLevel - 1];
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// 쿨타임 체크
    /// </summary>
    /// <returns>쿨타임이 전부 지났는지</returns>
    public bool CheckCoolTime()
    {
        if(baseCoolTime < Time.time - lastUseSkillCoolTime)
        {
            lastUseSkillCoolTime = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ExecuteSkill()
    {
        hits = Physics2D.OverlapCircleAll(playerTrs.position, attackRange, layerMask);
        if (!CheckCoolTime() || hits.Length == 0) return;

        int length = hits.Length;
        Collider2D target = hits[0];
        Debug.Log(hits[0].gameObject.name);
        float distance = Vector2.Distance(playerTrs.position, target.transform.position);

        for(int i = 1; i < length; i++)
        {
            if(Vector2.Distance(playerTrs.position, hits[i].transform.position) < distance)
            {
                target = hits[i];
                distance = Vector2.Distance(playerTrs.position, target.transform.position);
            }
        }

        for(int i = 0; i < countObj; i++)
        {
            if (projectileList[i].Usabel)
            {
                projectileList[i].gameObject.SetActive(true);
                projectileList[i].SetProjectile(playerTrs.position, (target.transform.position - playerTrs.position).normalized);
                break;
            }
        }

        hits = null;
    }
}
