using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquatTimelineSignal : MonoBehaviour
{
    public static SquatTimelineSignal Instance;

    /*説明キャンバス*/
    private GameObject SquatCanvas;
    /*「ホームに戻る」キャンバス*/
    private GameObject EndCanvas;

    /*説明のキャンバスに表示させるテキストの変数類*/
    private Text squatTextExp1;
    private Text squatTextExp2;
    private Text squatTextExp3;
    private Text squatTextExp4;
    private Text SqwatName;

   
 
    /*IMERISのアニメーター*/
    public Animator girlAnimation;

    /*音関連*/
    private AudioSource Voice_audioSource;


    public static int changeInt;

    /// <summary>スクワットの説明が終わったかどうか。true=終了/// </summary>
    public static bool squatExpEndBool = false;
    public static bool SubmenuOnOFF = true;

    /// <summary>trueの時、各種エラーメッセージをOFFにする/// </summary>
    public static bool squatOrderText=true;

    private void Start()
    {
        changeInt = 0;
        SquatGameSystem.squatGameClear = false;
        squatExpEndBool = false;
        SubmenuOnOFF = true;
        squatOrderText = true;
    }

    /// <summary>
    /// ノーマルスクワットの説明時に使用するシグナル
    /// </summary>
    public void NormalSquatTimelineSignal()
    {
        SquatGameSystem.squatGameClear = true;
        squatTextExp1 = GameObject.Find("SqwatTextExp").GetComponent<Text>();
        squatTextExp2 = GameObject.Find("SqwatTextExp2").GetComponent<Text>();
        squatTextExp3 = GameObject.Find("SqwatTextExp3").GetComponent<Text>();
        squatTextExp4 = GameObject.Find("SqwatTextExp4").GetComponent<Text>();
        SqwatName = GameObject.Find("SqwatName").GetComponent<Text>();
        SqwatName.text = "ノーマルスクワット";
        if (VoiceManager.VoiceOnOff == false)
        {
            Voice_audioSource = GameObject.Find("VoiceManager").GetComponent<AudioSource>();
            Voice_audioSource.volume = 0;
        }
        if (changeInt == 0)
        {
            LeftHandFollowObj.GetLeftHand = false;
            RightHandFollowObj.GetRightHand = false;
            HeadFollowObj.GetHead = false;
            girlAnimation.SetBool("Squat_bool", true);
            girlAnimation.SetBool("Squat_bool", false);
            girlAnimation.SetBool("QuaterSq", true);
            girlAnimation.SetBool("QuaterSq", false);
            girlAnimation.SetBool("WideSq", true);
            girlAnimation.SetBool("WideSq", false);
            squatOrderText = true;
            EndCanvas = GameObject.Find("EndCanvas");
            EndCanvas.SetActive(false);
            SquatCanvas = GameObject.Find("SquatCanvas");

            squatTextExp1.text = "①足を肩幅くらいに開く";
            changeInt += 1;
        }
        else if (changeInt == 1)
        {
            squatTextExp2.text = "②手は床と平行になるよう前に出し胸を張る";
            changeInt += 1;
        }
        else if (changeInt == 2)
        {
            squatTextExp3.text = "③お尻を後ろへ突き出すように、股関節から折り曲げる";
            changeInt += 1;
        }
        else if (changeInt == 3)
        {
            squatTextExp4.text = "④太ももが床と平行になるまで下げ、ゆっくりと元の姿勢に戻す";
            changeInt +=1;
        }
        else if (changeInt == 4)
        {
            changeInt = 0;
            squatExpEndBool = true;
            squatOrderText = false;
            SquatGameSystem.squatGameClear = false;
        }

    }
    /// <summary>
    /// クオータースクワットの説明時に使用するシグナル
    /// </summary>
    public void QuaterSquatTimelineSignal()
    {
        SquatGameSystem.squatGameClear = true;
        squatTextExp1 = GameObject.Find("SqwatTextExp").GetComponent<Text>();
        squatTextExp2 = GameObject.Find("SqwatTextExp2").GetComponent<Text>();
        squatTextExp3 = GameObject.Find("SqwatTextExp3").GetComponent<Text>();
        squatTextExp4 = GameObject.Find("SqwatTextExp4").GetComponent<Text>();
        SqwatName = GameObject.Find("SqwatName").GetComponent<Text>();
        SqwatName.text = "クオータースクワット";

        if (VoiceManager.VoiceOnOff == false)
        {

            Voice_audioSource = GameObject.Find("VoiceManager").GetComponent<AudioSource>();
            Voice_audioSource.volume = 0;
        }
        if (changeInt == 0)
        {
            LeftHandFollowObj.GetLeftHand = false;
            RightHandFollowObj.GetRightHand = false;
            HeadFollowObj.GetHead = false;
            girlAnimation.SetBool("Squat_bool", true);
            girlAnimation.SetBool("Squat_bool", false);
            girlAnimation.SetBool("QuaterSq", true);
            girlAnimation.SetBool("QuaterSq", false);
            girlAnimation.SetBool("WideSq", true);
            girlAnimation.SetBool("WideSq", false);
            squatOrderText = true;
            EndCanvas = GameObject.Find("EndCanvas");
            EndCanvas.SetActive(false);
            SquatCanvas = GameObject.Find("SquatCanvas");

            squatTextExp1.text = "①…足を肩幅くらいに開く";
            changeInt += 1;
        }
        else if (changeInt == 1)
        {
            squatTextExp2.text = "②…手は床と平行になるよう前に出し胸を張る";

            changeInt += 1;
        }
        else if (changeInt == 2)
        {
            squatTextExp3.text = "③…お尻を後ろへ突き出すように、股関節から折り曲げる";

            changeInt += 1;
        }
        else if (changeInt == 3)
        {
            squatTextExp4.text = "④…膝の角度が45度になったら、ゆっくりと元の姿勢に戻す";
            changeInt += 1;
        }
        else if (changeInt == 4)
        {
            changeInt = 0;
            squatExpEndBool = true;
            squatOrderText = false;
            SquatGameSystem.squatGameClear = false;
        }
    }
    /// <summary>
    /// ワイドスクワットの説明時に使用するシグナル
    /// </summary>
    public void WideSquatTimelineSignal()
    {
        SquatGameSystem.squatGameClear = true;
        squatTextExp1 = GameObject.Find("SqwatTextExp").GetComponent<Text>();
        squatTextExp2 = GameObject.Find("SqwatTextExp2").GetComponent<Text>();
        squatTextExp3 = GameObject.Find("SqwatTextExp3").GetComponent<Text>();
        squatTextExp4 = GameObject.Find("SqwatTextExp4").GetComponent<Text>();
        SqwatName = GameObject.Find("SqwatName").GetComponent<Text>();
        SqwatName.text = "ワイドスクワット";

        if (VoiceManager.VoiceOnOff == false)
        {

            Voice_audioSource = GameObject.Find("VoiceManager").GetComponent<AudioSource>();
            Voice_audioSource.volume = 0;
        }
        if (changeInt == 0)
        {
            LeftHandFollowObj.GetLeftHand = false;
            RightHandFollowObj.GetRightHand = false;
            HeadFollowObj.GetHead = false;
            girlAnimation.SetBool("Squat_bool", true);
            girlAnimation.SetBool("Squat_bool", false);
            girlAnimation.SetBool("QuaterSq", true);
            girlAnimation.SetBool("QuaterSq", false);
            girlAnimation.SetBool("WideSq", true);
            girlAnimation.SetBool("WideSq", false);
            squatOrderText = true;
            EndCanvas = GameObject.Find("EndCanvas");
            EndCanvas.SetActive(false);
            SquatCanvas = GameObject.Find("SquatCanvas");

            squatTextExp1.text = "①…足を肩幅より大きく広げる";
            changeInt += 1;
        }
        else if (changeInt == 1)
        {
            squatTextExp2.text = "②…手は床と平行になるよう前に出し胸を張る";
            changeInt += 1;
        }
        else if (changeInt == 2)
        {
            squatTextExp3.text = "③…お尻を後ろへ突き出すように、股関節から折り曲げる";
            changeInt += 1;
        }
        else if (changeInt == 3)
        {
            squatTextExp4.text = "④…太ももが床と平行になるまで下げ、ゆっくりと元の姿勢に戻す";
            changeInt += 1;
        }
        else if (changeInt == 4)
        {
            changeInt = 0;
            squatExpEndBool = true;
            squatOrderText = false;
            SquatGameSystem.squatGameClear = false;
        }
    }


    public void reset()
    {
        SquatCanvas.SetActive(false);
        EndCanvas.SetActive(false);
        //LeftHandFollowObj.girlAnimationStopBool = false;
        //LeftHandFollowObj.girlAngryAnimationPlayBool = false;
        SubmenuOnOFF = false;
        SquatGameSystem.r18ModeBool = false;
        LeftHandFollowObj.girlFaceChangeBool = false;
        SquatGameSystem.squatGameClear = true;
        squatExpEndBool = false;
        changeInt = 0;
        //girlAnimation.SetBool("AngryFace", true);
        SquatPrepPosition.girlAnimation.SetBool("Squat_bool", false);
        SquatPrepPosition.girlAnimation.SetBool("QuaterSq", false);
        SquatPrepPosition.girlAnimation.SetBool("WideSq", false);
    }

    public void DefFace()
    {
     girlAnimation.SetBool("AngryFace", false); 
    }

    public void BackMenu()
    {
        EndCanvas.SetActive(true);
    }
    //void main_SceneLoaded(Scene nextScene, LoadSceneMode mode)
    //{
    //    TimeLineManager.Instance.EventStop();  
    //    SquatPrepPosition.girlAnimation.SetBool("Squat_bool", false);
    //    SquatPrepPosition.girlAnimation.SetBool("QuaterSq", false);
    //    SquatPrepPosition.girlAnimation.SetBool("WideSq", false);

    //}

    public void StopSignal()
    {
        SquatGameSystem.r18ModeBool = false;
        LeftHandFollowObj.girlFaceChangeBool = false;
        SquatTimelineSignal.squatExpEndBool = false;
    }

}
