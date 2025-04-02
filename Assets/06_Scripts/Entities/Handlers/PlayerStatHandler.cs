using System;
using UnityEngine;

public class PlayerStatHandler : StatHandler
{
    private float exp = 0;
    private int maxExp = 100;

    public int Level
    {
        get => level;
        set
        {
            level = value;
            OnLevelUpEvent?.Invoke(level);
        }
    }

    private int level = 0;

    public Action<int> OnLevelUpEvent = delegate { }; //레벨업 할때 호출되는 이벤트

    private void Start()
    {
        invincibilityTime = Define.INVINCIBILITY_TIME;
    }

    public void SetData(PlayerData data)
    {
        MaxHP = data.MaxHP;
        hp = MaxHP;
        MoveSpeed = data.MoveSpeed;
    }

    public void ApplyUpgrade()
    {
        MaxHP *= DataManager.Instance.UpgradeData[UpgradeType.HP];
        MoveSpeed *= DataManager.Instance.UpgradeData[UpgradeType.MoveSpeed];
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
        gameUI.HealthUI.UpdateHealthBar(transform, MaxHP, hp);

        if (IsDead)
        {
            PlayerStateMachine stateMachine = GetComponent<PlayerController>().StateMachine;
            stateMachine.ChangeState(stateMachine.Death);
            stateMachine.Controller.InputSystem.Disable();
        }
    }

    //체력 회복
    public void Heal(float amount)
    {
        if (amount <= 0)
        {
            Debug.Log("힐량이 0이거나 음수입니다");
            return;
        }

        hp = Mathf.Min(hp + amount, MaxHP);
    }

    public void GetExp(float amount)
    {
        exp += amount;

        while (exp >= maxExp) //넘친 경험치가 다음 레벨로 이월되도록 
        {
            exp -= maxExp;
            Level++;
            AudioManager.Instance.sfxController.PlayClip(SfxName.LevelUp);
        }

        gameUI.Expbar.UpdateExp(exp, maxExp, Level);
    }
}