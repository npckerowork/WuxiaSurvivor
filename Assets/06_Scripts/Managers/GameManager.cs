using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerController Player { get; private set; }

    public Coin GameCoin = new();

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
}