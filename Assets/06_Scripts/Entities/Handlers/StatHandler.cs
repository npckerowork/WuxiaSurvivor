using UnityEngine;

public class StatHandler : MonoBehaviour
{
    public bool IsDead { get { return hp == 0; } }

    public float MaxHP = 100.0f;
    public float MoveSpeed = 5.0f;

    protected float hp;

    public void Damage(float damage)
    {
        hp = Mathf.Max(hp - damage, 0);
    }
}