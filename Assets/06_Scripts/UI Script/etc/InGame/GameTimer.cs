using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private IEnumerator timerCoroutine;

    public void InitUI()
    {
        timerCoroutine = GameManager.Instance.StartTimer();
        GameManager.Instance.OnTimeChanged += UpdateTime;

        // 메인 씬 변경 이벤트 할당
        SceneLoader.Instance.AddAction(SceneType.Main, StartTimer);
        SceneLoader.Instance.AddAction(SceneType.Main, () => Debug.Log("메인씬 실행"));
        SceneLoader.Instance.AddAction(SceneType.Lobby, () => Debug.Log("로비씬 실행"));
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
        int timeLimit = 300;

        int timeSecond = GameManager.Instance.currentTime;

        int time = timeLimit - timeSecond;

        int min = time / 60;
        int sec = time % 60;
        timeText.text = $"{min:D2} : {sec:D2}";
    }
}
