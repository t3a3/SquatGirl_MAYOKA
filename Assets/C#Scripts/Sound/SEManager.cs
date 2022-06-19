using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] List<SESoundData> seSoundDatas;


    public float masterVolume = 1;
    public float seMasterVolume = 1;


    public static SEManager Instance { get; private set; }
    public static float SeVol = 0.8f;
    public static bool SEOnOff = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //SE§Œä//
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.clip = data.audioClip;
        seAudioSource.volume = data.volume * seMasterVolume * SeVol;
        seAudioSource.PlayOneShot(data.audioClip);
    }

    public void StopSE(SESoundData.SE se)
    {
       // seAudioSource.loop = false;
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.clip = data.audioClip;
        seAudioSource.Stop();

    }
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Click,
        Back,
        positionOneOk,
        CosClick,
        AccClick,
        Sqwat,
        OnOFF,
        Skip,
        positionOK,
        PositionOK_All,
        release,
        TimeStop,
        Vibe,
        MuneTouch,
        ManTouch,
        VibeTouch// ‚±‚ê‚ªƒ‰ƒxƒ‹‚É‚È‚é
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}
