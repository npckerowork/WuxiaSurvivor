using UnityEngine;

public class Magnet : ItemBase
{
    private PlayerMagnet playerMagnet;

    private void Start()
    {
        playerMagnet = GameManager.Instance.Player.GetComponent<PlayerMagnet>();
    }

    protected override void ApplyEffect()
    {
        if (playerMagnet == null)
        {
            DebugLogger.LogError("플레이어에 PlayerMagnet스크립트가 없습니다.");
            return;
        }
        playerMagnet.ActivateMagnet();   //자기장 활성화
        base.ApplyEffect();
    }
}
