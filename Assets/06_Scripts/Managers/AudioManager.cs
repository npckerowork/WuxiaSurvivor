using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AudioManager : Singleton<AudioManager>
{
    // volumes
    public float[] volumes { get; private set; }

    // bgm 
    public BGMController bgmController { get; private set; }

    // sfx
    public SFXController sfxController { get; private set; }

    public event Action onVolumeChanged;
    protected override void Initialize()
    {
        // DontDestroy 설정
        SetDontDestroyOnLoad();

        // volume 불러오기
        LoadVolumes();

        // BGM / SFX Controller 추가
        bgmController = FindObjectOfType<BGMController>();
        sfxController = FindObjectOfType<SFXController>();

        // Controller 초기화
        bgmController?.InitController(this);
        sfxController?.InitController(this);

        onVolumeChanged +=
            () => bgmController.ChangeVolume(GetVolume(VolumeType.Bgm));
    }

    #region 볼륨 조절
    /// <summary>
    /// Volume 불러오기
    /// </summary>
    private void LoadVolumes()
    {
        volumes = new float[3];
        volumes[(int)VolumeType.Master] = PlayerPrefs.GetFloat(Define.MASTER_VOLUME_KEY, 1f);
        volumes[(int)VolumeType.Bgm] = PlayerPrefs.GetFloat(Define.BGM_VOLUME_KEY, 0.5f);
        volumes[(int)VolumeType.Sfx] = PlayerPrefs.GetFloat(Define.SFX_VOLUME_KEY, 0.5f);
    }

    /// <summary>
    /// Volume 저장
    /// </summary>
    public void SaveVolumes()
    {
        PlayerPrefs.SetFloat(Define.MASTER_VOLUME_KEY, volumes[(int)VolumeType.Master]);
        PlayerPrefs.SetFloat(Define.BGM_VOLUME_KEY, volumes[(int)VolumeType.Bgm]);
        PlayerPrefs.SetFloat(Define.SFX_VOLUME_KEY, volumes[(int)VolumeType.Sfx]);
    }

    /// <summary>
    /// Volume 값 수정
    /// </summary>
    /// <param name="type">변경할 Volume Type</param>
    /// <param name="value">값</param>
    public void SetVolume(VolumeType type, float value)
    {
        volumes[(int)type] = value;
        onVolumeChanged();
    }

    /// <summary>
    /// Master volume을 포함시킨 Volume값 가져오기
    /// </summary>
    /// <param name="type">가지고올 volume Type</param>
    /// <returns>volume 값</returns>
    public float GetVolume(VolumeType type)
    {
        float volume = volumes[(int)VolumeType.Master];
        if(type != VolumeType.Master)
            volume *= volumes[(int)type];

        return volume;
    }
    #endregion
}
