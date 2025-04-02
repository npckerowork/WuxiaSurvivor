public class EnemyStatHandler : StatHandler
{
    public float AttackDamage { get; set; } = 5.0f;
    public float AttackDelay { get; set; } = 1.0f;
    public float AttackRange { get; set; } = 1.0f;

    public void SetData(EnemyData data)
    {
        MaxHP = data.MaxHP;
        hp = MaxHP;
        MoveSpeed = data.MoveSpeed;
        AttackDamage = data.AttackDamage;
        AttackDelay = data.AttackDelay;
        AttackRange = data.AttackRange;
    }

    public override void Damage(float damage)
    {
        if (IsDead) return;

        float upgradeDamage = damage * DataManager.Instance.UpgradeData[UpgradeType.Damage];
        base.Damage(upgradeDamage);

        // ==== UI / Effect / Sound ====
        gameUI.DamageUI.OnDamage(upgradeDamage, transform);
        gameUI.HealthUI.UpdateHealthBar(transform, MaxHP, hp);
        AudioManager.Instance.sfxController.RandomHitSFX(transform.position);
        VFXManager.Instance.PlayVFX(EffectType.SparkPurple, transform.position);
        // =============================

        if (IsDead)
        {
            EnemyStateMachine stateMachine = GetComponent<EnemyController>().StateMachine;
            stateMachine.ChangeState(stateMachine.Death);
        }
    }
}