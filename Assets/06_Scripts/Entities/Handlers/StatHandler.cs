using DG.Tweening;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    public bool IsDead { get { return hp == 0; } }
    public bool IsInvincibility { get; private set; }

    public float MaxHP = 100.0f;
    public float MoveSpeed = 5.0f;

    protected float hp;

    private AnimationHandler animationHandler;

    private void Awake()
    {
        hp = MaxHP;
        animationHandler = GetComponent<AnimationHandler>();
    }

    public void Damage(float damage)
    {
        if (IsInvincibility)
        {
            return;
        }

        hp = Mathf.Max(hp - damage, 0);
        animationHandler.SetState(ActionState.Hit);

        IsInvincibility = true;
        DOVirtual.DelayedCall(Define.INVINCIBILITY_TIME, () => IsInvincibility = false);
    }
}