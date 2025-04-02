using UnityEngine;

public abstract class EnemyBaseState : IState
{
    public Transform Target { get; private set; }

    protected float targetDisatance = float.MaxValue;
    protected Vector2 moveDirection = Vector2.zero;

    protected PlayerController targetController;

    protected readonly EnemyStateMachine stateMachine;
    protected readonly EnemyStatHandler statHandler;
    protected readonly SpriteRenderer body;
    protected readonly Transform transform;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        transform = stateMachine.Controller.transform;
        statHandler = stateMachine.Controller.StatHandler;
        body = stateMachine.Controller.Body;

        SetTartget(GameManager.Instance.Player.transform);
    }

    public void SetTartget(Transform target)
    {
        Target = target;
        targetController = target.GetComponent<PlayerController>();
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void FixedUpdate() { }

    public virtual void Update()
    {
        if (statHandler.IsDead) return;

        targetDisatance = (Target.position - transform.position).magnitude;
        if (statHandler.AttackRange < targetDisatance) return;

        stateMachine.ChangeState(stateMachine.Attack);
    }
}