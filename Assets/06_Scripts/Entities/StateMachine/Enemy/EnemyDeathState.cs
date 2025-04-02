using DG.Tweening;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();

        stateMachine.Controller.AnimationHandler.SetState(ActionState.Die);
        DOVirtual.DelayedCall(1.0f, stateMachine.Controller.Death);
    }
}