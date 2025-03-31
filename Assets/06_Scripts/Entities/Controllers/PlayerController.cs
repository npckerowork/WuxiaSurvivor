using UnityEngine;

public class PlayerController : BaseController
{
    public PlayerInputSystem InputSystem { get; private set; }
    public PlayerStatHandler StatHandler { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    protected override void Initialize()
    {
        base.Initialize();

        StatHandler = statHandler as PlayerStatHandler;
        Rigidbody = GetComponent<Rigidbody2D>();

        InputSystem = new();
        StateMachine = new(this);
    }

    private void Start()
    {
        StateMachine.ChangeState(StateMachine.Idle);
    }

    private void OnEnable()
    {
        InputSystem.Enable();
    }

    private void OnDisable()
    {
        InputSystem.Disable();
    }

    private void Update()
    {
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }
}