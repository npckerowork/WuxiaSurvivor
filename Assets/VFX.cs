using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : Poolable
{
    private ParticleSystem[] vfxs;
    private void Awake()
    {
        vfxs = GetComponentsInChildren<ParticleSystem>();

        if (vfxs == null)
            return;

        var main = vfxs[0].main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        ResourceManager.Instance.Destroy(gameObject);
    }

    private void OnEnable()
    {
        foreach (var vfx in vfxs)
        {
            vfx.Play();
        }
    }
}
