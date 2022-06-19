using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SEVolumeSlider : MonoBehaviour
{
    /*音関連*/
    GameObject Find_SoundManager;
    AudioSource audioSource;


    void Start()
    {
        //スライダーのvalueをSoundManager.csのbgmVolに合わせる
        Slider slider = this.gameObject.GetComponentInChildren<Slider>();
        slider.value = SEManager.SeVol;

        //SoundManagerオブジェクト、オーディオソース取得
        Find_SoundManager = GameObject.Find("SEManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();

        //オーディオソースの音量と、SoundManager.csのSeVolを合わせる
        audioSource.volume = SEManager.SeVol;

        //スライダーを動かすと、SoundManagerのオーディオソースのVolumeと同期させる
        slider.onValueChanged.AddListener((float value) => {
            
            if (SEManager.SEOnOff==true)
            {
                audioSource.volume = value;
                SEManager.SeVol = audioSource.volume;
                PlayerPrefs.SetFloat("SE", SEManager.SeVol);
                PlayerPrefs.Save();

            }
        });
    }
}
