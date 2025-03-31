using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void InitUI(UIManager uiManager)
    {
        this.uiManager = uiManager;
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
