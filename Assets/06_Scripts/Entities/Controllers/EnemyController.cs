using DG.Tweening;
using UnityEngine;

public class EnemyController : BaseController
{
    #region Sequences
    private Sequence Body_Birth()
    {
        return Utility.RecyclableSequence()
            .Append(Body.DOFade(1.0f, 0.5f).From(0.0f).OnComplete(Stand));
    }

    private Sequence Body_Death()
    {
        return Utility.RecyclableSequence()
            .Append(Body.DOFade(0.0f, 0.5f).OnComplete(Destroy));
    }
    #endregion

    [field: SerializeField]
    public EnemyData Data { get; private set; }
    public EnemyProjectileHandler ProjectileHandler { get; private set; }
    public EnemyStatHandler StatHandler { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }

    protected override void Initialize()
    {
        base.Initialize();

        ProjectileHandler = GetComponent<EnemyProjectileHandler>();

        StatHandler = statHandler as EnemyStatHandler;
        StatHandler.SetData(Data);

        GetComponent<CharacterBuilder>().SetData(Data);

        StateMachine = new(this);

        BindSequences(BaseState.Birth, Body_Birth);
        BindSequences(BaseState.Death, Body_Death);
    }

    private void Start()
    {
        StateMachine.ChangeState(StateMachine.Run);
    }

    private void Update()
    {
        // TODO: 테스트 코드 -> Q 키를 누르면 모든 몬스터 HP가 50씩 감소됩니다.
        if (StatHandler.IsDead == false && Input.GetKeyDown(KeyCode.Q))
        {
            StatHandler.Damage(50);
        }

        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }
}