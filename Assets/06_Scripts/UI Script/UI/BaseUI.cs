using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;
    protected SFXController sfxController;

    public virtual void InitUI(UIManager uiManager)
    {
        this.uiManager = uiManager;
        sfxController = AudioManager.Instance.sfxController;
    }

    public virtual void ShowUI()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideUI()
    {
        gameObject.SetActive(false);
    }
}
