using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquatGameSystem : MonoBehaviour
{
    /*音関係*/
    //BGM
    GameObject Find_SoundManager;
    AudioSource audioSource;
    //SE
    AudioSource SEaudioSource;
    GameObject Find_SEManager;
    //Voice
    AudioSource VoiceaudioSource;
    GameObject Find_VoiceManager;

    /*IMERIS関係*/
    GameObject body;
    SkinnedMeshRenderer body_skinnedmeshRenderer;
    SkinnedMeshRenderer foot_skinnedmeshRenderer;
    public int F_Index;
    public int B_Index;

    /*R18モード関係*/
    public GameObject TimeStop;
    public GameObject VibeObj;
    public Slider LikeSlider;
    private int second;
    private float countTime = 0;
    public Text timeCount;
    public Text timeCountSQ;
    public static bool r18ModeBool;
    bool squatStopR18;
    public static bool youLoveMode;

    /*-----通常スクワット関係------*/
    float updateCamPositon;//フィットネス中のフロート
    float LHandPosition;//初期の手の高さ
    float RHandPosition;//初期の手の高さ
    float LHandPositionCheck;
    float RHandPositionCheck;
    float max = -0.25f; //スクワットでどこまで下がったのかのMAX基準
    float min = -0.1f;//スクワットで下げて、上がった時の判定基準
    int squatCount = 0;//スクワットの回数
    public static bool squatGameClear = false;//トレーニングのクリア判定
    public bool UpDown = false;//スクワットの判定
    bool isCalledOnce = false;
    //カウンターUI内
    [SerializeField] ParticleSystem particle;
    public Text countText;//スクワットをした回数のテキスト
    public GameObject CounterObj;
    public GameObject IrastDown;
    public GameObject IrastUp;
    public GameObject Down;
    public GameObject UP;
    public Text countText_UpDown;
    //手が下がりすぎメッセージ
    public GameObject handsGoDownTextObj;//
    //スクワット終了ボタンのゲームオブジェクト
    public GameObject endButtonObj;
    //スクワットクリア後、ランダムなイベントを流すために使う
    int random;

   
    void Start()
    {
        squatCount = 0;

        squatStopR18 = false;
        r18ModeBool = false;
        handsGoDownTextObj.SetActive(false);
        Find_SoundManager = GameObject.Find("SoundManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();
        Find_SEManager = GameObject.Find("SEManager");
        SEaudioSource = Find_SEManager.GetComponent<AudioSource>();
        Find_VoiceManager = GameObject.Find("VoiceManager");
        VoiceaudioSource = Find_VoiceManager.GetComponent<AudioSource>();
        random = Random.Range(5, 10);
    }

    void Update()
    {

        if (SquatTimelineSignal.squatExpEndBool == false && SquatTimelineSignal.squatOrderText == false)
        {
            //左右の手の高さ
            LHandPosition = SquatPrepPosition.customHandLeft.transform.position.y;
            RHandPosition = SquatPrepPosition.customHandRight.transform.position.y;

            //頭の高さ
            updateCamPositon = SquatPrepPosition.mainCamObj.transform.position.y;

            //基準となる頭の高さから、動いた頭の高さを引いた値
            float x = updateCamPositon - SquatPrepPosition.headPosition_Y;

            //基準となる左右の手の高さから、動いた手の高さを引いた値
            LHandPositionCheck = updateCamPositon - LHandPosition;
            RHandPositionCheck = updateCamPositon - RHandPosition;

            if (squatGameClear == false)
            {
                //----------------------------------------------------------
                //カウントのボイス再生
                //----------------------------------------------------------
                if (!isCalledOnce)
                {
                    SEaudioSource.volume = SEManager.SeVol;
                    VoiceaudioSource.volume = VoiceManager.VoiceVol;
                    switch (squatCount)
                    {
                        case 1:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count1);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count1);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 2:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count2);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count2);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 3:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count3);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count3);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 4:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if(youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count4);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count4);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 5:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count5);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count5);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 6:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count6);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count6);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 7:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count7);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count7);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 8:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count8);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count8);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 9:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count9);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count9);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                        case 10:
                            if (VoiceManager.VoiceOnOff == true)
                            {
                                //好感度の違いで声音変更
                                if (youLoveMode == false)
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.count10);
                                else
                                    VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.sexy_count10);
                            }
                            if (SEManager.SEOnOff == true) SEManager.Instance.PlaySE(SESoundData.SE.positionOneOk);
                            isCalledOnce = true;
                            break;
                    }
                }


                //----------------------------------------------------------
                // ノーマルスクワット//
                //----------------------------------------------------------
                if (LoadScene.selectSquat == 1 && squatStopR18 == false)
                {

                    float headPosition = x * -3.8f;
                    headPosition = System.Math.Min(headPosition, 1);
                    SquatPrepPosition.girlAnimation.SetFloat("SquatSpeed", headPosition);
                    if (LHandPositionCheck < 0.35f && RHandPositionCheck < 0.35f)
                    {
                        handsGoDownTextObj.SetActive(false);
                        //----------------------------------------------------------
                        // ゲームスタート!!
                        //----------------------------------------------------------
                        if (squatCount < 10)
                        {
                            if (x < max && UpDown == false)
                            {
                                SquatUp();
                            }
                            else if (x > min && UpDown == true)
                            {
                                SquatDown();
                            }
                        }
                        //----------------------------------------------------------
                        // ゲームクリア!!
                        //----------------------------------------------------------
                        else if (squatCount == 10)
                        {
                            if (!squatGameClear)
                            {
                                SquatGameClear();
                                Invoke("Event", 2.0f);
                            }
                        }
                    }
                    else
                    {
                        if (SubMenu.onClick == false)
                        {
                            handsGoDownTextObj.SetActive(true);
                        }
                    }
                }


                //----------------------------------------------------------
                // クオータースクワット//
                //----------------------------------------------------------
                if (LoadScene.selectSquat == 2 && squatStopR18 == false)
                {
                    float headPosition = x * -8f;
                    headPosition = System.Math.Min(headPosition, 1);
                    SquatPrepPosition.girlAnimation.SetFloat("SquatSpeed", headPosition);
                    if (LHandPositionCheck < 0.35f && RHandPositionCheck < 0.35f)
                    {
                        float Qmax = -0.15f;
                        float Qmin = -0.05f;
                        handsGoDownTextObj.SetActive(false);

                        //----------------------------------------------------------
                        // ゲームスタート!!
                        //----------------------------------------------------------
                        if (squatCount < 10)
                        {
                            if (x < Qmax && UpDown == false)
                            {
                                SquatUp();
                            }
                            else if (x > Qmin && UpDown == true)
                            {
                                SquatDown();
                            }
                        }
                        //----------------------------------------------------------
                        // ゲームクリア!!
                        //----------------------------------------------------------
                        else if (squatCount == 10)
                        {
                            if (!squatGameClear)
                            {
                                SquatGameClear();
                                Invoke("Event", 1.0f);
                            }
                        }
                    }
                    else
                    {
                        if (SubMenu.onClick == false)
                        {
                            handsGoDownTextObj.SetActive(true);
                        }

                    }
                }


                //----------------------------------------------------------
                // ワイドスクワット//
                //----------------------------------------------------------
                if (LoadScene.selectSquat == 3 && squatStopR18 == false)
                {
                    float headPosition = x * -4f;
                    headPosition = System.Math.Min(headPosition, 1);
                    SquatPrepPosition.girlAnimation.SetFloat("SquatSpeed", headPosition);
                    if (LHandPositionCheck < 0.35f && RHandPositionCheck < 0.35f)
                    {
                        handsGoDownTextObj.SetActive(false);
                        //----------------------------------------------------------
                        // ゲームスタート!!
                        //----------------------------------------------------------
                        if (squatCount < 10)
                        {
                            if (x < max && UpDown == false)
                            {
                                SquatUp();
                            }
                            else if (x > min && UpDown == true)
                            {
                                SquatDown();
                            }
                        }
                        //----------------------------------------------------------
                        // ゲームクリア!!
                        //----------------------------------------------------------
                        else if (squatCount == 10)
                        {
                            if (!squatGameClear)
                            {
                                SquatGameClear();
                                Invoke("Event", 1.0f);
                            }
                        }
                    }
                    else
                    {
                        if (SubMenu.onClick == false)
                        {
                            handsGoDownTextObj.SetActive(true);

                        }
                    }
                }

            }


            //----------------------------------------------------------
            //R18モード
            //----------------------------------------------------------
            ////-----好感度スライダーが100でアゲ顔-----//
            if (LikeSlider.value >= 100)
            {
                SquatPrepPosition.girlAnimation.SetBool("HeartFace", true);
                youLoveMode = true;
            }
            /////-----コントローラーのBボタンを押したときの処理----//
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                r18ModeBool = !r18ModeBool;
                squatStopR18 = !squatStopR18;
                SEManager.Instance.PlaySE(SESoundData.SE.TimeStop);

                //----R18モード中----//
                if (r18ModeBool == true && countTime > 0)
                {
                    //----R18モードのBGMを鳴らす----//
                    SoundManager.Instance.PlayBGM(BGMSoundData.BGM.TimeStop);
                    audioSource.volume = SoundManager.bgmVol;

                    //----カウンターUIをR18モードUIに変更----//
                    handsGoDownTextObj.SetActive(false);
                    TimeStop.SetActive(true);

                    //-----IMERISが裸になる-----//
                    ChangeCos_hadakaD();

                    //-----バイブ出現-----11
                    VibeObj.SetActive(true);
                }
                else
                //----R18モードではない----//
                {
                    //----通常ののBGMを鳴らす----//
                    SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Fitness);
                    audioSource.volume = SoundManager.bgmVol;

                    SEManager.Instance.StopSE(SESoundData.SE.Vibe);

                    //-----バイブ非表示-----//
                    VibeObj.transform.position = new Vector3(1.25f, 1.2f, 0.8f);
                    VibeObj.transform.rotation = Quaternion.Euler(0, -90, 0);
                    VibeObj.SetActive(false);

                    //-----スクワットのカウントを消費分減らす-----//
                    squatCount = (int)countTime / 5;
                    countText.text = squatCount + "回";

                    //----R18モードUI非表示----//
                    TimeStop.SetActive(false);


                    //-----裸になる前の衣装を着る-----//
                    CostuomeOn();
                }
            }

            if (squatGameClear == false && r18ModeBool == true)
            {

                //-----経過時間を計算-----//
                countTime -= Time.deltaTime;
                second = (int)countTime;
                //// (int)countTimeでint型に変換して表示させる。
                timeCount.text = second.ToString() + "秒";

                //-----5秒ごとに回数を減らす処理-----//
                squatCount = (int)countTime / 5;
                timeCountSQ.text = squatCount + "回";

                //-----残り時間が0になった時に行う処理-----//
                if (OVRInput.GetDown(OVRInput.RawButton.Start) || countTime <= 0)
                {

                    r18ModeBool = !r18ModeBool;
                    squatStopR18 = !squatStopR18;

                    //----通常ののBGMを鳴らす----//
                    SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Fitness);
                    audioSource.volume = SoundManager.bgmVol;

                    SEManager.Instance.StopSE(SESoundData.SE.Vibe);

                    //-----バイブ非表示-----//
                    VibeObj.transform.position = new Vector3(1.25f, 1.2f, 0.8f);
                    VibeObj.transform.rotation = Quaternion.Euler(0, -90, 0);
                    VibeObj.SetActive(false);

                    //-----スクワットのカウントを消費分減らす-----//
                    squatCount = (int)countTime / 5;
                    countText.text = squatCount + "回";

                    //-----カウンターUIの表示をリセット----//
                    UpDown = false;
                    countText_UpDown.text = "腰を下げて";
                    UP.SetActive(false);
                    Down.SetActive(true);

                    //----R18モードUI非表示----//
                    TimeStop.SetActive(false);


                    //-----裸になる前の衣装を着る-----//
                    CostuomeOn();
                }
            }
        }

    }


    /// <summary>
    /// クリアした際に流れるイベント関数
    /// </summary>
    public void Event()
    {
        endButtonObj.SetActive(true);
        TimeLineManager.Instance.EventPlay(random);
    }


    /// <summary>
    /// 腰を上げた時に行う処理
    /// </summary>
    public void SquatUp()
    {
        particle.Stop();
        UpDown = true;

        //----カウンターUI内の矢印変更-----//
        Down.SetActive(false);
        UP.SetActive(true);

        //----カウンターUI内のイラスト変更-----//
        IrastDown.SetActive(false);
        IrastUp.SetActive(true);

        //----カウンターUI内のテキスト変更-----//
        countText_UpDown.text = "腰を上げて";
    }


    /// <summary>
    /// 腰を下げた時に行う処理
    /// </summary>
    public void SquatDown()
    {
        particle.Play();
        UpDown = false;
        isCalledOnce = false;

        //----カウントと秒数の加算(R18時使用)----//
        squatCount += 1;
        countTime += 5;

        //----カウンターUI内の矢印変更-----//
        UP.SetActive(false);
        Down.SetActive(true);

        //----カウンターUI内のイラスト変更-----//
        IrastDown.SetActive(true);
        IrastUp.SetActive(false);

        //----カウンターUI内のテキスト変更-----//
        countText.text = squatCount + "回";
        countText_UpDown.text = "腰を下げて";
    }


    /// <summary>
    /// ゲームクリア時に流れる処理
    /// </summary>
    public void SquatGameClear()
    {
        squatCount = 0;
        r18ModeBool = false;
        SquatTimelineSignal.squatExpEndBool = true;

        //----不要なオブジェクト類の非表示-----//
        handsGoDownTextObj.SetActive(false);
        Down.SetActive(false);
        UP.SetActive(false);
        IrastDown.SetActive(false);
        IrastUp.SetActive(false);

        //-----クリア後のカウンターUIに関する変更-----//
        countText.text = squatCount + "回";
        countText.color = new Color(179f / 255f, 124f / 255f, 32f / 255f);
        countText_UpDown.text = "";

        //-----衣装開放の真偽を判定-----//
        // 全体のトータルの保存
        CharacterManager.allSquatTotal += 1;
        PlayerPrefs.SetInt("AllSqwat", CharacterManager.allSquatTotal);
        if (CharacterManager.allSquatTotal == 5 || CharacterManager.allSquatTotal == 10 || CharacterManager.allSquatTotal == 20)
        {
            CostumeChange.release = true;
        }
        // 選択したスクワットによって行われる処理
        switch (LoadScene.selectSquat)
        {
            case 1:
                SquatPrepPosition.girlAnimation.SetBool("Squat_bool", false);
                CharacterManager.NormalSquatTotal += 1;
                PlayerPrefs.SetInt("NormalSqwat", CharacterManager.NormalSquatTotal);
                if (CharacterManager.NormalSquatTotal == 1 || CharacterManager.NormalSquatTotal == 3 || CharacterManager.NormalSquatTotal == 7)
                {
                    CostumeChange.release = true;
                }
                break;
            case 2:
                SquatPrepPosition.girlAnimation.SetBool("QuaterSq", false);
                CharacterManager.quarterSquatTotal += 1;
                PlayerPrefs.SetInt("QuarterSqwat", CharacterManager.quarterSquatTotal);
                if (CharacterManager.quarterSquatTotal == 1 || CharacterManager.quarterSquatTotal == 3 || CharacterManager.quarterSquatTotal == 7)
                {
                    CostumeChange.release = true;
                }
                break;
            case 3:
                SquatPrepPosition.girlAnimation.SetBool("WideSq", false);
                CharacterManager.wideSquatTotal += 1;
                PlayerPrefs.SetInt("WideSqwat", CharacterManager.wideSquatTotal);
                if (CharacterManager.wideSquatTotal == 1 || CharacterManager.wideSquatTotal == 3 || CharacterManager.wideSquatTotal == 7)
                {
                    CostumeChange.release = true;
                }
                break;
        }
        PlayerPrefs.Save();
        squatGameClear = true;
    }


    //----------------------------------------------------------
    //衣装変更に関する関数
    //----------------------------------------------------------

    public void LoginCostume(int footP, int hadakaP)
    {
        CostumeChange.hadakaBool = false;
        GameObject[] items = GameObject.FindGameObjectsWithTag("Costume");
        foreach (GameObject item in items)
        {
            Debug.Log(item.name);
            item.SetActive(false);
        }
        foot(footP);
        hadaka_cos(hadakaP);
    }
    /// <summary>
    /// 裸になる　cosname5
    /// </summary>
    public void ChangeCos_hadakaD()
    {
        LoginCostume(0, 100);
        CostumeChange.hadakaBool = true;
    }


    /// <summary>
    /// summerに着替える
    /// </summary>
    public void ChangeCos_summerD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Summer);
    }


    /// <summary>
    /// nurseに着替える
    /// </summary>
    public void ChangeCos_NurseD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Nurse);
    }


    /// <summary>
    /// デフォルトの下着に着替える
    /// </summary>
    public void ChangeCos_DefUnderD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Def_Under);
    }


    /// <summary>
    /// マイクロビキニ_白に着替える cosname0
    /// </summary>
    public void ChangeCos_BikiniWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_W);
    }


    /// <summary>
    /// マイクロビキニ_黒に着替える cosname1
    /// </summary>
    public void ChangeCos_BikiniBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_B);
    }


    /// <summary>
    /// ミコ服白に着替える cosname2
    /// </summary>
    public void ChangeCos_MikoWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_W);
    }


    /// <summary>
    /// ミコ服黒に着替える cosname3
    /// </summary>
    public void ChangeCos_MikoBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_B);
    }


    /// <summary>
    /// バニー服に着替える cosname4
    /// </summary>
    public void ChangeCos_BunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny);
    }


    /// <summary>
    /// バニー服レースに着替える cosname5
    /// </summary>
    public void ChangeCos_BunnyLaceD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny_Lace);
    }


    /// <summary>
    /// 逆バニーに着替える cosname6
    /// </summary>
    public void ChangeCos_ReBunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.ReBunny);
    }


    /// <summary>
    /// ブルマに着替える cosname7
    /// </summary>
    public void ChangeCos_BurumaD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Buruma);
    }


    /// <summary>
    /// ベルトセーラー黒に着替える cosname8
    /// </summary>
    public void ChangeCos_BeltSailorBD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_B);
    }


    /// <summary>
    /// ベルトセーラー赤に着替える cosname9
    /// </summary>
    public void ChangeCos_BeltSailorRD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_R);
    }


    /// <summary>
    /// キョンシーに着替える cosname10
    /// </summary>
    public void ChangeCos_JiangshiD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Jiangshi);
    }


    /// <summary>
    /// セーターベージュに着替える cosname11
    /// </summary>
    public void ChangeCos_SlingSweater_BeigeD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Beige);
    }


    /// <summary>
    /// セーター黒に着替える cosname12
    /// </summary>
    public void ChangeCos_SlingSweater_BlackD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Black);
    }


    /// <summary>
    /// セーター白に着替える cosname13
    /// </summary>
    public void ChangeCos_SlingSweater_WhiteD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_White);
    }

    public void hadaka_cos(int B)
    {
        body = GameObject.FindGameObjectWithTag("body");
        body_skinnedmeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
        B_Index = body_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Breast_big");
        body_skinnedmeshRenderer.SetBlendShapeWeight(B_Index, B);
    }
    public void foot(int F)
    {
        body = GameObject.FindGameObjectWithTag("body");
        foot_skinnedmeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
        F_Index = foot_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Foot_hill");
        foot_skinnedmeshRenderer.SetBlendShapeWeight(F_Index, F);
    }

    /// <summary>
    /// 裸になる前の衣装を着る
    /// </summary>
    public void CostuomeOn()
    {
        switch (CostumeChange.costumeNumber)
        {
            case 0:
                ChangeCos_summerD();
                break;
            case 1:
                ChangeCos_NurseD();
                break;
            case 2:
                ChangeCos_DefUnderD();
                break;
            case 3:
                ChangeCos_SlingSweater_BeigeD();
                break;
            case 4:
                ChangeCos_SlingSweater_BlackD();
                break;
            case 5:
                ChangeCos_SlingSweater_WhiteD();
                break;
            case 6:
                ChangeCos_BurumaD();
                break;
            case 7:
                ChangeCos_BikiniWD();
                break;
            case 8:
                ChangeCos_BikiniBD();
                break;
            case 9:
                ChangeCos_BeltSailorBD();
                break;
            case 10:
                ChangeCos_BeltSailorRD();
                break;
            case 11:
                ChangeCos_BunnyD();
                break;
            case 12:
                ChangeCos_BunnyLaceD();
                break;
            case 13:
                ChangeCos_ReBunnyD();
                break;
            case 14:
                ChangeCos_MikoWD();
                break;
            case 15:
                ChangeCos_MikoBD();
                break;
            case 16:
                ChangeCos_JiangshiD();
                break;
            case 17:
                ChangeCos_hadakaD();
                break;
        }
    }
}

