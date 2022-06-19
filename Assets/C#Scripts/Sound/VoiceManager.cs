using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    [SerializeField] AudioSource voiceAudioSource;
    [SerializeField] List<VoiceSoundData> voiceSoundDatas;

    public float masterVolume = 1;
    public float voiceMasterVolume = 1;
    public static VoiceManager Instance { get; private set; }
    public static float VoiceVol = 1.0f;
    public static bool VoiceOnOff = true;

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

    //Voice§Œä//
    public void PlayVoice(VoiceSoundData.Voice voice)
    {
        VoiceSoundData data = voiceSoundDatas.Find(data => data.voice == voice);
        voiceAudioSource.volume = data.volume * voiceMasterVolume * VoiceVol;
        voiceAudioSource.PlayOneShot(data.audioClip);
    }

    public void PauseVoice(VoiceSoundData.Voice voice)
    {
        VoiceSoundData data = voiceSoundDatas.Find(data => data.voice == voice);
        voiceAudioSource.clip = data.audioClip;
        voiceAudioSource.Stop();
    }
}
[System.Serializable]
public class VoiceSoundData
{
    public enum Voice
    {
        count1,
        count2,
        count3,
        count4,
        count5,
        count6,
        count7,
        count8,
        count9,
        count10,
        Login,
        FirstLogin,
        sexy_count1,
        sexy_count2,
        sexy_count3,
        sexy_count4,
        sexy_count5,
        sexy_count6,
        sexy_count7,
        sexy_count8,
        sexy_count9,
        sexy_count10,
        SexyImerisVoice
    }

    public Voice voice;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}
