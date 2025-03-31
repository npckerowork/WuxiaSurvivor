using DG.Tweening;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    private float timer;

    public override void Enter()
    {
        base.Enter();

        if (stateMachine.Controller.ProjectileHandler == null)
        {
            DOVirtual.DelayedCall(0.25f, () => targetController.StatHandler.Damage(statHandler.AttackDamage));
        }

        stateMachine.Controller.AnimationHandler.SetState(ActionState.Attack);
    }

    public override void Exit()
    {
        base.Exit();
        timer = 0.0f;
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer < statHandler.AttackDelay) return;

        base.Update();

        if (statHandler.AttackRange < targetDisatance)
        {
            stateMachine.ChangeState(stateMachine.Run);
            return;
        }
    }
}