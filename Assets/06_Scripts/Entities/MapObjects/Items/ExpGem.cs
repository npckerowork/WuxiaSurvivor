using UnityEngine;

public class ExpGem : ItemBase
{
    [SerializeField] private int addBaseExpAmount; //기본 경험치 획득량

    protected override void ApplyEffect()
    {
        GameManager.Instance.Player.StatHandler.GetExp(addBaseExpAmount); //경험치 획득
        Debug.Log($"{addBaseExpAmount} 경험치 획득!");
        base.ApplyEffect();
    }
}
