using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceOnOffButton : MonoBehaviour
{
    /**/
    public bool voiceOnOff;
    Image image;
    public Sprite[] ButtonSprite;

    /**/
    Slider VoiceSlider;
    AudioSource audioSource;

    /// <summary>
    ///  一時停止が[0]、再生が[1]
    /// </summary>
    void OnEnable()
    {
        voiceOnOff = VoiceManager.VoiceOnOff;
        image = this.gameObject.GetComponent<Image>();
        if (voiceOnOff == true)
        {
            image.sprite = ButtonSprite[1];
        }
        else if (voiceOnOff == false)
        {
            image.sprite = ButtonSprite[0];
        }
    }

    public void OnClick()
    {
        if (voiceOnOff == true)
        {
            PauseVoice();
        }
        else if (voiceOnOff == false)
        {
            PlayVoice();
        }
    }

    /// <summary>
    /// 声を鳴らす
    /// </summary>
    public void PlayVoice()
    {
        VoiceSlider = GameObject.Find("Voice_VolumeSlider").GetComponentInChildren<Slider>();
        audioSource = GameObject.Find("VoiceManager").GetComponent<AudioSource>();
        audioSource.volume = VoiceSlider.value;
        image.sprite = ButtonSprite[1];
        voiceOnOff = true;
        VoiceManager.VoiceOnOff = true;
    }

    /// <summary>
    /// 声を止める
    /// </summary>
    public void PauseVoice()
    {
        audioSource = GameObject.Find("VoiceManager").GetComponent<AudioSource>();
        audioSource.volume = 0;
        image.sprite = ButtonSprite[0];
        voiceOnOff = false;
        VoiceManager.VoiceOnOff = false;
    }
}
