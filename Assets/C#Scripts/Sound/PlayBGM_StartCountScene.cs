using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM_StartCountScene : MonoBehaviour
{
    public bool OnOff;
    void Start()
    {
        OnOff = SoundManager.BgmOnOff;
        if (OnOff == true)
        {
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Count);

            //Debug.Log("true");
        }
        else if (OnOff == false)
        {
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.Count);
            //Debug.Log("false");
        }
    }
}
