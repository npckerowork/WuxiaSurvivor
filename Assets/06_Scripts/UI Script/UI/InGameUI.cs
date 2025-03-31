using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : BaseUI
{
    [SerializeField] private ExpBar expbar;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private SkillInventory skillInventory;
    [SerializeField] private Button pauseButton;
    [SerializeField] private DamageUI damageUI;
    [SerializeField] private HealthUI healthUI;

    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        // 초기화
        expbar.InitExpBar();
        gameTimer.InitTimer();
        skillInventory.InitSkillInventory();
        damageUI.InitDamageUI();
        healthUI.InitHealthBar();

        // 버튼 버튼
        pauseButton.onClick.AddListener(
            () => uiManager[UIType.Pause].ShowUI());
    }

    public override void ShowUI()
    {
        base.ShowUI();

        // 초기화 / 타이머 시작
        expbar.InitExpBar();
        gameTimer.StartTimer();
    }

    public override void HideUI()
    {
        base.HideUI();

        // 타이머 종료
        gameTimer.EndTimer();
    }

    public void OnDamagePopup(float damage, Vector3 pos)
    {
        damageUI.OnDamage(damage, pos);
    }

    public void OnHealthBar(Transform target, float maxHp, float hp)
    {
        healthUI.UpdateHealthBar(target, maxHp, hp);
    }
}