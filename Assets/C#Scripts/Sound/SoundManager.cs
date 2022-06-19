using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]  AudioSource bgmAudioSource;
    [SerializeField] List<BGMSoundData> bgmSoundDatas;



    public float masterVolume = 1;
    public float bgmMasterVolume = 1;



    public static SoundManager Instance { get; private set; }
    public static float bgmVol=0.4f;
    public static bool BgmOnOff = true;

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


    //BGM§Œä//
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume;
        bgmAudioSource.Play();
    }
    public void PauseBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.Pause();
    }
    public void StopBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.Stop();
    }
    
}


[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        Home,
        Fitness,
        Count, 
        TimeStop
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

