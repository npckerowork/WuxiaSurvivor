using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public int Weight = 0; //확률 가중치

    public void Spawn(Vector2Int pos, Transform parent)
    {
        if (Weight == 0)
        {
            Debug.Log("가중치의 값을 설정해주세요");
            return;
        }
        GameObject go = ResourceManager.Instance.Instantiate(gameObject.name, parent, pos, Vector3.zero);
        go.transform.SetParent(null);
    }
}
