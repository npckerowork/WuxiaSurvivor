using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SFXController : MonoBehaviour
{
    // 효과음 범위
    [SerializeField] private float hearingRange = 10;

    private AudioManager audioManager;
    private AudioSource audioSource;
    private AudioListener audioListener;

    private Dictionary<AudioClip, AudioSource> audioSources;
    private SfxName[] hitSfxNames;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip[] clips;
    public void InitController(AudioManager audioManager)
    {
        this.audioManager = audioManager;
        transform.parent = audioManager.transform;

        audioSource = GetComponent<AudioSource>();
        audioListener = FindObjectOfType<AudioListener>();

        audioSources = new Dictionary<AudioClip, AudioSource>();

        for(int i = 0; i < Enum.GetValues(typeof(SfxName)).Length; i++)
        {
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(clips[i], newAudioSource);

            newAudioSource.clip = clips[i];
            newAudioSource.playOnAwake = false;
        }

        hitSfxNames = new SfxName[]
        { SfxName.Fight1, SfxName.Fight2, SfxName.Fight3, };
    }

    /// <summary>
    /// 효과음 실행
    /// </summary>
    /// <param name="clipName">sfx clip enum</param>
    /// <param name="sfxPosition">실행 위치</param>
    public void PlayClip(SfxName clipName, Vector2 sfxPosition = default)
    {
        AudioClip clip = clips[(int)clipName];

        // null 예외처리
        if (clip == null)
            return;

        //  null 예외처리
        if (audioListener == null)
            audioListener = FindObjectOfType<AudioListener>();

        // 범위 밖
        float distance = Vector2.Distance(audioListener.transform.position, sfxPosition);
        if (distance >= hearingRange)
            return;

        // 예외처리
        if (!audioSources.TryGetValue(clip, out AudioSource audio))
            return;

        // 이미 재생중
        if (audio.isPlaying)
        {
            // 실행된지 0.15초를 넘지못함 -> 재생 X
            if (audio.time <= 0.15f)
                return;

            // 재생중인 클립 멈춤
            audio.Stop();
        }

        // 사운드 조절 / 클립 재생
        audio.volume = audioManager.GetVolume(VolumeType.Sfx);
        audio.Play();
    }

    public void RandomHitSFX(Vector2 sfxPosition = default)
    {
        int clipLength = hitSfxNames.Length;
        SfxName randomClip = hitSfxNames[Random.Range(0, clipLength)];
        PlayClip(randomClip, sfxPosition);
    }

    private void OnDrawGizmos()
    {
        if (audioListener == null)
            return;

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(audioListener.transform.position, hearingRange);
    }
}
