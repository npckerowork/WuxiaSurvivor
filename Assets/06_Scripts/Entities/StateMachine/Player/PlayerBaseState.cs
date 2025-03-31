using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerBaseState : IState
{
    protected Vector2 moveDirection;

    protected readonly PlayerStateMachine stateMachine;
    protected readonly PlayerStatHandler statHandler;
    protected readonly Rigidbody2D rigidbody;
    protected readonly SpriteRenderer body;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        statHandler = stateMachine.Controller.StatHandler;
        rigidbody = stateMachine.Controller.Rigidbody;
        body = stateMachine.Controller.Body;
    }

    public virtual void Enter()
    {
        PlayerInputSystem.PlayerActions @event = stateMachine.Controller.InputSystem.Player;
        @event.Move.performed += OnMovementPerformed;
        @event.Move.canceled += OnMovementCanceled;
    }

    public virtual void Exit()
    {
        PlayerInputSystem.PlayerActions @event = stateMachine.Controller.InputSystem.Player;
        @event.Move.performed -= OnMovementPerformed;
        @event.Move.canceled -= OnMovementCanceled;
    }

    public virtual void Update() { }

    public virtual void FixedUpdate()
    {
        if (moveDirection.x != 0)
        {
            body.flipX = moveDirection.x < 0;
        }

        rigidbody.velocity = statHandler.MoveSpeed * moveDirection;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        stateMachine.Controller.AnimationHandler.SetState(ActionState.Run);
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        moveDirection = Vector2.zero;
        stateMachine.Controller.AnimationHandler.SetState(ActionState.Idle);
    }
}