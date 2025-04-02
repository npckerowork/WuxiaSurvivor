public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Controller.AnimationHandler.SetState(ActionState.Idle);
    }
}