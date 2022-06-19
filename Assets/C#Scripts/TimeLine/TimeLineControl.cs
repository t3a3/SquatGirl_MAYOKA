using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineControl : MonoBehaviour
{
    public PlayableDirector playableDirector;
    //void Start()
    //{
    //    //同じゲームオブジェクトにあるPlayableDirectorを取得する
    //    playableDirector = GetComponent<PlayableDirector>();
    //}

    //再生する
    public void PlayTimeline()
    {
        playableDirector.Play();
    }

    //一時停止する
    public void PauseTimeline()
    {
        playableDirector.Pause();
    }

    //一時停止を再開する
    public void ResumeTimeline()
    {
        playableDirector.Resume();
    }
}
