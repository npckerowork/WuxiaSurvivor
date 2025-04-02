public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Controller.AnimationHandler.SetState(ActionState.Idle);
    }
}