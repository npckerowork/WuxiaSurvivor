using System.Collections.Generic;
using UnityEngine;

public class RotateWeaponSkill : MonoBehaviour, ISkillBehavior
{
    // 회전할 무기 프리팹
    [SerializeField] private GameObject weaponPrefabs;
    // 스킬 데이터
    [SerializeField] private AttackSkillData attackSkillData;
    // 회전 속도
    [SerializeField] private float speed;
    // 플레이어와 얼마나 떨어져서 회전할지
    [SerializeField] private float distance;
    // 배치할 무기 갯수
    [SerializeField] private int weaponCount;
    // 몬스터 레이어
    [SerializeField] private LayerMask enemyLayer;
    
    // 생성한 무기 프리팹 리스트
    private List<GameObject> weaponList = new List<GameObject>();

    // 스킬 레벨
    private int skillLevel = 1;

    void Start()
    {
        Init();
    }

    void Update()
    {
        ExecuteSkill();
    }

    public void Init()
    {
        for (int i = 0; i < weaponCount; i++)
        {
            GameObject obj = Instantiate(weaponPrefabs, transform);
            weaponList.Add(obj);
            obj.transform.rotation = Quaternion.Euler(Vector3.forward * 360 * i / weaponCount);
            obj.transform.position = obj.transform.up.normalized * distance;
            obj.GetComponent<RotateWeapon>().Init(attackSkillData.Damage[skillLevel - 1], enemyLayer);
        }
    }

    public void ExecuteSkill()
    {
        transform.Rotate(Vector3.back * speed);
    }
}
