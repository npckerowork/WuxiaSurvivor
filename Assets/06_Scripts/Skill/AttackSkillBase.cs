using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkillBase : MonoBehaviour, ISkillBehavior
{
    [SerializeField] protected AttackSkillData attackSkillData;
    public AttackSkillData SkillData { get { return attackSkillData; } }
    [SerializeField] protected LayerMask enemyLayer;

    protected Transform playerTrs;

    public virtual void Init()
    {
        playerTrs = GameManager.Instance.Player.transform;
    }

    public virtual void ExecuteSkill()
    {
        
    }

    public virtual void SkillLevelUp()
    {
        if (attackSkillData.SkillLevel == attackSkillData.MaxLevel) return;

        attackSkillData.SkillLevel++;
    }
}
