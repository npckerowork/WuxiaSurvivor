using System.Collections;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    [SerializeField] private float magnetRange = 5f; //자기장 범위
    [SerializeField] private float magnetDuration = 3f; //자기장 지속시간 
    [SerializeField] private LayerMask attractItemLayer; //끌어올 아이템 레이어

    private bool isMagnetActive = false;

    public void ActivateMagnet()
    {
        if (!isMagnetActive)
        {
            StartCoroutine(IActivateMagnet());
        }
    }

    private IEnumerator IActivateMagnet()
    {
        isMagnetActive = true;
        float timer = magnetDuration;

        while (timer > 0f)
        {
            AttractItems();
            timer -= Time.deltaTime;
            yield return null;
        }

        isMagnetActive = false;
    }

    private void AttractItems()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, magnetRange, attractItemLayer);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<MagnetAttract>(out var item))
            {
                item.IsActiveMagnet = true;
            }
        }
    }
}
