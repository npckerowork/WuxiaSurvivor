using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : BaseUI
{
    [Header("Button")]
    [SerializeField] private Button backButton;

    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        backButton.onClick.AddListener(HideUI);
    }

    public override void HideUI()
    {
        base.HideUI();

        // Lobby UI
        //uiManager.lobbyUI.ShowUI();
        uiManager[UIType.Lobby].ShowUI();
    }
}
