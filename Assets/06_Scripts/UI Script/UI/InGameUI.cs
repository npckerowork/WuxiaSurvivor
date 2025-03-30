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

    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        // 초기화
        expbar.InitExpBar();
        gameTimer.InitTimer();
        skillInventory.InitSkillInventory();

        // 버튼 버튼
        pauseButton.onClick.AddListener(OnPause);
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

    private void OnPause()
    {
        uiManager[UIType.Pause].ShowUI();
    }
}