using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkController : MonoBehaviour
{
    private Tilemap tilemap;
    public int ChunkSize { get; set; } //타일맵 사이즈

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void GenerateChunk(TileData[] tiles)
    {
        tilemap.ClearAllTiles();

        for (int y = 0; y < ChunkSize; y++)
        {
            for (int x = 0; x < ChunkSize; x++)
            {
                //타일 랜덤배치
                TileBase tile = GetRandomTile(tiles); 
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    private TileBase GetRandomTile(TileData[] tiles)
    {
        float totalWeight = 0f;
        foreach (var td in tiles)
        {
            totalWeight += td.Weight; 
        }

        float randomPoint = Random.Range(0f, totalWeight);
        float current = 0f;

        foreach (var td in tiles)
        {
            current += td.Weight;
            if (randomPoint <= current)
            {
                return td.Tile;
            }
        }
        return tiles[0].Tile;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Camera"))
        {
            Vector2 camPos = collision.transform.position;
            //Tilemap의 기준 위치(Pivot)을 중간으로 이동
            Vector2 centerPos = (Vector2)transform.position + Vector2.one * (ChunkSize * 0.5f);

            Vector2 direction = camPos - centerPos;
            Vector2 moveDir = direction.normalized;

            //카메라와 타일맵  x축과 y축 거리의 절댓값으로 수평이동인지 수동이동인지 판단
            bool isHorizontal = Mathf.Abs(direction.x) > Mathf.Abs(direction.y); 

            if (isHorizontal)
            {
                //수평이동
                transform.Translate(Vector3.right * Mathf.Sign(moveDir.x) * ChunkSize * 2);
            }
            else
            {
                //수직이동
                transform.Translate(Vector3.up * Mathf.Sign(moveDir.y) * ChunkSize * 2);
            }
        }
    }
}
