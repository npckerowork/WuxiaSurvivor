using UnityEngine;

public class InfiniteMapController : MonoBehaviour
{
    public ChunkController[] Chunks;
    public TileData[] GroundTiles; 
    public int ChunkSize = 40; // 한 Chunk당 타일 수 (타일 크기 1 기준)

    private void Start()
    {
        // 좌표 오프셋 리스트
        Vector2[] offsets = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, -1),
            new Vector2(-1, -1),
            new Vector2(-1, 0),
        };

        //타일맵 배치
        for (int i = 0; i < Chunks.Length; i++)
        {
            Vector2 position = new Vector2(offsets[i].x * ChunkSize, offsets[i].y * ChunkSize);
            Chunks[i].transform.position = position;
            Chunks[i].ChunkSize = ChunkSize; //타일수 설정
            Chunks[i].GenerateChunk(GroundTiles); //타일 배치
        }
    }
}
