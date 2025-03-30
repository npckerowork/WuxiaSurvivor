using UnityEngine;

public class Coin : ItemBase
{
    [SerializeField] private int addBaseCoinAmount; //기본 코인획득수

    protected override void ApplyEffect()
    {
        // TODO : 코인획득
        Debug.Log($"{addBaseCoinAmount} 코인 획득!");
        base.ApplyEffect();
    }
}
