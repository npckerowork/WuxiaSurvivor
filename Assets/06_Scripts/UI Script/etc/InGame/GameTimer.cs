using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    public void InitUI()
    {
        GameManager.Instance.OnTimeChanged += UpdateTime;
    }

    /// <summary>
    /// 타이머 텍스트
    /// </summary>
    private void UpdateTime()
    {
        // TODO:
        // GameManager timeLimit로 변경하기
        int timeLimit = 300;

        int timeSecond = GameManager.Instance.currentTime;

        int time = timeLimit - timeSecond;

        int min = time / 60;
        int sec = time % 60;
        timeText.text = $"{min:D2} : {sec:D2}";
    }
}
