using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM_StartHomeScene : MonoBehaviour
{
    GameObject Find_SoundManager;
    AudioSource audioSource;
    public bool bgmOnOff;


    void Start()
    {
        // ログイン時各種音量を取得
        SoundManager.bgmVol = PlayerPrefs.GetFloat("BGM", 0.4f);
        SEManager.SeVol = PlayerPrefs.GetFloat("SE", 0.8f);
        VoiceManager.VoiceVol = PlayerPrefs.GetFloat("VOICE", 1.0f);

        // AudioSourceを取得
        Find_SoundManager = GameObject.Find("SoundManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();

        bgmOnOff = SoundManager.BgmOnOff;

        // BGM再生
        if (bgmOnOff == true)
        {
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Home);
            audioSource.volume = SoundManager.bgmVol;
        }
        // BGMなし
        else if (bgmOnOff == false)
        {
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.Home);
            audioSource.volume = SoundManager.bgmVol;
        }
    }
}
