public class EnemyStatHandler : StatHandler
{
    public float AttackDamage = 5.0f;
    public float AttackDelay = 1.0f;
    public float AttackRange = 1.0f;

    public void SetData(EnemyData data)
    {
        MaxHP = data.MaxHP;
        hp = MaxHP;
        MoveSpeed = data.MoveSpeed;
        AttackDamage = data.AttackDamage;
        AttackDelay = data.AttackDelay;
        AttackRange = data.AttackRange;
    }
}