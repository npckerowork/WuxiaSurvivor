using UnityEngine;

public class MagnetAttract : MonoBehaviour
{
    [SerializeField] private float attractDuration; //목표까지 도달하는데 걸리는 시간
    private Transform player;

    [HideInInspector]
    public bool IsActiveMagnet = false; //자기장이 활성화 되어있는지

    private void Start()
    {
        player = GameManager.Instance.Player.transform;
    }

    private void OnDisable()
    {
        IsActiveMagnet = false;
    }

    private void Update()
    {
        if (player == null || !IsActiveMagnet) return;
        //자기장 처리
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, attractDuration);
    }
}
