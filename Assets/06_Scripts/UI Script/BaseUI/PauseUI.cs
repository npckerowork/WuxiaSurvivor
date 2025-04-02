using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : BaseUI
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button lobbyButton;
    [SerializeField] private Button quitButton;

    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        backButton.onClick.AddListener(HideUI);
        optionButton.onClick.AddListener(OnOption);
        lobbyButton.onClick.AddListener(OnLobby);
        quitButton.onClick.AddListener(() => Application.Quit());
    }

    /// <summary>
    /// Pause UI 켜기
    /// </summary>
    public override void ShowUI()
    {
        base.ShowUI();
        Time.timeScale = 0;
    }

    /// <summary>
    /// Pause UI 닫기
    /// </summary>
    public override void HideUI()
    {
        base.HideUI();
        Time.timeScale = 1;

        sfxController.PlayClip(SfxName.ButtonClick);
    }

    /// <summary>
    /// Option UI 켜기
    /// </summary>
    private void OnOption()
    {
        sfxController.PlayClip(SfxName.ButtonClick);

        uiManager[UIType.Option].ShowUI();
    }

    /// <summary>
    /// Lobby로 돌아가기 
    /// </summary>
    private void OnLobby()
    {
        sfxController.PlayClip(SfxName.ButtonClick);
        uiManager.fade.FadeOut(EndFadeOut);
        AudioManager.Instance.bgmController.ChangeBGM(BgmName.LobbyBGM);
    }

    /// <summary>
    /// Lobby로 돌아가기 FadeOut 종료후
    /// </summary>
    private void EndFadeOut()
    {
        HideUI();                          
        uiManager[UIType.Ingame].HideUI();
        uiManager[UIType.Lobby].ShowUI();   

        SceneLoader.Instance.ChangeScene(SceneType.Lobby);
    }
}
