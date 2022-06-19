using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquatPrepPosition : MonoBehaviour
{
    /*--���̃X�N���v�g�����Ă���Q�[���I�u�W�F�N�g--*/
    public GameObject squatPrepPositionObj;
    public GameObject squatGameSystem;

    /*--���֘A--*/
    AudioSource audioSource;
    GameObject Find_SoundManager;

    /*--IMERIS�֘A--*/
    GameObject imeris3Dmodel;//�RD���f���I�u�W�F�N�g
    public static Animator girlAnimation;//�A�j���[�V����

    /*--���C���J�����A���E�̃J�X�^���n���h�̕ϐ���--*/
    public static GameObject mainCamObj;//���C���J����
    public static GameObject customHandLeft;//����
    public static GameObject customHandRight;//�E��

    /*--���E�̎��Text�̃Q�[���I�u�W�F�N�g--*/
    public GameObject LHandOK;
    public GameObject RHandOK;
    public GameObject LHandOK_R;
    public GameObject RHandOK_R;

    /*--���E�̎�̈ʒu�̃K�C�h�e�L�X�g�I�u�W�F�N�g--*/
    public GameObject handGuidTextObj_B;
    public GameObject handGuidTextObj_R;

    /*���̈ʒu�̔���Ŏg�p����^�U*/
    bool headPositionOK;

    //float
    float updateHeadPosition;//�����ڐ��̃t���[�g
    float LHandPosition;//�����̎�̍���
    float RHandPosition;//�����̎�̍���

    //int ����p(���v���R�ɂȂ������A���̃t�F�[�Y�ւƈڍs����)
    int L = 0;
    int R = 0;
    int H = 0;

    /*--A�{�^�����������Ƃ��̊e�����B�X�N���b�g�̊�ƂȂ鍂��--*/
    /// <summary>���̍����̊�l/// </summary>
    public static float headPosition_Y;
    /// <summary>����̍����̊�l/// </summary>
    public static float L_handPositon_Y;
    /// <summary>�E��̍����̊�l/// </summary>
    public static float R_handPosition_Y;


    /*--���E�̎�̃|�W�V������OK�������ꍇ�ɉ���炷--*/
    bool isCalledOnce_L = false;
    bool isCalledOnce_R = false;

    /*--�G���[���b�Z�[�W��Text�̃Q�[���I�u�W�F�N�g--*/
    public GameObject handsGoDownTextObj;
    public GameObject HeadOrder;

    /*--�e�L�X�g�I�u�W�F�N�g���i�[����Ă���t�H���_�[--*/
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
        //-----�X�N���b�g�������_�Ŏc���Ă���G���[���b�Z�[�W��OFF�ɂ���-----//
        if (SquatTimelineSignal.squatOrderText == true && SquatTimelineSignal.squatExpEndBool == false)
        {
            RHandOK_R.SetActive(false);
            LHandOK_R.SetActive(false);
            HeadOrder.SetActive(false);
            handsGoDownTextObj.SetActive(false);
            LRHandPosition.SetActive(false);
        }

        //----------------------------------------------------------
        //���A����A�E�肪��̍������ǂ����𔻒�
        //----------------------------------------------------------
        if (SquatTimelineSignal.squatExpEndBool == true)
        {
            LRHandPosition.SetActive(true);
            //----------------------------------------------------------
            //�ڐ��̍���
            //----------------------------------------------------------
            mainCamObj = Camera.main.gameObject;
            updateHeadPosition = mainCamObj.transform.position.y;
            //����̍���
            LHandPosition = customHandLeft.transform.position.y;
            RHandPosition = customHandRight.transform.position.y;

            //----------------------------------------------------------
            //LHandOK�̃e�L�X�g�\��
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
            //RHandOK�̃e�L�X�g�\��
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
            //HeadOK�̃e�L�X�g�\��
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
            //�S�Ă�OK�������ꍇ
            //----------------------------------------------------------
            if (L + R + H == 3)
            {
                handGuidTextObj_B.SetActive(false);
                handGuidTextObj_R.SetActive(true);
                HeadOrder.SetActive(false);

                //-----�m�[�}���X�N���b�g�I�����Ă����ꍇ-----//
                if (LoadScene.selectSquat == 1)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        OVRInputButtonA();
                        girlAnimation.SetBool("Squat_bool", true);
                    }
                }

                //-----�N�I�|�^�|�X�N���b�g�I�����Ă����ꍇ-----//
                if (LoadScene.selectSquat == 2)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        OVRInputButtonA();
                        girlAnimation.SetBool("QuaterSq", true);
                    }
                }

                //-----���C�h�X�N���b�g�I�����Ă����ꍇ-----//
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
    /// A�{�^���������Ƃ��̋��ʂ̏���
    /// </summary>
    public void OVRInputButtonA()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.PositionOK_All);
        }
        SquatTimelineSignal.squatExpEndBool = false;

        //�ϐ�anim�ɃA�j���[�^�[�R���|�[�l���g���i�[
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
