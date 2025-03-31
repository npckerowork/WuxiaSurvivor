using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    protected override void Initialize()
    {
        SetDontDestroyOnLoad();
    }

    public T Instantiate<T>(Transform parent, Vector2 localPosition, Vector3 localRotation) where T : BaseController
    {
        string key = typeof(T).Name;
        var gameObject = Instantiate(key, parent, localPosition, localRotation);
        var @base = gameObject.GetComponent<T>();

        @base.Birth();
        return @base;
    }

    public GameObject Instantiate(string key, Transform parent, Vector2 localPosition, Vector3 localRotation)
    {
        GameObject gameObject = PoolManager.Instance.Get(key);
        if (gameObject == null)
        {
            string path = $"{Define.PATH_OBJECT}/{key}";
            GameObject original = Resources.Load<GameObject>(path);
            if (original == null)
            {
                Debug.LogWarning($"Failed to Load<GameObject>({path})");
                return null;
            }

            gameObject = Instantiate(original);
        }

        gameObject.transform.SetParent(parent);
        gameObject.transform.SetLocalPositionAndRotation(localPosition, Quaternion.Euler(localRotation));

        return gameObject;
    }

    public GameObject Instantiate(GameObject original)
    {
        GameObject gameObject = Object.Instantiate(original);
        gameObject.name = original.name;

        return gameObject;
    }

    public void Destroy(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Poolable>(out var poolable))
        {
            PoolManager.Instance.Release(poolable);
            return;
        }

        Object.Destroy(gameObject);
    }
}