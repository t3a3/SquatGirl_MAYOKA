using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquatGameSystem : MonoBehaviour
{
    /*���֌W*/
    //BGM
    GameObject Find_SoundManager;
    AudioSource audioSource;
    //SE
    AudioSource SEaudioSource;
    GameObject Find_SEManager;
    //Voice
    AudioSource VoiceaudioSource;
    GameObject Find_VoiceManager;

    /*IMERIS�֌W*/
    GameObject body;
    SkinnedMeshRenderer body_skinnedmeshRenderer;
    SkinnedMeshRenderer foot_skinnedmeshRenderer;
    public int F_Index;
    public int B_Index;

    /*R18���[�h�֌W*/
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

    /*-----�ʏ�X�N���b�g�֌W------*/
    float updateCamPositon;//�t�B�b�g�l�X���̃t���[�g
    float LHandPosition;//�����̎�̍���
    float RHandPosition;//�����̎�̍���
    float LHandPositionCheck;
    float RHandPositionCheck;
    float max = -0.25f; //�X�N���b�g�łǂ��܂ŉ��������̂���MAX�
    float min = -0.1f;//�X�N���b�g�ŉ����āA�オ�������̔���
    int squatCount = 0;//�X�N���b�g�̉�
    public static bool squatGameClear = false;//�g���[�j���O�̃N���A����
    public bool UpDown = false;//�X�N���b�g�̔���
    bool isCalledOnce = false;
    //�J�E���^�[UI��
    [SerializeField] ParticleSystem particle;
    public Text countText;//�X�N���b�g�������񐔂̃e�L�X�g
    public GameObject CounterObj;
    public GameObject IrastDown;
    public GameObject IrastUp;
    public GameObject Down;
    public GameObject UP;
    public Text countText_UpDown;
    //�肪�����肷�����b�Z�[�W
    public GameObject handsGoDownTextObj;//
    //�X�N���b�g�I���{�^���̃Q�[���I�u�W�F�N�g
    public GameObject endButtonObj;
    //�X�N���b�g�N���A��A�����_���ȃC�x���g�𗬂����߂Ɏg��
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
            //���E�̎�̍���
            LHandPosition = SquatPrepPosition.customHandLeft.transform.position.y;
            RHandPosition = SquatPrepPosition.customHandRight.transform.position.y;

            //���̍���
            updateCamPositon = SquatPrepPosition.mainCamObj.transform.position.y;

            //��ƂȂ铪�̍�������A���������̍������������l
            float x = updateCamPositon - SquatPrepPosition.headPosition_Y;

            //��ƂȂ鍶�E�̎�̍�������A��������̍������������l
            LHandPositionCheck = updateCamPositon - LHandPosition;
            RHandPositionCheck = updateCamPositon - RHandPosition;

            if (squatGameClear == false)
            {
                //----------------------------------------------------------
                //�J�E���g�̃{�C�X�Đ�
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                                //�D���x�̈Ⴂ�Ő����ύX
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
                // �m�[�}���X�N���b�g//
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
                        // �Q�[���X�^�[�g!!
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
                        // �Q�[���N���A!!
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
                // �N�I�[�^�[�X�N���b�g//
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
                        // �Q�[���X�^�[�g!!
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
                        // �Q�[���N���A!!
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
                // ���C�h�X�N���b�g//
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
                        // �Q�[���X�^�[�g!!
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
                        // �Q�[���N���A!!
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
            //R18���[�h
            //----------------------------------------------------------
            ////-----�D���x�X���C�_�[��100�ŃA�Q��-----//
            if (LikeSlider.value >= 100)
            {
                SquatPrepPosition.girlAnimation.SetBool("HeartFace", true);
                youLoveMode = true;
            }
            /////-----�R���g���[���[��B�{�^�����������Ƃ��̏���----//
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                r18ModeBool = !r18ModeBool;
                squatStopR18 = !squatStopR18;
                SEManager.Instance.PlaySE(SESoundData.SE.TimeStop);

                //----R18���[�h��----//
                if (r18ModeBool == true && countTime > 0)
                {
                    //----R18���[�h��BGM��炷----//
                    SoundManager.Instance.PlayBGM(BGMSoundData.BGM.TimeStop);
                    audioSource.volume = SoundManager.bgmVol;

                    //----�J�E���^�[UI��R18���[�hUI�ɕύX----//
                    handsGoDownTextObj.SetActive(false);
                    TimeStop.SetActive(true);

                    //-----IMERIS�����ɂȂ�-----//
                    ChangeCos_hadakaD();

                    //-----�o�C�u�o��-----11
                    VibeObj.SetActive(true);
                }
                else
                //----R18���[�h�ł͂Ȃ�----//
                {
                    //----�ʏ�̂�BGM��炷----//
                    SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Fitness);
                    audioSource.volume = SoundManager.bgmVol;

                    SEManager.Instance.StopSE(SESoundData.SE.Vibe);

                    //-----�o�C�u��\��-----//
                    VibeObj.transform.position = new Vector3(1.25f, 1.2f, 0.8f);
                    VibeObj.transform.rotation = Quaternion.Euler(0, -90, 0);
                    VibeObj.SetActive(false);

                    //-----�X�N���b�g�̃J�E���g��������炷-----//
                    squatCount = (int)countTime / 5;
                    countText.text = squatCount + "��";

                    //----R18���[�hUI��\��----//
                    TimeStop.SetActive(false);


                    //-----���ɂȂ�O�̈ߑ��𒅂�-----//
                    CostuomeOn();
                }
            }

            if (squatGameClear == false && r18ModeBool == true)
            {

                //-----�o�ߎ��Ԃ��v�Z-----//
                countTime -= Time.deltaTime;
                second = (int)countTime;
                //// (int)countTime��int�^�ɕϊ����ĕ\��������B
                timeCount.text = second.ToString() + "�b";

                //-----5�b���Ƃɉ񐔂����炷����-----//
                squatCount = (int)countTime / 5;
                timeCountSQ.text = squatCount + "��";

                //-----�c�莞�Ԃ�0�ɂȂ������ɍs������-----//
                if (OVRInput.GetDown(OVRInput.RawButton.Start) || countTime <= 0)
                {

                    r18ModeBool = !r18ModeBool;
                    squatStopR18 = !squatStopR18;

                    //----�ʏ�̂�BGM��炷----//
                    SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Fitness);
                    audioSource.volume = SoundManager.bgmVol;

                    SEManager.Instance.StopSE(SESoundData.SE.Vibe);

                    //-----�o�C�u��\��-----//
                    VibeObj.transform.position = new Vector3(1.25f, 1.2f, 0.8f);
                    VibeObj.transform.rotation = Quaternion.Euler(0, -90, 0);
                    VibeObj.SetActive(false);

                    //-----�X�N���b�g�̃J�E���g��������炷-----//
                    squatCount = (int)countTime / 5;
                    countText.text = squatCount + "��";

                    //-----�J�E���^�[UI�̕\�������Z�b�g----//
                    UpDown = false;
                    countText_UpDown.text = "����������";
                    UP.SetActive(false);
                    Down.SetActive(true);

                    //----R18���[�hUI��\��----//
                    TimeStop.SetActive(false);


                    //-----���ɂȂ�O�̈ߑ��𒅂�-----//
                    CostuomeOn();
                }
            }
        }

    }


    /// <summary>
    /// �N���A�����ۂɗ����C�x���g�֐�
    /// </summary>
    public void Event()
    {
        endButtonObj.SetActive(true);
        TimeLineManager.Instance.EventPlay(random);
    }


    /// <summary>
    /// �����グ�����ɍs������
    /// </summary>
    public void SquatUp()
    {
        particle.Stop();
        UpDown = true;

        //----�J�E���^�[UI���̖��ύX-----//
        Down.SetActive(false);
        UP.SetActive(true);

        //----�J�E���^�[UI���̃C���X�g�ύX-----//
        IrastDown.SetActive(false);
        IrastUp.SetActive(true);

        //----�J�E���^�[UI���̃e�L�X�g�ύX-----//
        countText_UpDown.text = "�����グ��";
    }


    /// <summary>
    /// �������������ɍs������
    /// </summary>
    public void SquatDown()
    {
        particle.Play();
        UpDown = false;
        isCalledOnce = false;

        //----�J�E���g�ƕb���̉��Z(R18���g�p)----//
        squatCount += 1;
        countTime += 5;

        //----�J�E���^�[UI���̖��ύX-----//
        UP.SetActive(false);
        Down.SetActive(true);

        //----�J�E���^�[UI���̃C���X�g�ύX-----//
        IrastDown.SetActive(true);
        IrastUp.SetActive(false);

        //----�J�E���^�[UI���̃e�L�X�g�ύX-----//
        countText.text = squatCount + "��";
        countText_UpDown.text = "����������";
    }


    /// <summary>
    /// �Q�[���N���A���ɗ���鏈��
    /// </summary>
    public void SquatGameClear()
    {
        squatCount = 0;
        r18ModeBool = false;
        SquatTimelineSignal.squatExpEndBool = true;

        //----�s�v�ȃI�u�W�F�N�g�ނ̔�\��-----//
        handsGoDownTextObj.SetActive(false);
        Down.SetActive(false);
        UP.SetActive(false);
        IrastDown.SetActive(false);
        IrastUp.SetActive(false);

        //-----�N���A��̃J�E���^�[UI�Ɋւ���ύX-----//
        countText.text = squatCount + "��";
        countText.color = new Color(179f / 255f, 124f / 255f, 32f / 255f);
        countText_UpDown.text = "";

        //-----�ߑ��J���̐^�U�𔻒�-----//
        // �S�̂̃g�[�^���̕ۑ�
        CharacterManager.allSquatTotal += 1;
        PlayerPrefs.SetInt("AllSqwat", CharacterManager.allSquatTotal);
        if (CharacterManager.allSquatTotal == 5 || CharacterManager.allSquatTotal == 10 || CharacterManager.allSquatTotal == 20)
        {
            CostumeChange.release = true;
        }
        // �I�������X�N���b�g�ɂ���čs���鏈��
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
    //�ߑ��ύX�Ɋւ���֐�
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
    /// ���ɂȂ�@cosname5
    /// </summary>
    public void ChangeCos_hadakaD()
    {
        LoginCostume(0, 100);
        CostumeChange.hadakaBool = true;
    }


    /// <summary>
    /// summer�ɒ��ւ���
    /// </summary>
    public void ChangeCos_summerD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Summer);
    }


    /// <summary>
    /// nurse�ɒ��ւ���
    /// </summary>
    public void ChangeCos_NurseD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Nurse);
    }


    /// <summary>
    /// �f�t�H���g�̉����ɒ��ւ���
    /// </summary>
    public void ChangeCos_DefUnderD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Def_Under);
    }


    /// <summary>
    /// �}�C�N���r�L�j_���ɒ��ւ��� cosname0
    /// </summary>
    public void ChangeCos_BikiniWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_W);
    }


    /// <summary>
    /// �}�C�N���r�L�j_���ɒ��ւ��� cosname1
    /// </summary>
    public void ChangeCos_BikiniBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_B);
    }


    /// <summary>
    /// �~�R�����ɒ��ւ��� cosname2
    /// </summary>
    public void ChangeCos_MikoWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_W);
    }


    /// <summary>
    /// �~�R�����ɒ��ւ��� cosname3
    /// </summary>
    public void ChangeCos_MikoBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_B);
    }


    /// <summary>
    /// �o�j�[���ɒ��ւ��� cosname4
    /// </summary>
    public void ChangeCos_BunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny);
    }


    /// <summary>
    /// �o�j�[�����[�X�ɒ��ւ��� cosname5
    /// </summary>
    public void ChangeCos_BunnyLaceD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny_Lace);
    }


    /// <summary>
    /// �t�o�j�[�ɒ��ւ��� cosname6
    /// </summary>
    public void ChangeCos_ReBunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.ReBunny);
    }


    /// <summary>
    /// �u���}�ɒ��ւ��� cosname7
    /// </summary>
    public void ChangeCos_BurumaD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Buruma);
    }


    /// <summary>
    /// �x���g�Z�[���[���ɒ��ւ��� cosname8
    /// </summary>
    public void ChangeCos_BeltSailorBD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_B);
    }


    /// <summary>
    /// �x���g�Z�[���[�Ԃɒ��ւ��� cosname9
    /// </summary>
    public void ChangeCos_BeltSailorRD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_R);
    }


    /// <summary>
    /// �L�����V�[�ɒ��ւ��� cosname10
    /// </summary>
    public void ChangeCos_JiangshiD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Jiangshi);
    }


    /// <summary>
    /// �Z�[�^�[�x�[�W���ɒ��ւ��� cosname11
    /// </summary>
    public void ChangeCos_SlingSweater_BeigeD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Beige);
    }


    /// <summary>
    /// �Z�[�^�[���ɒ��ւ��� cosname12
    /// </summary>
    public void ChangeCos_SlingSweater_BlackD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Black);
    }


    /// <summary>
    /// �Z�[�^�[���ɒ��ւ��� cosname13
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
    /// ���ɂȂ�O�̈ߑ��𒅂�
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

