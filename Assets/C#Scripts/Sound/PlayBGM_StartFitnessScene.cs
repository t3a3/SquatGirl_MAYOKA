using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM_StartFitnessScene : MonoBehaviour
{
    public bool OnOff;
    void Start()
    {
        OnOff = SoundManager.BgmOnOff;
        if (OnOff == true)
        {
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Fitness);
           
        }
        else 
        {
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.Fitness);
        }
    }
}
