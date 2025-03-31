public class EnemyStateMachine : StateMachine
{
    public EnemyController Controller { get; private set; }

    public EnemyIdleState Idle { get; private set; }
    public EnemyRunState Run { get; private set; }
    public EnemyAttackState Attack { get; private set; }

    public EnemyStateMachine(EnemyController controller)
    {
        Controller = controller;

        Idle = new(this);
        Run = new(this);
        Attack = new(this);
    }
}