using UnityEngine;

public class CoinItem : ItemBase
{
    [SerializeField] private int addBaseCoinAmount; //기본 코인획득수

    protected override void ApplyEffect()
    {
        GameManager.Instance.GameCoin.Add(addBaseCoinAmount); //코인 획득
        Debug.Log($"{addBaseCoinAmount} 코인 획득!");
        base.ApplyEffect();
    }
}
