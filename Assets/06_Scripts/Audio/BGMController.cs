using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private AudioManager audioManager;
    private AudioSource audioSource;

    [Header("BGM Clips")]
    [SerializeField] private AudioClip[] clips;

    [Header("Fade In/Out")]
    [SerializeField] private float fadeInDuration;
    [SerializeField] private float fadeOutDuration;

    public void InitController(AudioManager audioManager)
    {
        this.audioManager = audioManager;
        transform.parent = audioManager.transform;

        audioSource = GetComponent<AudioSource>();

        StartBGM(BgmName.LobbyBGM);
    }

    private void StartBGM(BgmName bgm)
    {
        audioSource.clip = clips[(int)bgm];
        audioSource.volume = 0;
        audioSource.Play();

        float volume = audioManager.GetVolume(VolumeType.Bgm);
        audioSource.DOFade(volume, fadeInDuration);     
    }

    public void ChangeBGM(BgmName bgm)
    {
        audioSource.DOFade(0, fadeOutDuration).OnComplete(() => StartBGM(bgm));
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}