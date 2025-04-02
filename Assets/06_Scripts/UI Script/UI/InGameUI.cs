using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public enum GameUIType
{
    ExpBar,
    Timer,
    Inventory,
    Damage,
    Health
}

public class InGameUI : BaseUI
{
    [Header("Game UI")]
    [SerializeField] private ExpBar expbar;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private SkillInventory skillInventory;
    [SerializeField] private DamageUI damageUI;
    [SerializeField] private HealthUI healthUI;

    [Header("Button")]
    [SerializeField] private Button pauseButton;

    // get
    public ExpBar Expbar => expbar;
    public DamageUI DamageUI => damageUI;
    public HealthUI HealthUI => healthUI;

    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        // 초기화
        expbar.InitUI();
        gameTimer.InitUI();
        skillInventory.InitUI();
        damageUI.InitUI();
        healthUI.InitUI();

        pauseButton.onClick.AddListener(OnPause);
    }

    /// <summary>
    /// Pause UI 켜기
    /// </summary>
    private void OnPause()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        uiManager[UIType.Pause].ShowUI();
    }
}