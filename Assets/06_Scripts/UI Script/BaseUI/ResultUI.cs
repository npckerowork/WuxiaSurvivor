using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button backButton;

    public override void InitUI(UIManager uiManager)
    {
        base.InitUI(uiManager);

        backButton.onClick.AddListener(OnLobby);
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
    }

    public void OnResult(string gameoverText)
    {
        resultText.text = gameoverText;
        ShowUI();
    }

    private void OnLobby()
    {
        sfxController.PlayClip(SfxName.ButtonClick);
        uiManager.fade.FadeOut(EndFadeOut);
        AudioManager.Instance.bgmController.ChangeBGM(BgmName.LobbyBGM);
    }

    private void EndFadeOut()
    {
        HideUI();
        uiManager[UIType.Ingame].HideUI();
        uiManager[UIType.Lobby].ShowUI();

        SceneLoader.Instance.ChangeScene(SceneType.Lobby);
    }
}
