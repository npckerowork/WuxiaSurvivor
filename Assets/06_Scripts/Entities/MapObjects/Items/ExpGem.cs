using UnityEngine;

public class ExpGem : ItemBase
{
    [SerializeField] private int addBaseExpAmount; //기본 경험치 획득량

    protected override void ApplyEffect()
    {
        //최종 획득 경험치 계산 (기본 획득 경험치 * 업그레이드한 경험치 배율)
        float expRatio = DataManager.Instance.UpgradeData[UpgradeType.ExpRatio];
        int addExpAmount = Mathf.FloorToInt(addBaseExpAmount * expRatio); 
        GameManager.Instance.Player.StatHandler.GetExp(addExpAmount); //경험치 획득
        Debug.Log($"{addExpAmount} 경험치 획득!");
        base.ApplyEffect();
    }
}
