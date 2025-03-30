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
    // 사용 가능한 상태인지
    private bool usable = true;
    public bool Usabel
    {
        get {  return usable; }
        set { usable = value; }
    }

    private void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        
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
        gameObject.SetActive(true);
        startPosition = startPos;
        transform.position = startPosition;
        rigid.velocity = dir * speed;
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
        // 지금은 레이어로 구분하는지 태그로 구분하는지도 모르니 잠시 비워둡니다
        OffProjectile();
    }

    private void OffProjectile()
    {
        usable = false;
        rigid.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
