using UnityEngine;

public class ItemBase : Poolable
{
    protected virtual void ApplyEffect()
    {
        ResourceManager.Instance.Destroy(gameObject); //풀로 돌려놓기

        AudioManager.Instance.sfxController.
            PlayClip(SfxName.GetItem, transform.position);

        VFXManager.Instance.PlayVFX(EffectType.SparkYellow, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyEffect();
        }
    }
}
