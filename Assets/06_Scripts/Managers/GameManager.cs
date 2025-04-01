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
    private readonly WaitForSeconds interval = new(1.0f);

    protected override void Initialize()
    {
        SetDontDestroyOnLoad();

        Player = FindAnyObjectByType<PlayerController>();
        GameCoin = new();

        Application.wantsToQuit += OnWantsToQuit;
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

    public IEnumerator Spawning()
    {
        while (!isEnded)
        {
            if (Enemies.Count < 100)
            {
                GameObject enemy = GetRandomMonster();
                Enemies.Add(enemy);
            }

            yield return interval;
        }
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 direction = Vector3.zero;
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                direction = Vector3.right;
                break;
            case 1:
                direction = Vector3.left;
                break;
            case 2:
                direction = Vector3.down;
                break;
            case 3:
                direction = Vector3.up;
                break;
        }

        return direction;
    }

    private GameObject GetRandomMonster()
    {
        Vector3 randomPosition = Player.transform.position + 12.0f * GetRandomDirection();
        return ResourceManager.Instance.Instantiate(Define.ENEMIES[0], null, randomPosition, Vector3.zero);
    }
}