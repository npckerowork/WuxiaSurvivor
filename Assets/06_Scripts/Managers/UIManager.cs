using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private BaseUI[] uis;

    public BaseUI this[UIType type] => uis[(int)type];
    public Fade fade;

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
            FindObjectOfType<PauseUI>(true),
            FindObjectOfType<SkillSelectUI>(true)
        };
        fade = FindObjectOfType<Fade>(true); 

        // 초기화
        InitUIs();
    }

    public void InitUIs()
    {
        foreach(BaseUI ui in uis)
        {
            ui?.InitUI(this);
        }

        fade.InitFade();
    }

    public T GetUI<T>()
    {
        foreach(BaseUI ui in uis)
        {
            if (ui is T result)
                return (T)result;
        }

        return default;
    }
}
