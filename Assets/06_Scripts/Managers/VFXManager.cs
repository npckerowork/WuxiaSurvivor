using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    protected override void Initialize()
    {
        SetDontDestroyOnLoad();
    }

    public void PlayVFX(EffectType type, Vector2 position, Vector3 rotation = default)
    {
        string key = $"Effect_{type.ToString()}";

        ResourceManager.Instance.Instantiate(key, transform, position, rotation);
    }
}
