using UnityEngine;

public class EnemyRunState : EnemyBaseState
{
    public EnemyRunState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Controller.AnimationHandler.SetState(ActionState.Run);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Controller.AnimationHandler.Animator.speed = 1.0f;
    }

    public override void Update()
    {
        if (Target == null) return;

        base.Update();

        moveDirection = (Target.position - transform.position).normalized;
        if (moveDirection.x != 0)
        {
            body.flipX = moveDirection.x < 0;
        }

        transform.Translate(statHandler.MoveSpeed * Time.deltaTime * moveDirection);
    }
}