using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineControl : MonoBehaviour
{
    public PlayableDirector playableDirector;
    //void Start()
    //{
    //    //�����Q�[���I�u�W�F�N�g�ɂ���PlayableDirector���擾����
    //    playableDirector = GetComponent<PlayableDirector>();
    //}

    //�Đ�����
    public void PlayTimeline()
    {
        playableDirector.Play();
    }

    //�ꎞ��~����
    public void PauseTimeline()
    {
        playableDirector.Pause();
    }

    //�ꎞ��~���ĊJ����
    public void ResumeTimeline()
    {
        playableDirector.Resume();
    }
}
