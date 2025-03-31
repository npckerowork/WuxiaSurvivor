using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("아이템")]
    [SerializeField] private float itemSpawnRate = 0.4f; //아이템이 생성될 확률
    [SerializeField] private float itemRespawnCooldown = 60f; //아이템이 재생성되는 쿨다운(초)
    [SerializeField] private Spawnable[] spawnItemsPrefabs;

    private ChunkController chunkController;

    private void Start()
    {
        chunkController = GetComponent<ChunkController>();

        InvokeRepeating(nameof(TrySpawnItem), 0, itemRespawnCooldown); //일정시간 마다 아이템 생성
    }

    private void TrySpawnItem()
    {
        float rate = Random.value;
        if (rate <= itemSpawnRate)
        {
            SpawnItem(GetRandomSpawnPosition());
        }
    }

    private Vector2Int GetRandomSpawnPosition()
    {
        int max = chunkController.ChunkSize;
        int x = Random.Range(0, max);
        int y = Random.Range(0, max);
        return new Vector2Int(x, y);
    }

    //가중치 기반 무작위 선택 방식
    private Spawnable GetRandomWeightedObject(Spawnable[] spawnables)
    {
        int totalWeight = 0;

        foreach (var obj in spawnables)
        {
            totalWeight += obj.Weight;
        }

        float randomPoint = Random.Range(0f, totalWeight);
        float current = 0f;

        foreach (var obj in spawnables)
        {
            current += obj.Weight;
            if (randomPoint <= current)
            {
                return obj;
            }
        }
        return spawnables[0];
    }

    private void SpawnItem(Vector2Int pos)
    {
        var spawnItem = GetRandomWeightedObject(spawnItemsPrefabs);
        Spawn(spawnItem, pos);
    }

    private void Spawn(Spawnable spawnObject, Vector2Int pos)
    {
        spawnObject.Spawn(pos, transform);
    }
}
