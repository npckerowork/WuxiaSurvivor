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

    public override void ShowUI()
    {
        base.ShowUI();
        Time.timeScale = 0;
    }
    public override void HideUI()
    {
        base.HideUI();
        Time.timeScale = 1;

        sfxController.PlayClip(SfxName.ButtonClick2);
    }

    private void OnOption()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);

        // Option UI 켜기
        uiManager[UIType.Option].ShowUI();
    }

    private void OnLobby()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        uiManager.fade.FadeOut(LobbyFadeOut);
    }

    private void LobbyFadeOut()
    {
        // 여기 메서드명이 애매해요@@

        HideUI();                           // Pause UI off
        uiManager[UIType.Ingame].HideUI();  // InGame UI off
        uiManager[UIType.Lobby].ShowUI();   // Lobby UI On

        SceneManager.LoadScene("00_Lobby"); // 씬 변경
    }


    private void QuitGame()
    {
        sfxController.PlayClip(SfxName.ButtonClick2);
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
