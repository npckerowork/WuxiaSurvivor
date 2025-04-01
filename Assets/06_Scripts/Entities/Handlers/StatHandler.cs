using DG.Tweening;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    public bool IsDead { get { return hp == 0; } }
    public bool IsInvincibility { get; private set; }

    public float MaxHP { get; set; } = 100.0f;
    public float MoveSpeed { get; set; } = 5.0f;

    protected float hp;

    private AnimationHandler animationHandler;

    private void Awake()
    {
        hp = MaxHP;
        animationHandler = GetComponent<AnimationHandler>();
    }

    public virtual void Damage(float damage)
    {
        if (IsDead || IsInvincibility)
        {
            return;
        }

        IsInvincibility = true;
        hp = Mathf.Max(hp - damage, 0);
        animationHandler.SetState(ActionState.Hit);

        DOVirtual.DelayedCall(Define.INVINCIBILITY_TIME, () => IsInvincibility = false);
    }
}