using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUI : BaseUI
{
    [Header("Lobby Data")]
    [SerializeField] private TextMeshProUGUI uiTitle;

    [Header("Button")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button optionButton;
    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        startButton.onClick.AddListener(HideUI);
        upgradeButton.onClick.AddListener(OnUpgrade);
        optionButton.onClick.AddListener(OnOption);

        ShowUI();
    }

    public override void HideUI()
    {
        base.HideUI();

        uiManager.inGameUI.ShowUI();
        SceneManager.LoadScene("01_Main");
    }

    private void OnUpgrade()
    {
        uiManager[UIType.Upgrade].ShowUI();
    }

    private void OnOption()
    {
        uiManager[UIType.Option].ShowUI();
    }
}
