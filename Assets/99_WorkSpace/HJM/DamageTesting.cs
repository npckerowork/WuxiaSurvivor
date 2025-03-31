using UnityEngine;

public class DamageTesting : MonoBehaviour
{
    private InGameUI gameUI;
    private SpriteRenderer sr;

    public float maxHP;
    public float hp;

    private void Start()
    {
        gameUI = UIManager.Instance.GetUI<InGameUI>();
        sr = GetComponent<SpriteRenderer>();

        maxHP = 1000;
        hp = maxHP;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            float damage = Random.Range(1f, 100f);
            gameUI.DamageUI.OnDamage(damage, transform);

            hp -= damage;
            gameUI.HealthUI.UpdateHealthBar(transform, maxHP, hp);

            DataManager.Instance.Coin.Add(10000);
        }
    }
}
