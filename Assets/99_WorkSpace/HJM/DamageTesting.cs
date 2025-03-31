using UnityEngine;

public class DamageTesting : MonoBehaviour
{
    SpriteRenderer sr;
    float topY;

    public float maxHP;
    public float hp;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        topY = sr.bounds.max.y;

        maxHP = 1000;
        hp = maxHP;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            float damage = Random.Range(1f, 100f);
            UIManager.Instance.GetUI<InGameUI>().OnDamagePopup
                (damage, TopPosition());

            hp -= damage;
            UIManager.Instance.GetUI<InGameUI>().OnHealthBar
                (transform, maxHP, hp);
        }


    }

    public Vector3 TopPosition()
    {
        return transform.position + new Vector3(0, (topY/2) + 0.1f, 0);
    }
}
