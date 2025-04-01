using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 발사된 후에 사라질 범위
    [SerializeField] private float destroyDistance;
    private Rigidbody2D rigid;
    // 발사 지점
    private Vector2 startPosition;
    // 투사체가 날아가는 속도
    [SerializeField] private float speed;
    // 충돌한 몬스터에게 가할 데미지
    private float damage;
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    // 사용 가능한 상태인지
    private bool usable = true;
    public bool Usabel
    {
        get {  return usable; }
        set { usable = value; }
    }
    private LayerMask monsterLayer;
    public LayerMask MonsterLayer
    {
        get { return monsterLayer; }
        set { monsterLayer = value; }
    }

    public void Init()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!usable)
        {
            CheckDistance();
        }
    }

    // 발사할 때 호출
    public void SetProjectile(Vector2 startPos, Vector2 dir)
    {
        startPosition = startPos;
        transform.position = startPosition;
        rigid.velocity = dir * speed;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        usable = false;
    }

    public void CheckDistance()
    {
        if (Vector2.Distance(transform.position, startPosition) > destroyDistance)
        {
            OffProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적 캐릭터라면 데미지를 가하는 동작 수행
        if (collision.gameObject.layer == Mathf.Log(monsterLayer, 2) 
            && collision.TryGetComponent<EnemyStatHandler>(out EnemyStatHandler enemy))
        {
            enemy.Damage(damage);
            //OffProjectile();
        }
    }

    private void OffProjectile()
    {
        usable = true;
        rigid.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
