using UnityEngine;

public abstract class EnemyBaseState : IState
{
    protected float targetDisatance = float.MaxValue;
    protected Vector2 moveDirection = Vector2.zero;

    protected Transform transform;
    protected Transform target;

    protected readonly EnemyStateMachine stateMachine;
    protected readonly EnemyStatHandler statHandler;
    protected readonly SpriteRenderer body;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        transform = stateMachine.Controller.transform;
        target = GameManager.Instance.Player.transform;

        statHandler = stateMachine.Controller.StatHandler;
        body = stateMachine.Controller.Body;

        // TEST CODE
        stateMachine.Controller.GetComponent<BaseController>().Stand();
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void FixedUpdate() { }

    public virtual void Update()
    {
        if (statHandler.IsDead) return;

        targetDisatance = (target.position - transform.position).magnitude;
        if (statHandler.AttackRange < targetDisatance) return;

        stateMachine.ChangeState(stateMachine.Attack);
    }
}