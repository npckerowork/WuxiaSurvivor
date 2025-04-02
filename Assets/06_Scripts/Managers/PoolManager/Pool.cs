using UnityEngine;
using UnityEngine.Pool;

public class Pool
{
    private readonly GameObject original;
    private readonly Transform transform;
    private readonly IObjectPool<GameObject> objectPool;

    public Pool(string key, Transform parent)
    {
        string path = $"{Define.PATH_OBJECT}/{key}";
        original = Resources.Load<GameObject>(path);

        transform = new GameObject(key).transform;
        transform.SetParent(parent);

        objectPool = new ObjectPool<GameObject>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    public GameObject Get()
    {
        return objectPool.Get();
    }

    public void Release(Poolable poolable)
    {
        objectPool.Release(poolable.gameObject);
    }

    private GameObject CreateFunc()
    {
        return ResourceManager.Instance.Instantiate(original);
    }

    private void ActionOnGet(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void ActionOnRelease(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform);
        gameObject.SetActive(false);
    }

    private void ActionOnDestroy(GameObject gameObject)
    {
        Object.Destroy(gameObject);
    }
}