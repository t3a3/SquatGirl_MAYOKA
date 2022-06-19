using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_OnOffButton : MonoBehaviour
{

    AudioSource audioSource;
    public bool imageBGMOnOff;

    /*画像の変数類*/
    Image image;
    public Sprite[] ButtonSprite;

    /// <summary>
    /// BGMオンオフボタンの画像を変える。一時停止が[0]、再生が[1]
    /// </summary>
    void OnEnable()
    {
        imageBGMOnOff = SoundManager.BgmOnOff;
        image = this.gameObject.GetComponent<Image>();
        if (imageBGMOnOff == true)
        {
            image.sprite = ButtonSprite[1];
        }
        else if (imageBGMOnOff == false)
        {
            image.sprite = ButtonSprite[0];
        }
    }

    public void OnClick()
    {
        if (imageBGMOnOff == true)
        {
            PauseBgm();
        }
        else if (imageBGMOnOff == false)
        {
            PlayBgm();
        }
    }

    /// <summary>
    /// BGMを鳴らす
    /// </summary>
    public void PlayBgm()
    {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audioSource.Play();
        image.sprite = ButtonSprite[1];
        imageBGMOnOff = true;
        SoundManager.BgmOnOff = true;      
    }

    /// <summary>
    /// BGMを止める
    /// </summary>
    public void PauseBgm()
    {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        audioSource.Pause();
        image.sprite = ButtonSprite[0];
        imageBGMOnOff = false;
        SoundManager.BgmOnOff = false;
    }

}
