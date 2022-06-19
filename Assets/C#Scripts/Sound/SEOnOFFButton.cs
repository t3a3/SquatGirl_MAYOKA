using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEOnOFFButton : MonoBehaviour
{
    /*âÊëúÇÃïœêîóﬁ*/
    public bool imageSEOnOff;
    Image image;
    public Sprite[] ButtonSprite;

    /**/
    AudioSource audioSource;
    Slider SeSlider;
   
    void OnEnable()
    {
        imageSEOnOff = SEManager.SEOnOff;
        image = this.gameObject.GetComponent<Image>();
        if (imageSEOnOff == true)
        {
            image.sprite = ButtonSprite[1];
        }
        else if (imageSEOnOff == false)
        {
            image.sprite = ButtonSprite[0];
        }
    }


    public void OnClickSE()
    {
        if (imageSEOnOff == true)
        {   
            PauseSE();
        }
        else if (imageSEOnOff == false)
        {
            PlaySE();
        }
    }

    /// <summary>
    /// SEÇñ¬ÇÁÇ∑
    /// </summary>
    public void PlaySE()
    {
        SeSlider = GameObject.Find("SE_VolumeSlider").GetComponentInChildren<Slider>();
        audioSource = GameObject.Find("SEManager").GetComponent<AudioSource>();
        audioSource.volume = SeSlider.value;
        image.sprite = ButtonSprite[1];
        imageSEOnOff = true;
        SEManager.SEOnOff = true;
    }

    /// <summary>
    /// SEÇé~ÇﬂÇÈ
    /// </summary>
    public void PauseSE()
    {
        audioSource = GameObject.Find("SEManager").GetComponent<AudioSource>();
        audioSource.volume = 0;
        image.sprite = ButtonSprite[0];
        imageSEOnOff = false;
        SEManager.SEOnOff = false;
        //SoundManager.BgmOnOff = false;
    }
}
