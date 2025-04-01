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
        quitButton.onClick.AddListener(QuitGame);
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

        sfxController.PlayClip(SfxName.ButtonClick2);
    }

    /// <summary>
    /// Option UI 켜기
    /// </summary>
    private void OnOption()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);

        // Option UI 켜기
        uiManager[UIType.Option].ShowUI();
    }

    /// <summary>
    /// Lobby로 돌아가기 
    /// </summary>
    private void OnLobby()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        uiManager.fade.FadeOut(EndFadeOut);
        AudioManager.Instance.bgmController.ChangeBGM(BgmName.LobbyBGM);// 배경음 변경
    }

    /// <summary>
    /// Lobby로 돌아가기 FadeOut 종료후
    /// </summary>
    private void EndFadeOut()
    {
        HideUI();                           // Pause UI off
        uiManager[UIType.Ingame].HideUI();  // InGame UI off
        uiManager[UIType.Lobby].ShowUI();   // Lobby UI On

        SceneLoader.Instance.ChangeScene(SceneType.Lobby);
    }

    /// <summary>
    /// 게임 종료
    /// </summary>
    private void QuitGame()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
