using UnityEngine;

public enum ActionState
{
    Idle,
    Run,
    Attack
}

public class AnimationHandler : MonoBehaviour
{
    private static readonly int[] PARAMETERS =
    {
        Animator.StringToHash(ActionState.Idle.ToString()),
        Animator.StringToHash(ActionState.Run.ToString()),
        Animator.StringToHash(ActionState.Attack.ToString())
    };

    public Animator Animator { get; private set; }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void SetState(ActionState state)
    {
        foreach (var parameter in PARAMETERS)
        {
            Animator.SetBool(parameter, false);
        }

        if (state == ActionState.Attack)
        {
            Animator.SetTrigger(PARAMETERS[(int)state]);
            return;
        }

        Animator.SetBool(PARAMETERS[(int)state], true);
    }
}