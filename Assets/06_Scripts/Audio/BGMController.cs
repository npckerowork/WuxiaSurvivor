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
    public void InitController(AudioManager audioManager)
    {
        this.audioManager = audioManager;
        transform.parent = audioManager.transform;

        audioSource = GetComponent<AudioSource>();

        InitBGM();
    }

    private void InitBGM()
    {
        audioSource.clip = clips[(int)BgmName.LobbyBGM];
        audioSource.volume = audioManager.GetVolume(VolumeType.Bgm);
        audioSource.Play();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void ChangeBGM(BgmName clipName)
    {
        audioSource.Stop();
        audioSource.clip = clips[(int)clipName];
        audioSource.Play();
    }

    private void FadeBGM()
    {
        
    }
}