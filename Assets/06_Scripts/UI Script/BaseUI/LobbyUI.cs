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

        // 보유 코인 UI 업데이트
        DataManager.Instance.Coin.OnUpdateCoinAmountEvent += CoinUpdate;
    }

    public override void HideUI()
    {
        base.HideUI();                     

        uiManager[UIType.Ingame].ShowUI();  

        SceneLoader.Instance.ChangeScene(SceneType.Main);
    }

    /// <summary>
    /// 게임 시작 
    /// </summary>
    private void OnStart()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);

        uiManager.fade.FadeOut(HideUI);
        AudioManager.Instance.bgmController.ChangeBGM(BgmName.GameBGM);
    }

    /// <summary>
    /// Upgrade UI 켜기
    /// </summary>
    private void OnUpgrade()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);

        uiManager[UIType.Upgrade].ShowUI();
    }

    /// <summary>
    /// Option UI 켜기
    /// </summary>
    private void OnOption()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);

        uiManager[UIType.Option].ShowUI();
    }

    /// <summary>
    /// 코인 Text 업데이트
    /// </summary>
    public void CoinUpdate(long coin)
    {
        coinText.text = $"{coin}";
    }
}
