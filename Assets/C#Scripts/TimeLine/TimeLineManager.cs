using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;



[RequireComponent(typeof(PlayableDirector))]
public class TimeLineManager : MonoBehaviour
{

    public static TimeLineManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ここにインスペクター上であらかじめ複数のセット
    [SerializeField] private TimelineAsset[] timelines;
    private PlayableDirector director;//PlayableDirector型の変数directorを宣言


    void Start()
    {
        //同じオブジェクトに付いているPlayableDirectorコンポーネントを取得
        director = this.GetComponent<PlayableDirector>();
    }


    //イベント再生メソッド ボタンに割り当てる
    /// <summary>
    /// TimeLineManagerにセットしたTimeLineを再生する
    /// </summary>
    /// <param name="id">再生したいTimeLineの番号</param>
    public void EventPlay(int id)
    {

        //ボタンの引数によってタイムラインを指定して再生
        switch (id)
        {
            case 1:
                // 再生したいタイムラインをPlayableDirectorに再生させる
                director.Play(timelines[0]);
                break;

            //ノーマルスクワット
            case 2:
                // 再生したいタイムラインをPlayableDirectorに再生させる
                director.Play(timelines[1]);
                break;

            //クオータースクワット
            case 3:
                // 再生したいタイムラインをPlayableDirectorに再生させる
                director.Play(timelines[2]);
                break;

            //ワイドスクワット
            case 4:
                // 再生したいタイムラインをPlayableDirectorに再生させる
                director.Play(timelines[3]);
                break;
            //終了後アニメーション
            case 5:
                director.Play(timelines[4]);
                break;
            case 6:
                director.Play(timelines[5]);
                break;
            case 7:
                director.Play(timelines[6]);
                break;
            case 8:
                director.Play(timelines[7]);
                break;
            case 9:
                director.Play(timelines[8]);
                break;
            //怒る
            case 10:
                director.Play(timelines[9]);
                break;
        }
    }
    public void EventStop()
    {
        director.Stop();
    }

    public void EventPause()
    {
        director.Pause();
    }
}
