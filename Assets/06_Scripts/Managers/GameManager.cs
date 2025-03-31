public class GameManager : Singleton<GameManager>
{
    public PlayerController Player { get; private set; }

    public Coin GameCoin = new();

    protected override void Initialize()
    {
        SetDontDestroyOnLoad();

        Player = FindAnyObjectByType<PlayerController>();
        GameCoin = new();
    }

    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveData(); // 게임 종료 시 게임 저장
    }
}