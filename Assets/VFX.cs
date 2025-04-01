using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : Poolable
{
    private ParticleSystem[] particleSystem;
    private void Awake()
    {
        particleSystem = GetComponentsInChildren<ParticleSystem>();

        if (particleSystem == null)
            return;

        var main = particleSystem[0].main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        ResourceManager.Instance.Destroy(gameObject);
    }

    private void OnEnable()
    {
        foreach (var particleSystem in particleSystem)
        { 
            particleSystem.Play();
        }
    }
}
