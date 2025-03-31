using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    // 효과음 범위
    [SerializeField] private float hearingRange = 10;

    private AudioManager audioManager;
    private AudioSource audioSource;
    private AudioListener audioListener;
    private HashSet<AudioClip> playingClips;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip[] clips;
    public void InitController(AudioManager audioManager)
    {
        this.audioManager = audioManager;
        transform.parent = audioManager.transform;

        audioSource = GetComponent<AudioSource>();
        audioListener = FindObjectOfType<AudioListener>();

        playingClips = new HashSet<AudioClip>();
    }

    /// <summary>
    /// 효과음 실행
    /// </summary>
    /// <param name="clipName">sfx clip enum</param>
    /// <param name="sfxPosition">실행 위치</param>
    public void PlayClip(SfxName clipName, Vector2 sfxPosition)
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

        // 이미 재생중인 클립 ( 중복 방지
        // TODO: 재생중인 클립일때 재생된지 n초가 지났다면 멈추고 다시 실행시키기
        if (playingClips.Contains(clip))
            return;
        
        // 클립 재생
        playingClips.Add(clip);
        audioSource.PlayOneShot(clip, audioManager.GetVolume(VolumeType.Sfx));

        // 클립 종료 코루틴
        StartCoroutine(EndPlayingStatus(clip));
    }

    private IEnumerator EndPlayingStatus(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
        playingClips.Remove(clip);
    }

    private void OnDrawGizmos()
    {
        if (audioListener == null)
            return;

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(audioListener.transform.position, hearingRange);
    }
}
