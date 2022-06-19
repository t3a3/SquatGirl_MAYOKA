using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fitness_VolumeIcon : MonoBehaviour
{
    public bool OnOff;
    Image image;

    public Sprite[] ButtonSprite;
    //ˆê’â~‚ª[0]AÄ¶‚ª[1]

    void Start()
    {
        OnOff = SoundManager.BgmOnOff;
        image = this.gameObject.GetComponent<Image>();
        if (OnOff == true)
        {
            image.sprite = ButtonSprite[1];
        }
        else if (OnOff == false)
        {
            image.sprite = ButtonSprite[0];
        }
    }
}
