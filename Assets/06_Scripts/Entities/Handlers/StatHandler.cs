using DG.Tweening;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    public bool IsDead { get { return hp == 0; } }
    public bool IsInvincibility { get; private set; }

    public float MaxHP { get; set; } = 100.0f;
    public float MoveSpeed { get; set; } = 5.0f;

    protected float hp;
    protected float invincibilityTime;

    private AnimationHandler animationHandler;
    protected InGameUI gameUI;
    private void Awake()
    {
        hp = MaxHP;
        animationHandler = GetComponent<AnimationHandler>();
        gameUI = UIManager.Instance.GetUI<InGameUI>();
    }

    private void OnEnable()
    {
        hp = MaxHP;
    }

    public virtual void Damage(float damage)
    {
        if (IsDead || IsInvincibility)
        {
            return;
        }

        if (invincibilityTime > 0.0f)
        {
            IsInvincibility = true;
            DOVirtual.DelayedCall(invincibilityTime, () => IsInvincibility = false);
        }

        hp = Mathf.Max(hp - damage, 0);
        animationHandler.SetState(ActionState.Hit);
    }
}