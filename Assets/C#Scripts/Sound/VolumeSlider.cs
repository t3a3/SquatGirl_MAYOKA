using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    /*音関連*/
    GameObject Find_SoundManager;
    AudioSource audioSource;


    void Start()
    {
        
        //SoundManagerオブジェクト、オーディオソース取得
        Find_SoundManager = GameObject.Find("SoundManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();

        //スライダーのvalueをSoundManager.csのbgmVolに合わせる
        Slider slider = this.gameObject.GetComponentInChildren<Slider>();
        slider.value = SoundManager.bgmVol;


        //オーディオソースの音量と、SoundManager.csのbgmVolを合わせる
        audioSource.volume = SoundManager.bgmVol;
     
        //スライダーを動かすと、SoundManagerのオーディオソースのVolumeと同期させる
        slider.onValueChanged.AddListener((float value) => {
            audioSource.volume = value;
            SoundManager.bgmVol = audioSource.volume;
            PlayerPrefs.SetFloat("BGM", SoundManager.bgmVol);
            PlayerPrefs.Save();
        });
    }
}
