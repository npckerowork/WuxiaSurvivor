using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [field: SerializeField]
    public PlayerData Data { get; private set; }
    public PlayerInputSystem InputSystem { get; private set; }
    public PlayerStatHandler StatHandler { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerSkillHandler SkillHandler { get; private set; }
    public Dictionary<string, ISkillBehavior> Skills { get; private set; } = new();

    protected override void Initialize()
    {
        base.Initialize();

        StatHandler = statHandler as PlayerStatHandler;
        StatHandler.SetData(Data);

        Rigidbody = GetComponent<Rigidbody2D>();
        SkillHandler = GetComponent<PlayerSkillHandler>();

        InputSystem = new();
        StateMachine = new(this);

        GetComponent<CharacterBuilder>().SetData(Data);
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