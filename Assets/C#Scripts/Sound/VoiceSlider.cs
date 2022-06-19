using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceSlider : MonoBehaviour
{
    /*音関連*/
    GameObject Find_SoundManager;
    AudioSource audioSource;


    void Start()
    {
            //スライダーのvalueをSoundManager.csのbgmVolに合わせる
            Slider slider = this.gameObject.GetComponentInChildren<Slider>();
            slider.value = VoiceManager.VoiceVol;

            //SoundManagerオブジェクト、オーディオソース取得
            Find_SoundManager = GameObject.Find("VoiceManager");
            audioSource = Find_SoundManager.GetComponent<AudioSource>();

            //オーディオソースの音量と、SoundManager.csのbgmVolを合わせる
            audioSource.volume = VoiceManager.VoiceVol;

            //スライダーを動かすと、SoundManagerのオーディオソースのVolumeと同期させる
            slider.onValueChanged.AddListener((float value) =>
            {
                if (VoiceManager.VoiceOnOff == true)
                {
                    audioSource.volume = value;
                    VoiceManager.VoiceVol = audioSource.volume;
                    PlayerPrefs.SetFloat("VOICE", VoiceManager.VoiceVol);
                    PlayerPrefs.Save();
                }
            });
      
    }
}
