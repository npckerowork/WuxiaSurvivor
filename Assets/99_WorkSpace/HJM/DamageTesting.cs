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

            UpgradeData data = DataManager.Instance.UpgradeData;

            //for (int i = 0; i < 4; i++)
            //{
            //    Debug.Log($"{(UpgradeType)i}/{data.upgradeLevels[i]}/{data.upgradePrice[i]}/{data.upgradeValues[i]}");
            //}
        }
    }
}
