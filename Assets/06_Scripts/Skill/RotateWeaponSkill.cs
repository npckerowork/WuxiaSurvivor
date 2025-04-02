using System.Collections.Generic;
using UnityEngine;

public class RotateWeaponSkill : AttackSkillBase
{
    // 회전할 무기 프리팹
    [SerializeField] private GameObject weaponPrefabs;
    // 회전 속도
    [SerializeField] private float speed;
    // 플레이어와 얼마나 떨어져서 회전할지
    [SerializeField] private float distance;
    // 배치할 무기 갯수
    [SerializeField] private int weaponCount;
    
    // 생성한 무기 프리팹 리스트
    private List<RotateWeapon> weaponList = new List<RotateWeapon>();

    void Update()
    {
        ExecuteSkill();
    }

    public override void Init()
    {
        base.Init();

        for (int i = 0; i < weaponCount; i++)
        {
            GameObject obj = Instantiate(weaponPrefabs, transform);
            weaponList.Add(obj.GetComponent<RotateWeapon>());
            obj.transform.rotation = Quaternion.Euler(Vector3.forward * 360 * i / weaponCount);
            obj.transform.localPosition = obj.transform.up.normalized * distance;
            weaponList[i].Init(attackSkillData.Damage[attackSkillData.SkillLevel - 1], enemyLayer);
        }
    }

    public override void ExecuteSkill()
    {
        transform.Rotate(Vector3.back * speed);
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();

        for(int i = 0; i < weaponCount; i++)
        {
            weaponList[i].Damage = attackSkillData.Damage[attackSkillData.SkillLevel - 1];
        }
    }
}
