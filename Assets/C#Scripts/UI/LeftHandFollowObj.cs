using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LeftHandFollowObj : MonoBehaviour
{
    /*--*/
    public PlayableDirector playableDirector;
    public Animator girlFaceAnimation;


    /// <summary>
    /// 女の子の表情を変える真偽。true=表情が変わっている。
    /// </summary>
    public static bool girlFaceChangeBool;


    /*追従する左手オブジェクトと各座標の変数類*/
    GameObject leftHandAnchor;
    float leftHandPosition_X;
    float leftHandPosition_Y;
    float leftHandPosition_Z;
    public static bool GetLeftHand;

    /* 女の子に触れている時の変数類*/
    private float timeToTouch_L; //左手で女の子に触れている時の経過時間
   // private float changeFaceBaseTime = 2; //表情が変わるまでの時間。2秒。
    bool girlTouchSE = false; //タッチ時のSEを流すかどうかの真偽。


    /*スクワット強制終了イベント時の変数類 */
    public static float angryElapseTime; //スクワット強制終了イベントの経過時間


    /// <summary> 女の子が怒るまでのカウント。3でスクワット強制終了処理実行。</summary>
    public static int girlAngryCount;
    /// <summary> 女の子が怒りの表情かどうかの真偽。true=怒っている。</summary>
    public static bool girlAngryFace;
    /// <summary>現在進行しているイベントを止めるかどうかの真偽。true=イベントが止まっている状態。 </summary>
    public static bool girlAnimationStopBool;
    /// <summary> 女の子が怒り、スクワット強制終了イベントを流すかどうかの真偽。true=流している状態。 </summary>
    public static bool girlAngryAnimationPlayBool;


    //シングルトン
    public static LeftHandFollowObj instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        girlAnimationStopBool = false;
        girlAngryAnimationPlayBool = false;
        girlFaceChangeBool = false;
        girlAngryCount = 0;
        angryElapseTime = 0;
        GetLeftHand = false;
        leftHandAnchor = GameObject.Find("LeftHandAnchor");
        GetLeftHandPosition();
    }


    // Update is called once per frame
    void Update()
    {
        GetLeftHandPosition();

        // スクワットシーン中、女の子の胸、股を３回以上触ったら処理実行
        if (girlAngryCount >= 3&& !girlAnimationStopBool)
        {
            StartCoroutine("AngryEvent");
            girlAnimationStopBool = true;
        }
       
    }

    /// <summary> 左コントローラーにこのゲームオブジェクトを追従させる /// </summary>
    public void GetLeftHandPosition()
    {
        if (GetLeftHand == false)
        {
            leftHandAnchor = GameObject.Find("LeftHandAnchor");
            GetLeftHand = true;
        }
        leftHandPosition_X = leftHandAnchor.transform.position.x;
        leftHandPosition_Y = leftHandAnchor.transform.position.y;
        leftHandPosition_Z = leftHandAnchor.transform.position.z;
        this.gameObject.transform.position = new Vector3(leftHandPosition_X, leftHandPosition_Y, leftHandPosition_Z);
    }

    /// <summary> 怒りポイントが3超えた時のコルーチン /// </summary>
    /// <returns></returns>
    private IEnumerator AngryEvent()
    {
        girlFaceAnimation.SetBool("NagomiFace", false);
        girlFaceAnimation.SetBool("KomariFace", false);
        girlFaceAnimation.SetBool("AngryFace", false);
        SquatTimelineSignal.squatOrderText = true;
        yield return new WaitForSeconds(0.8f);
        TimeLineManager.Instance.EventStop();
        yield return new WaitForSeconds(1f);
        TimeLineManager.Instance.EventPlay(10);

    }

    /// <summary> 女の子の胸、股を触った時のコルーチン </summary>
    /// <returns></returns>
    private IEnumerator Touch_NO_R18Mode()
    {
        yield return new WaitForSeconds(2f);
        Komari();
        yield return new WaitForSeconds(2f);
        Angry();
    }
    /// <summary> 女の子の頭を触った時のコルーチン </summary>
    /// <returns></returns>
    private IEnumerator HeadTouch()
    {
        yield return new WaitForSeconds(2f);
        Nagomi();
    }


    // 困り顔の処理
    public void Komari()
    {
        if (LeftHandFollowObj.girlFaceChangeBool == false)
        {
            LeftHandFollowObj.girlFaceChangeBool = true;
            girlFaceAnimation.SetBool("KomariFace", true);
        }

    }

    // 怒り顔の処理
    public void Angry()
    {
        LeftHandFollowObj.girlFaceChangeBool = false;
        if (LeftHandFollowObj.girlFaceChangeBool == false)
        {
            girlFaceAnimation.SetBool("KomariFace", false);
            girlFaceAnimation.SetBool("AngryFace", true);
            LeftHandFollowObj.girlFaceChangeBool = true;
            if (SceneManager.GetActiveScene().name == "FitnessRoom") girlAngryFace = true;
        }
    }

    // 和み顔の処理
    public void Nagomi()
    {
        if (LeftHandFollowObj.girlFaceChangeBool == false)
        {
            LeftHandFollowObj.girlFaceChangeBool = true;
            girlFaceAnimation.SetBool("NagomiFace", true);
        }
    }

    /// <summary> 好感度スライダーをアップさせる処理 </summary>
    /// <param name="sliderP">スライダーの数値を増やす値</param>
    public void SliderUp(int sliderP)
    {
        timeToTouch_L -= Time.deltaTime;

        if (timeToTouch_L <= 0.0)
        {
            timeToTouch_L = 1.0f;
            Vibe.loveHeartSlider.value += sliderP;

        }
    }


    /// <summary>
    /// 女の子の頭、胸、股を触っている時の処理
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {

        //-----スクワットをクリアしていない＆怒りのカウントが３以下の時の処理-----//
        if (SquatGameSystem.squatGameClear == false && LeftHandFollowObj.girlAngryCount < 3)
        {

            // R18モードではない
            if (SquatGameSystem.r18ModeBool == false)
            {
                switch (other.gameObject.tag)
                {
                    // 股を触っている
                    case "CupM":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.ManTouch);
                            girlTouchSE = true;
                        }
                        StartCoroutine("Touch_NO_R18Mode");
                        break;
                    // 胸を触っている
                    case "CupO":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.MuneTouch);
                            girlTouchSE = true;
                        }
                        StartCoroutine("Touch_NO_R18Mode");
                        break;
                    // 頭を触っている
                    case "CupH":
                        StartCoroutine("HeadTouch");
                        break;
                }

            }

            // R18モード＆女の子の好感度が100以下の時の処理
            if (SquatGameSystem.r18ModeBool == true && Vibe.loveHeartSlider.value < 100)
            {
                switch (other.gameObject.tag)
                {
                    // 股を触っている
                    case "CupM":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.ManTouch);
                            girlTouchSE = true;
                            VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.SexyImerisVoice);
                        }
                        SliderUp(4);
                        break;
                    // 胸を触っている
                    case "CupO":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.MuneTouch);
                            girlTouchSE = true;
                            VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.SexyImerisVoice);
                        }
                        SliderUp(3);
                        break;
                    // 頭を触っている
                    case "CupH":
                        SliderUp(2);
                        break;
                }
            }
        }

        //-----スクワットをクリア状態の時の処理(プレイヤースクワット状態以外)-----//
        if (SquatGameSystem.squatGameClear == true && LeftHandFollowObj.girlAngryCount < 3)
        {
            switch (other.gameObject.tag)
            {
                // 股を触っている
                case "CupM":
                    if (!girlTouchSE)
                    {
                        SEManager.Instance.PlaySE(SESoundData.SE.ManTouch);
                        girlTouchSE = true;
                    }
                    StartCoroutine("Touch_NO_R18Mode");
                    break;
                // 胸を触っている
                case "CupO":
                    if (!girlTouchSE)
                    {
                        SEManager.Instance.PlaySE(SESoundData.SE.MuneTouch);
                        girlTouchSE = true;
                    }
                    StartCoroutine("Touch_NO_R18Mode");
                    break;
                // 頭を触っている
                case "CupH":
                    StartCoroutine("HeadTouch");
                    break;
            }
        }
    }


    /// <summary>
    /// 女の子の頭、胸、股から左手が離れた時の処理
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        girlTouchSE = false;
        timeToTouch_L = 0;
        girlFaceAnimation.SetBool("NagomiFace", false);
        girlFaceAnimation.SetBool("KomariFace", false);
        girlFaceAnimation.SetBool("AngryFace", false);

       

        switch (other.gameObject.tag)
        {
            case "CupM":
                StopCoroutine("Touch_NO_R18Mode");
                SEManager.Instance.StopSE(SESoundData.SE.ManTouch);
                VoiceManager.Instance.PauseVoice(VoiceSoundData.Voice.SexyImerisVoice);
                break;
            case "CupO":
                StopCoroutine("Touch_NO_R18Mode");
                SEManager.Instance.StopSE(SESoundData.SE.MuneTouch);
                VoiceManager.Instance.PauseVoice(VoiceSoundData.Voice.SexyImerisVoice);
                break;
            case "CupH":
                StopCoroutine("HeadTouch");
                break;

        }

        // 女の子の表情が変化している時
        if (LeftHandFollowObj.girlFaceChangeBool == true)
        {
            LeftHandFollowObj.girlFaceChangeBool = false;
            // 怒りのカウント3以下の時、動作を再開させる
            if (LeftHandFollowObj.girlAngryCount < 3)
            {
                
                angryElapseTime = 0;
                playableDirector.Resume();
            }

            // 女の子の表情が怒り顔の時。怒りのカウントを1加算
            if (LeftHandFollowObj.girlAngryFace == true&&SquatGameSystem.youLoveMode==false)
            {
                LeftHandFollowObj.girlAngryFace = false;
                LeftHandFollowObj.girlAngryCount += 1;
            }

        }
    }
}