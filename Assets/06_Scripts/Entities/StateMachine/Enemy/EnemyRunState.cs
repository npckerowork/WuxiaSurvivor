using UnityEngine;

public class EnemyRunState : EnemyBaseState
{
    public EnemyRunState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Controller.AnimationHandler.SetState(ActionState.Run);
    }

    public override void Update()
    {
        base.Update();

        if (target == null)
        {
            target = GameManager.Instance.Player.transform;
            return;
        }

        moveDirection = (target.position - transform.position).normalized;
        if (moveDirection.x != 0)
        {
            body.flipX = moveDirection.x < 0;
        }

        transform.Translate(statHandler.MoveSpeed * Time.deltaTime * moveDirection);
    }
}