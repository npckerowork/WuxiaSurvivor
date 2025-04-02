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

    public ItemBase ExpGemPrefab;

    protected override void Initialize()
    {
        base.Initialize();

        ProjectileHandler = GetComponent<EnemyProjectileHandler>();

        StatHandler = statHandler as EnemyStatHandler;
        StatHandler.SetData(Data);
        OnDeath += DropExpGem;

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

    public override void Birth()
    {
        base.Birth();
        StateMachine.ChangeState(StateMachine.Run);
    }

    public override void Destroy()
    {
        base.Destroy();

        GameManager.Instance.Enemies.Remove(gameObject);
        GameManager.Instance.GameUpdate();
    }

    private void DropExpGem()
    {
        //경험지 젬 드롭
        var gem = ResourceManager.Instance.Instantiate(ExpGemPrefab.name, null, transform.position, Vector2.zero);

        //TODO: EffectManager로 옮기기..?
        //팅기게 하는 이펙트
        Vector2 dir = Random.insideUnitCircle.normalized * 1.0f; //랜덤한 방향성 부여
        Vector3 targetPos = transform.position + (Vector3)dir;

        float duration = 0.2f;

        //x축 이동
        gem.transform.DOMove(targetPos, duration).SetEase(Ease.Linear);

        //y축 이동 (포물선 궤도)
        gem.transform.DOMoveY(transform.position.y + 0.5f, duration / 2f)
            .SetEase(Ease.OutQuad)
            .SetLoops(2, LoopType.Yoyo);  //2번 튀어오르게
    }
}