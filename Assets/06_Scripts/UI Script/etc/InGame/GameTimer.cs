using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private int timeSecond;
    [SerializeField] private TextMeshProUGUI timeText;

    private IEnumerator timerCoroutine;

    /// <summary>
    /// 초기화
    /// </summary>
    public void InitTimer()
    {
        timerCoroutine = GameManager.Instance.StartTimer();
        GameManager.Instance.OnTimeChanged += UpdateTime;
    }

    /// <summary>
    /// 타이머 시작
    /// </summary>
    public void StartTimer()
    {
        StartCoroutine(timerCoroutine);
    }

    /// <summary>
    /// 타이머 종료
    /// </summary>
    public void EndTimer()
    {
        StopCoroutine(timerCoroutine);
    }

    /// <summary>
    /// 타이머 텍스트
    /// </summary>
    private void UpdateTime()
    {
        int timeSecond = GameManager.Instance.currentTime;

        int min = timeSecond / 60;
        int sec = timeSecond % 60;
        timeText.text = $"{min:D2} : {sec:D2}";
    }
}
