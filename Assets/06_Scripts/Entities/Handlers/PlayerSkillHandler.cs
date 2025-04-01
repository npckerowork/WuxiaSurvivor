using UnityEngine;

public class PlayerSkillHandler : MonoBehaviour
{
    public Transform SkillPos;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public float GetSkillDirection()
    {
        return spriteRenderer.flipX ? -1f : 1f;
    }
}