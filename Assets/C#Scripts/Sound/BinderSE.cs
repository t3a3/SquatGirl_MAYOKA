using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinderSE : MonoBehaviour
{
    AudioSource audioSource;
    GameObject Find_SoundManager;
    private void Start()
    {
        Find_SoundManager = GameObject.Find("SEManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();
    }
    
    public void onClick()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.Click);
        }
    }
    public void onBack()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.Back);
        }
    }

    public void onCosClick()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.CosClick);
        }
    }
    public void onAccClick()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.AccClick);
        }
    }

    public void onSqwat()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.Sqwat);
        }
    }

    public void onOnOfft()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.OnOFF);
        }
    }
    public void onSkio()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.Skip);
        }
    }

    public void onSave()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.PositionOK_All);
        }
    }
}
