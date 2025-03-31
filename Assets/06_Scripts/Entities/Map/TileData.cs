using UnityEngine.Tilemaps;

[System.Serializable]
public class TileData
{
    public TileBase Tile;
    public TileType TileType; //타일 타입
    public float Weight; //타일이 표시되는 가중치
}
