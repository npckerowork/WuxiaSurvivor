using UnityEngine;

public class EnemyController : BaseController
{
    [field: SerializeField]
    public EnemyData Data { get; private set; }
    public EnemyProjectileHandler ProjectileHandler { get; private set; }
    public EnemyStatHandler StatHandler { get; private set; }

    private EnemyStateMachine stateMachine;

    protected override void Initialize()
    {
        base.Initialize();

        ProjectileHandler = GetComponent<EnemyProjectileHandler>();

        StatHandler = statHandler as EnemyStatHandler;
        StatHandler.SetData(Data);

        GetComponent<CharacterBuilder>().SetData(Data);

        stateMachine = new(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.Run);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
}