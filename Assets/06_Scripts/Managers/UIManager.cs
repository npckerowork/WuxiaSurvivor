using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    Lobby,
    Upgrade,
    Option,
    Ingame,
    Pause
}


public class UIManager : Singleton<UIManager>
{
    public LobbyUI lobbyUI { get; private set; }
    public UpgradeUI upgradeUI { get; private set; }
    public OptionUI optionUI { get; private set; }
    public InGameUI inGameUI { get; private set; }
    public PauseUI pauseUI { get; private set; }

    private BaseUI[] uis;

    public BaseUI this[UIType type] => uis[(int)type];

    protected override void Initialize()
    {
        // DontDestroy 설정
        SetDontDestroyOnLoad();

        // UI 생성
        ResourceManager.Instance.Instantiate(Define.CANVAS_KEY, this.transform, Vector2.zero, Vector2.zero);

        // 캐싱
        uis = new BaseUI[]
        {
            FindObjectOfType<LobbyUI>(true),
            FindObjectOfType<UpgradeUI>(true),
            FindObjectOfType<OptionUI>(true),
            FindObjectOfType<InGameUI>(true),
            FindObjectOfType<PauseUI>(true)
        };
         
        // 초기화
        InitUIs();
    }

    public void InitUIs()
    {
        foreach(BaseUI ui in uis)
        {
            ui?.InitUI(this);
        }
    }
}
