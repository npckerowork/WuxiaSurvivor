using UnityEngine;

public enum AttackCategory
{
    ProjectileFire,
    Rotate,
    Boomerang
}

[CreateAssetMenu(fileName = "new AttackSkillData", menuName = "Skill/SkillDatas/AttackSkillData")]
public class AttackSkillData : SkillData
{
    // 공격 방식(투사체 발사라던지, 투사체를 발사했다가 돌아온다던지...)
    [SerializeField] protected AttackCategory attackType;
    public AttackCategory AttackType { get { return attackType; } }
    // 스킬로 입힐 수 있는 데미지
    // 레벨에 따라서 바뀔 수 있게 배열로
    [SerializeField] protected float[] damage;
    public float[] Damage { get { return damage; } }
    // 스킬 발동에 필요한 오브젝트 갯수
    [SerializeField] private int[] objCount;
    public int[] ObjCount { get { return objCount; } }
}
