using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_OnOffButton : MonoBehaviour
{

    AudioSource audioSource;
    public bool imageBGMOnOff;

    /*�摜�̕ϐ���*/
    Image image;
    public Sprite[] ButtonSprite;

    /// <summary>
    /// BGM�I���I�t�{�^���̉摜��ς���B�ꎞ��~��[0]�A�Đ���[1]
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
    /// BGM��炷
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
    /// BGM���~�߂�
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
