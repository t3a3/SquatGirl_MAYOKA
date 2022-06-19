using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquatPrepPosition : MonoBehaviour
{
    /*--このスクリプトがついているゲームオブジェクト--*/
    public GameObject squatPrepPositionObj;
    public GameObject squatGameSystem;

    /*--音関連--*/
    AudioSource audioSource;
    GameObject Find_SoundManager;

    /*--IMERIS関連--*/
    GameObject imeris3Dmodel;//３Dモデルオブジェクト
    public static Animator girlAnimation;//アニメーション

    /*--メインカメラ、左右のカスタムハンドの変数類--*/
    public static GameObject mainCamObj;//メインカメラ
    public static GameObject customHandLeft;//左手
    public static GameObject customHandRight;//右手

    /*--左右の手のTextのゲームオブジェクト--*/
    public GameObject LHandOK;
    public GameObject RHandOK;
    public GameObject LHandOK_R;
    public GameObject RHandOK_R;

    /*--左右の手の位置のガイドテキストオブジェクト--*/
    public GameObject handGuidTextObj_B;
    public GameObject handGuidTextObj_R;

    /*頭の位置の判定で使用する真偽*/
    bool headPositionOK;

    //float
    float updateHeadPosition;//初期目線のフロート
    float LHandPosition;//初期の手の高さ
    float RHandPosition;//初期の手の高さ

    //int 判定用(合計が３になった時、次のフェーズへと移行する)
    int L = 0;
    int R = 0;
    int H = 0;

    /*--Aボタンを押したときの各高さ。スクワットの基準となる高さ--*/
    /// <summary>頭の高さの基準値/// </summary>
    public static float headPosition_Y;
    /// <summary>左手の高さの基準値/// </summary>
    public static float L_handPositon_Y;
    /// <summary>右手の高さの基準値/// </summary>
    public static float R_handPosition_Y;


    /*--左右の手のポジションがOKだった場合に音を鳴らす--*/
    bool isCalledOnce_L = false;
    bool isCalledOnce_R = false;

    /*--エラーメッセージのTextのゲームオブジェクト--*/
    public GameObject handsGoDownTextObj;
    public GameObject HeadOrder;

    /*--テキストオブジェクトが格納されているフォルダー--*/
    public GameObject CounterObj;
    public GameObject LRHandPosition;


    void OnEnable()
    {
        customHandLeft = GameObject.Find("CustomHandLeft");
        customHandRight = GameObject.Find("CustomHandRight");
        mainCamObj = Camera.main.gameObject;
        Find_SoundManager = GameObject.Find("SEManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();
    }

    private void Start()
    {
        SquatGameSystem.squatGameClear = false;
        switch (LoadScene.selectSquat)
        {
            case 1:
                TimeLineManager.Instance.EventPlay(2);
                break;
            case 2:
                TimeLineManager.Instance.EventPlay(3);
                break;
            case 3:
                TimeLineManager.Instance.EventPlay(4);
                break;
        }
    }

    void Update()
    {
        //-----スクワット説明時点で残っているエラーメッセージをOFFにする-----//
        if (SquatTimelineSignal.squatOrderText == true && SquatTimelineSignal.squatExpEndBool == false)
        {
            RHandOK_R.SetActive(false);
            LHandOK_R.SetActive(false);
            HeadOrder.SetActive(false);
            handsGoDownTextObj.SetActive(false);
            LRHandPosition.SetActive(false);
        }

        //----------------------------------------------------------
        //頭、左手、右手が基準の高さかどうかを判定
        //----------------------------------------------------------
        if (SquatTimelineSignal.squatExpEndBool == true)
        {
            LRHandPosition.SetActive(true);
            //----------------------------------------------------------
            //目線の高さ
            //----------------------------------------------------------
            mainCamObj = Camera.main.gameObject;
            updateHeadPosition = mainCamObj.transform.position.y;
            //両手の高さ
            LHandPosition = customHandLeft.transform.position.y;
            RHandPosition = customHandRight.transform.position.y;

            //----------------------------------------------------------
            //LHandOKのテキスト表示
            //----------------------------------------------------------
            if (LoadScene.selectSquat == 1 || LoadScene.selectSquat == 2 || LoadScene.selectSquat == 3 || LoadScene.selectSquat == 5)
            {
                if (updateHeadPosition - LHandPosition < 0.32f)
                {
                    if (!isCalledOnce_L)
                    {
                        if (SEManager.SEOnOff == true)
                        {
                            audioSource.volume = SEManager.SeVol;
                            SEManager.Instance.PlaySE(SESoundData.SE.positionOK);
                        }
                        isCalledOnce_L = true;
                    }

                    LHandOK_R.SetActive(true);
                    LHandOK.SetActive(false);
                    L = 1;
                }
                else
                {
                    LHandOK_R.SetActive(false);
                    LHandOK.SetActive(true);
                    isCalledOnce_L = false;
                    L = 0;
                }
            }

            //----------------------------------------------------------
            //RHandOKのテキスト表示
            //----------------------------------------------------------
            if (LoadScene.selectSquat == 1 || LoadScene.selectSquat == 2 || LoadScene.selectSquat == 3 || LoadScene.selectSquat == 5)
            {
                if (updateHeadPosition - RHandPosition < 0.32f)
                {
                    if (!isCalledOnce_R)
                    {
                        if (SEManager.SEOnOff == true)
                        {
                            audioSource.volume = SEManager.SeVol;
                            SEManager.Instance.PlaySE(SESoundData.SE.positionOK);
                        }
                        isCalledOnce_R = true;
                    }
                    RHandOK.SetActive(false);
                    RHandOK_R.SetActive(true);
                    R = 1;
                }
                else
                {
                    RHandOK_R.SetActive(false);
                    RHandOK.SetActive(true);
                    isCalledOnce_R = false;
                    R = 0;
                }
            }

            //----------------------------------------------------------
            //HeadOKのテキスト表示
            //----------------------------------------------------------
            if (LoadScene.selectSquat == 1 || LoadScene.selectSquat == 2 || LoadScene.selectSquat == 3 || LoadScene.selectSquat == 5)
            {
                if (updateHeadPosition >= 1.3f)
                {
                    handGuidTextObj_B.SetActive(true);
                    HeadOrder.SetActive(false);
                    H = 1;
                    headPositionOK = true;
                }
                else
                {
                    headPositionOK = false;
                    if (headPositionOK == false)
                    {
                        handGuidTextObj_R.SetActive(false);
                        handGuidTextObj_B.SetActive(false);
                        HeadOrder.SetActive(true);
                        H = 0;
                    }
                }
            }

            //----------------------------------------------------------
            //全てがOKだった場合
            //----------------------------------------------------------
            if (L + R + H == 3)
            {
                handGuidTextObj_B.SetActive(false);
                handGuidTextObj_R.SetActive(true);
                HeadOrder.SetActive(false);

                //-----ノーマルスクワット選択していた場合-----//
                if (LoadScene.selectSquat == 1)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        OVRInputButtonA();
                        girlAnimation.SetBool("Squat_bool", true);
                    }
                }

                //-----クオ－タ－スクワット選択していた場合-----//
                if (LoadScene.selectSquat == 2)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        OVRInputButtonA();
                        girlAnimation.SetBool("QuaterSq", true);
                    }
                }

                //-----ワイドスクワット選択していた場合-----//
                if (LoadScene.selectSquat == 3)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        OVRInputButtonA();
                        girlAnimation.SetBool("WideSq", true);
                    }
                }
            }
            else
            {
                handGuidTextObj_R.SetActive(false);
                if (headPositionOK == true)
                {
                    handGuidTextObj_B.SetActive(true);
                }

            }
        }
    }

    /// <summary>
    /// Aボタン押したときの共通の処理
    /// </summary>
    public void OVRInputButtonA()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.PositionOK_All);
        }
        SquatTimelineSignal.squatExpEndBool = false;

        //変数animにアニメーターコンポーネントを格納
        imeris3Dmodel = GameObject.FindGameObjectWithTag("IMERIS");
        girlAnimation = imeris3Dmodel.GetComponent<Animator>();

        headPosition_Y = updateHeadPosition;
        L_handPositon_Y = LHandPosition;
        R_handPosition_Y = RHandPosition;

        CounterObj.SetActive(true);
        LRHandPosition.SetActive(false);
        SquatGameSystem.squatGameClear = false;
        squatPrepPositionObj.SetActive(false);
        squatGameSystem.SetActive(true);
    }
}
