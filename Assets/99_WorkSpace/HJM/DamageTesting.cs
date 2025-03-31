using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTesting : MonoBehaviour
{
    SpriteRenderer sr;
    float topY;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        topY = sr.bounds.max.y;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            float damage = Random.Range(1f, 100f);
            UIManager.Instance.GetUI<InGameUI>().OnDamagePopup
                (damage, TopPosition());
        }
    }

    public Vector3 TopPosition()
    {
        return new Vector3
            (
            transform.position.x,
            topY + 0.1f,
            transform.position.z
            );
    }
}
