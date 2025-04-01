using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUI : BaseUI
{
    [Header("Lobby Data")]
    [SerializeField] private TextMeshProUGUI coinText;

    [Header("Button")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button optionButton;
    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        startButton.onClick.AddListener(OnStart);
        upgradeButton.onClick.AddListener(OnUpgrade);
        optionButton.onClick.AddListener(OnOption);

        ShowUI();

        DataManager.Instance.Coin.OnUpdateCoinAmountEvent += CoinUpdate;
    }

    public override void HideUI()
    {
        base.HideUI();                      // Lobby UI off

        uiManager[UIType.Ingame].ShowUI();  // InGame UI on

        SceneLoader.Instance.ChangeScene(SceneType.Main);
        //SceneManager.LoadScene("01_Main");  // 씬 변경
    }

    private void OnStart()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        uiManager.fade.FadeOut(HideUI);
        AudioManager.Instance.bgmController.ChangeBGM(BgmName.GameBGM); // 배경음 변경
    }

    private void OnUpgrade()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        uiManager[UIType.Upgrade].ShowUI();
    }

    private void OnOption()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        uiManager[UIType.Option].ShowUI();
    }

    public void CoinUpdate(long coin)
    {
        coinText.text = $"{coin}";
    }
}
