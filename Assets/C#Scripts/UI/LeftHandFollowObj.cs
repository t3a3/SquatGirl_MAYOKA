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
    /// ���̎q�̕\���ς���^�U�Btrue=�\��ς���Ă���B
    /// </summary>
    public static bool girlFaceChangeBool;


    /*�Ǐ]���鍶��I�u�W�F�N�g�Ɗe���W�̕ϐ���*/
    GameObject leftHandAnchor;
    float leftHandPosition_X;
    float leftHandPosition_Y;
    float leftHandPosition_Z;
    public static bool GetLeftHand;

    /* ���̎q�ɐG��Ă��鎞�̕ϐ���*/
    private float timeToTouch_L; //����ŏ��̎q�ɐG��Ă��鎞�̌o�ߎ���
   // private float changeFaceBaseTime = 2; //�\��ς��܂ł̎��ԁB2�b�B
    bool girlTouchSE = false; //�^�b�`����SE�𗬂����ǂ����̐^�U�B


    /*�X�N���b�g�����I���C�x���g���̕ϐ��� */
    public static float angryElapseTime; //�X�N���b�g�����I���C�x���g�̌o�ߎ���


    /// <summary> ���̎q���{��܂ł̃J�E���g�B3�ŃX�N���b�g�����I���������s�B</summary>
    public static int girlAngryCount;
    /// <summary> ���̎q���{��̕\��ǂ����̐^�U�Btrue=�{���Ă���B</summary>
    public static bool girlAngryFace;
    /// <summary>���ݐi�s���Ă���C�x���g���~�߂邩�ǂ����̐^�U�Btrue=�C�x���g���~�܂��Ă����ԁB </summary>
    public static bool girlAnimationStopBool;
    /// <summary> ���̎q���{��A�X�N���b�g�����I���C�x���g�𗬂����ǂ����̐^�U�Btrue=�����Ă����ԁB </summary>
    public static bool girlAngryAnimationPlayBool;


    //�V���O���g��
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

        // �X�N���b�g�V�[�����A���̎q�̋��A�҂��R��ȏ�G�����珈�����s
        if (girlAngryCount >= 3&& !girlAnimationStopBool)
        {
            StartCoroutine("AngryEvent");
            girlAnimationStopBool = true;
        }
       
    }

    /// <summary> ���R���g���[���[�ɂ��̃Q�[���I�u�W�F�N�g��Ǐ]������ /// </summary>
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

    /// <summary> �{��|�C���g��3���������̃R���[�`�� /// </summary>
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

    /// <summary> ���̎q�̋��A�҂�G�������̃R���[�`�� </summary>
    /// <returns></returns>
    private IEnumerator Touch_NO_R18Mode()
    {
        yield return new WaitForSeconds(2f);
        Komari();
        yield return new WaitForSeconds(2f);
        Angry();
    }
    /// <summary> ���̎q�̓���G�������̃R���[�`�� </summary>
    /// <returns></returns>
    private IEnumerator HeadTouch()
    {
        yield return new WaitForSeconds(2f);
        Nagomi();
    }


    // �����̏���
    public void Komari()
    {
        if (LeftHandFollowObj.girlFaceChangeBool == false)
        {
            LeftHandFollowObj.girlFaceChangeBool = true;
            girlFaceAnimation.SetBool("KomariFace", true);
        }

    }

    // �{���̏���
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

    // �a�݊�̏���
    public void Nagomi()
    {
        if (LeftHandFollowObj.girlFaceChangeBool == false)
        {
            LeftHandFollowObj.girlFaceChangeBool = true;
            girlFaceAnimation.SetBool("NagomiFace", true);
        }
    }

    /// <summary> �D���x�X���C�_�[���A�b�v�����鏈�� </summary>
    /// <param name="sliderP">�X���C�_�[�̐��l�𑝂₷�l</param>
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
    /// ���̎q�̓��A���A�҂�G���Ă��鎞�̏���
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {

        //-----�X�N���b�g���N���A���Ă��Ȃ����{��̃J�E���g���R�ȉ��̎��̏���-----//
        if (SquatGameSystem.squatGameClear == false && LeftHandFollowObj.girlAngryCount < 3)
        {

            // R18���[�h�ł͂Ȃ�
            if (SquatGameSystem.r18ModeBool == false)
            {
                switch (other.gameObject.tag)
                {
                    // �҂�G���Ă���
                    case "CupM":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.ManTouch);
                            girlTouchSE = true;
                        }
                        StartCoroutine("Touch_NO_R18Mode");
                        break;
                    // ����G���Ă���
                    case "CupO":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.MuneTouch);
                            girlTouchSE = true;
                        }
                        StartCoroutine("Touch_NO_R18Mode");
                        break;
                    // ����G���Ă���
                    case "CupH":
                        StartCoroutine("HeadTouch");
                        break;
                }

            }

            // R18���[�h�����̎q�̍D���x��100�ȉ��̎��̏���
            if (SquatGameSystem.r18ModeBool == true && Vibe.loveHeartSlider.value < 100)
            {
                switch (other.gameObject.tag)
                {
                    // �҂�G���Ă���
                    case "CupM":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.ManTouch);
                            girlTouchSE = true;
                            VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.SexyImerisVoice);
                        }
                        SliderUp(4);
                        break;
                    // ����G���Ă���
                    case "CupO":
                        if (!girlTouchSE)
                        {
                            SEManager.Instance.PlaySE(SESoundData.SE.MuneTouch);
                            girlTouchSE = true;
                            VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.SexyImerisVoice);
                        }
                        SliderUp(3);
                        break;
                    // ����G���Ă���
                    case "CupH":
                        SliderUp(2);
                        break;
                }
            }
        }

        //-----�X�N���b�g���N���A��Ԃ̎��̏���(�v���C���[�X�N���b�g��ԈȊO)-----//
        if (SquatGameSystem.squatGameClear == true && LeftHandFollowObj.girlAngryCount < 3)
        {
            switch (other.gameObject.tag)
            {
                // �҂�G���Ă���
                case "CupM":
                    if (!girlTouchSE)
                    {
                        SEManager.Instance.PlaySE(SESoundData.SE.ManTouch);
                        girlTouchSE = true;
                    }
                    StartCoroutine("Touch_NO_R18Mode");
                    break;
                // ����G���Ă���
                case "CupO":
                    if (!girlTouchSE)
                    {
                        SEManager.Instance.PlaySE(SESoundData.SE.MuneTouch);
                        girlTouchSE = true;
                    }
                    StartCoroutine("Touch_NO_R18Mode");
                    break;
                // ����G���Ă���
                case "CupH":
                    StartCoroutine("HeadTouch");
                    break;
            }
        }
    }


    /// <summary>
    /// ���̎q�̓��A���A�҂��獶�肪���ꂽ���̏���
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

        // ���̎q�̕\��ω����Ă��鎞
        if (LeftHandFollowObj.girlFaceChangeBool == true)
        {
            LeftHandFollowObj.girlFaceChangeBool = false;
            // �{��̃J�E���g3�ȉ��̎��A������ĊJ������
            if (LeftHandFollowObj.girlAngryCount < 3)
            {
                
                angryElapseTime = 0;
                playableDirector.Resume();
            }

            // ���̎q�̕\��{���̎��B�{��̃J�E���g��1���Z
            if (LeftHandFollowObj.girlAngryFace == true&&SquatGameSystem.youLoveMode==false)
            {
                LeftHandFollowObj.girlAngryFace = false;
                LeftHandFollowObj.girlAngryCount += 1;
            }

        }
    }
}