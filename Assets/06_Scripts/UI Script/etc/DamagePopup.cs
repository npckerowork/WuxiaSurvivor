using Assets.PixelFantasy.PixelHeroes.Common.Scripts.UI;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DamagePopup : MonoBehaviour
{
    private DamageUI ui;
    private TextMeshPro damageText;
    private Color defaultTextColor;


    [SerializeField] private float moveYDistance;   // 위로 올라가는 거리
    [SerializeField] private float fadeDuration;    // Fade 시간

    public void InitPopup(DamageUI ui)
    {
        this.ui = ui;
        damageText = GetComponent<TextMeshPro>();

        defaultTextColor = damageText.color;
    }


    public void OnDamage(float damage, Transform pos)
    {
        // 활성화
        gameObject.SetActive(true);

        // 위치 이동
        transform.position = pos.position + new Vector3(0,0, 1);
        
        // 텍스트 / 컬러 변경
        damageText.text = damage.ToString("#.#");
        damageText.color = defaultTextColor;

        // 데미지 팝업 애니메이션
        // 위로 올라가면서 Fade 
        // Fade 종료 -> ReturnDamagePopup 호출 
        transform.DOMoveY(transform.position.y + moveYDistance, fadeDuration).SetEase(Ease.OutCubic);
        damageText.DOFade(0, fadeDuration).SetEase(Ease.Linear)
            .OnComplete(ReturnDamagePopup);
    }

    private void ReturnDamagePopup()
    {
        ui.ReturnPopup(this);
        gameObject.SetActive(false);
    }
}