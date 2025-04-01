using DG.Tweening;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        stateMachine.Controller.AnimationHandler.SetState(ActionState.Die);
        DOVirtual.DelayedCall(1.0f, stateMachine.Controller.Death);
    }
}