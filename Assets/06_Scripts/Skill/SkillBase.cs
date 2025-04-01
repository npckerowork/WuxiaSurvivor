using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour, ISkillBehavior
{
    protected Transform playerTrs;

    public void ExecuteSkill()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        playerTrs = GameManager.Instance.Player.transform;
    }

    public void SkillLevelUp()
    {
        throw new System.NotImplementedException();
    }

    public void StopSkill()
    {
        throw new System.NotImplementedException();
    }
}
