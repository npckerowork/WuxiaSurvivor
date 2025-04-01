using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image fadeImage;
    private float duration = 1.5f;

    public void InitFade()
    {
        fadeImage = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    public void FadeOut(Action endAction = null)
    {
        fadeImage.color = new Color(0, 0, 0, 0);
        gameObject.SetActive(true);

        fadeImage.DOFade(1, duration).OnComplete(() =>
        {
            endAction?.Invoke();
            FadeIn();
        }).SetUpdate(true);

    }

    public void FadeIn()
    {
        fadeImage.DOFade(0, duration).OnComplete(
            () => gameObject.SetActive(false)).SetUpdate(true);
    }
}
