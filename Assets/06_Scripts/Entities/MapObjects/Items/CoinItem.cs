using UnityEngine;

public class CoinItem : ItemBase
{
    [SerializeField] private int addBaseCoinAmount; //기본 코인획득수

    protected override void ApplyEffect()
    {
        //최종 획득 코인수 계산 (기본 획득 코인수 * 업그레이드한 코인수 배율)
        float coinRatio = DataManager.Instance.UpgradeData[UpgradeType.CoinRatio];
        int addCoinAmount = Mathf.FloorToInt(addBaseCoinAmount * coinRatio);
        GameManager.Instance.GameCoin.Add(addCoinAmount);
        DebugLogger.Log($"{addCoinAmount} 코인 획득!");
        base.ApplyEffect();
    }
}
