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
        // ƒƒOƒCƒ“Šeí‰¹—Ê‚ğæ“¾
        SoundManager.bgmVol = PlayerPrefs.GetFloat("BGM", 0.4f);
        SEManager.SeVol = PlayerPrefs.GetFloat("SE", 0.8f);
        VoiceManager.VoiceVol = PlayerPrefs.GetFloat("VOICE", 1.0f);

        // AudioSource‚ğæ“¾
        Find_SoundManager = GameObject.Find("SoundManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();

        bgmOnOff = SoundManager.BgmOnOff;

        // BGMÄ¶
        if (bgmOnOff == true)
        {
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Home);
            audioSource.volume = SoundManager.bgmVol;
        }
        // BGM‚È‚µ
        else if (bgmOnOff == false)
        {
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.Home);
            audioSource.volume = SoundManager.bgmVol;
        }
    }
}
