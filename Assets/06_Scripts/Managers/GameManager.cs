using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerController Player { get; private set; }
    public readonly List<EnemyController> Enemies = new();

    public Coin GameCoin = new();

    private const int timeLimit = 30;      // 시간 제한
    public int currentTime { get; private set; }

    public Action OnTimeOver = delegate { };        // 시간제한 종료 후 실행 이벤트
    public Action OnTimeChanged = delegate { };     // 시간이 변할 때 실행 이벤트

    // 게임 로직
    private const int timeUnit = timeLimit / 5;     // 난이도가 올라가는 단위
    private bool isEnded;                           // 게임 승리 조건 확인을 위한 bool값

    private readonly WaitForSeconds longInterval = new(1.0f);
    private readonly WaitForSeconds shortInterval = new(0.2f);

    protected override void Initialize()
    {
        SetDontDestroyOnLoad();

        GameCoin = new();

        Application.wantsToQuit += OnWantsToQuit;
        DOTween.SetTweensCapacity(200, 125);

        SceneLoader.Instance.AddAction(SceneType.Main, GameStart);
    }

    public void Clear()
    {
        Enemies.Clear();
        StopAllCoroutines();
    }

    private bool OnWantsToQuit()
    {
        DataManager.Instance.SaveData(); // 저장 요청
#if UNITY_EDITOR
        Debug.Log("게임 종료 전에 저장 완료!");
#endif
        return true; // false면 종료 취소됨
    }

    public void GameStart()
    {
        currentTime = 0;
        isEnded = false;

        Player = FindAnyObjectByType<PlayerController>();
        Player.OnDeath += GameDefeat;

        StartCoroutine(Spawning());
        StartCoroutine(StartTimer());

        SceneLoader.Instance.AddAction(SceneType.Lobby, Clear);
    }

    public void GameUpdate()
    {
        if (!isEnded) return;
        if (Enemies.Count > 0) return;

        GameVictory();
    }

    public void GameDefeat()
    {
        if (isEnded) return;

        foreach (var enemy in Enemies)
        {
            enemy.Body.DOFade(0.0f, 0.5f).OnComplete(() => Destroy(gameObject));
        }

        Clear();
        isEnded = true;

        UIManager.Instance.GetUI<ResultUI>().OnResult("게임 패배");
    }

    public void GameVictory()
    {
        StopAllCoroutines();
        UIManager.Instance.GetUI<ResultUI>().OnResult("게임 승리");
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
            {
                OnTimeOver?.Invoke();
                break;
            }
        }
    }

    public IEnumerator Spawning()
    {
        while (!isEnded)
        {
            int level = currentTime / timeUnit;
            if (level == 5)
            {
                isEnded = true;
            }

            if (Enemies.Count < 100)
            {
                Enemies.Add(GetRandomMonster(level).GetComponent<EnemyController>());
            }

            yield return level == 4 ? shortInterval : longInterval;
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

    private GameObject GetRandomMonster(int level)
    {
        Vector3 randomPosition = Player.transform.position + 12.0f * GetRandomDirection();
        randomPosition.x += UnityEngine.Random.Range(-2.0f, 2.0f);
        randomPosition.y += UnityEngine.Random.Range(-2.0f, 2.0f);

        switch (level)
        {
            case 1:
                return ResourceManager.Instance.Instantiate(Define.ENEMIES[1], null, randomPosition, Vector3.zero);
            case 2:
                if (UnityEngine.Random.Range(0, 3) == 0) return ResourceManager.Instance.Instantiate(Define.ENEMIES[2], null, randomPosition, Vector3.zero);
                else return ResourceManager.Instance.Instantiate(Define.ENEMIES[1], null, randomPosition, Vector3.zero);
            case 3:
                if (UnityEngine.Random.Range(0, 3) == 0) return ResourceManager.Instance.Instantiate(Define.ENEMIES[3], null, randomPosition, Vector3.zero);
                else return ResourceManager.Instance.Instantiate(Define.ENEMIES[2], null, randomPosition, Vector3.zero);
            case 4:
                if (UnityEngine.Random.Range(0, 3) == 0) return ResourceManager.Instance.Instantiate(Define.ENEMIES[3], null, randomPosition, Vector3.zero);
                else return ResourceManager.Instance.Instantiate(Define.ENEMIES[1], null, randomPosition, Vector3.zero);
            case 5:
                return ResourceManager.Instance.Instantiate(Define.ENEMIES[4], null, randomPosition, Vector3.zero);
            default:
                return ResourceManager.Instance.Instantiate(Define.ENEMIES[0], null, randomPosition, Vector3.zero);
        }
    }
}