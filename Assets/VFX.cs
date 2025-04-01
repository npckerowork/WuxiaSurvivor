using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : Poolable
{
    private ParticleSystem particleSystem;
    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();

        var main = particleSystem.main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        ResourceManager.Instance.Destroy(gameObject);
    }

    private void OnEnable()
    {
        particleSystem.Play();
    }
}
