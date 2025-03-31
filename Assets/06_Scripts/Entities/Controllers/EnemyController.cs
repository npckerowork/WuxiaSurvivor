public class EnemyController : BaseController
{
    public EnemyStatHandler StatHandler { get; private set; }

    private EnemyStateMachine stateMachine;

    protected override void Initialize()
    {
        base.Initialize();

        StatHandler = GetComponent<EnemyStatHandler>();

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