using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerController Player { get; private set; }
    public readonly List<GameObject> Enemies = new();

    public Coin GameCoin = new();

    private const int timeLimit = 300;      // 시간 제한
    public int currentTime { get; private set; }

    public Action OnTimeOver = delegate { };        // 시간제한 종료 후 실행 이벤트
    public Action OnTimeChanged = delegate { };     // 시간이 변할 때 실행 이벤트

    private bool isEnded;
    private readonly WaitForSeconds interval = new(0.2f);

    protected override void Initialize()
    {
        SetDontDestroyOnLoad();

        Player = FindAnyObjectByType<PlayerController>();
        GameCoin = new();

        Application.wantsToQuit += OnWantsToQuit;
        StartCoroutine(Spawning());
    }

    private bool OnWantsToQuit()
    {
        DataManager.Instance.SaveData(); // 저장 요청
#if UNITY_EDITOR
        Debug.Log("게임 종료 전에 저장 완료!");
#endif
        return true; // false면 종료 취소됨
    }

    public IEnumerator StartTimer()
    {
        currentTime = 0;

        while (true)
        {
            yield return new WaitForSeconds(1f);
            currentTime++;
            OnTimeChanged?.Invoke();

            // 제한시간 종료
            if (currentTime >= timeLimit)
                OnTimeOver?.Invoke();
        }
    }

    private IEnumerator Spawning()
    {
        while (!isEnded)
        {
            GameObject enemy = null;
            switch (currentTime)
            {
                default:
                    enemy = ResourceManager.Instance.Instantiate(Define.ENEMIES[0], null, Player.transform.position, Vector3.zero);
                    break;
            }

            Enemies.Add(enemy);

            yield return interval;
        }
    }
}