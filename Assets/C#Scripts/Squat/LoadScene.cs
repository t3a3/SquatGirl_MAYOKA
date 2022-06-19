using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    /*どのスクワットを選択したか判断する整数*/
    public static int selectSquat;


    /// <summary>
    /// ノーマルスクワットを選択。selectSquat = 1;
    /// </summary>
    public void onClick_NormalSquat()
    {
        //SceneManager.sceneLoaded += n_SceneLoaded;
        //SceneManager.LoadScene("FitnessRoom");
    }
    //void n_SceneLoaded(Scene nextScene, LoadSceneMode mode)
    //{
    //    selectSquat = 1;
    //    SquatGameSystem.squatGameClear = false;
    //    TimeLineManager.Instance.EventPlay(2);
    //}


    /// <summary>
    /// クオータースクワットを選択。selectSquat = 2;
    /// </summary>
    public void onClick_QuaterSquat()
    {
        SceneManager.sceneLoaded += q_SceneLoaded;
        SceneManager.LoadScene("FitnessRoom");
    }
    void q_SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        selectSquat = 2;
        SquatGameSystem.squatGameClear = false;
        TimeLineManager.Instance.EventPlay(3);
    }


    /// <summary>
    /// ワイドスクワットを選択。selectSquat = 3;
    /// </summary>
    public void onClick_WideSquat()
    {
        SceneManager.sceneLoaded += w_SceneLoaded;
        SceneManager.LoadScene("FitnessRoom");
    }
    void w_SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        selectSquat = 3;
        SquatGameSystem.squatGameClear = false;
        TimeLineManager.Instance.EventPlay(4);
    }
}
