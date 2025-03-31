using UnityEngine;

public class HealPotion : ItemBase
{
    [SerializeField] private int addBaseHealAmount; //기본 체력회복값

    protected override void ApplyEffect()
    {
        GameManager.Instance.Player.StatHandler.Heal(addBaseHealAmount); //체력 회복
        Debug.Log($"{addBaseHealAmount} 체력 회복!");
        base.ApplyEffect();
    }
}
