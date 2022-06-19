using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquatTimelineSignal : MonoBehaviour
{
    public static SquatTimelineSignal Instance;

    /*�����L�����o�X*/
    private GameObject SquatCanvas;
    /*�u�z�[���ɖ߂�v�L�����o�X*/
    private GameObject EndCanvas;

    /*�����̃L�����o�X�ɕ\��������e�L�X�g�̕ϐ���*/
    private Text squatTextExp1;
    private Text squatTextExp2;
    private Text squatTextExp3;
    private Text squatTextExp4;
    private Text SqwatName;

   
 
    /*IMERIS�̃A�j���[�^�[*/
    public Animator girlAnimation;

    /*���֘A*/
    private AudioSource Voice_audioSource;


    public static int changeInt;

    /// <summary>�X�N���b�g�̐������I��������ǂ����Btrue=�I��/// </summary>
    public static bool squatExpEndBool = false;
    public static bool SubmenuOnOFF = true;

    /// <summary>true�̎��A�e��G���[���b�Z�[�W��OFF�ɂ���/// </summary>
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
    /// �m�[�}���X�N���b�g�̐������Ɏg�p����V�O�i��
    /// </summary>
    public void NormalSquatTimelineSignal()
    {
        SquatGameSystem.squatGameClear = true;
        squatTextExp1 = GameObject.Find("SqwatTextExp").GetComponent<Text>();
        squatTextExp2 = GameObject.Find("SqwatTextExp2").GetComponent<Text>();
        squatTextExp3 = GameObject.Find("SqwatTextExp3").GetComponent<Text>();
        squatTextExp4 = GameObject.Find("SqwatTextExp4").GetComponent<Text>();
        SqwatName = GameObject.Find("SqwatName").GetComponent<Text>();
        SqwatName.text = "�m�[�}���X�N���b�g";
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

            squatTextExp1.text = "�@�����������炢�ɊJ��";
            changeInt += 1;
        }
        else if (changeInt == 1)
        {
            squatTextExp2.text = "�A��͏��ƕ��s�ɂȂ�悤�O�ɏo�����𒣂�";
            changeInt += 1;
        }
        else if (changeInt == 2)
        {
            squatTextExp3.text = "�B���K�����֓˂��o���悤�ɁA�Ҋ֐߂���܂�Ȃ���";
            changeInt += 1;
        }
        else if (changeInt == 3)
        {
            squatTextExp4.text = "�C�����������ƕ��s�ɂȂ�܂ŉ����A�������ƌ��̎p���ɖ߂�";
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
    /// �N�I�[�^�[�X�N���b�g�̐������Ɏg�p����V�O�i��
    /// </summary>
    public void QuaterSquatTimelineSignal()
    {
        SquatGameSystem.squatGameClear = true;
        squatTextExp1 = GameObject.Find("SqwatTextExp").GetComponent<Text>();
        squatTextExp2 = GameObject.Find("SqwatTextExp2").GetComponent<Text>();
        squatTextExp3 = GameObject.Find("SqwatTextExp3").GetComponent<Text>();
        squatTextExp4 = GameObject.Find("SqwatTextExp4").GetComponent<Text>();
        SqwatName = GameObject.Find("SqwatName").GetComponent<Text>();
        SqwatName.text = "�N�I�[�^�[�X�N���b�g";

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

            squatTextExp1.text = "�@�c�����������炢�ɊJ��";
            changeInt += 1;
        }
        else if (changeInt == 1)
        {
            squatTextExp2.text = "�A�c��͏��ƕ��s�ɂȂ�悤�O�ɏo�����𒣂�";

            changeInt += 1;
        }
        else if (changeInt == 2)
        {
            squatTextExp3.text = "�B�c���K�����֓˂��o���悤�ɁA�Ҋ֐߂���܂�Ȃ���";

            changeInt += 1;
        }
        else if (changeInt == 3)
        {
            squatTextExp4.text = "�C�c�G�̊p�x��45�x�ɂȂ�����A�������ƌ��̎p���ɖ߂�";
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
    /// ���C�h�X�N���b�g�̐������Ɏg�p����V�O�i��
    /// </summary>
    public void WideSquatTimelineSignal()
    {
        SquatGameSystem.squatGameClear = true;
        squatTextExp1 = GameObject.Find("SqwatTextExp").GetComponent<Text>();
        squatTextExp2 = GameObject.Find("SqwatTextExp2").GetComponent<Text>();
        squatTextExp3 = GameObject.Find("SqwatTextExp3").GetComponent<Text>();
        squatTextExp4 = GameObject.Find("SqwatTextExp4").GetComponent<Text>();
        SqwatName = GameObject.Find("SqwatName").GetComponent<Text>();
        SqwatName.text = "���C�h�X�N���b�g";

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

            squatTextExp1.text = "�@�c�����������傫���L����";
            changeInt += 1;
        }
        else if (changeInt == 1)
        {
            squatTextExp2.text = "�A�c��͏��ƕ��s�ɂȂ�悤�O�ɏo�����𒣂�";
            changeInt += 1;
        }
        else if (changeInt == 2)
        {
            squatTextExp3.text = "�B�c���K�����֓˂��o���悤�ɁA�Ҋ֐߂���܂�Ȃ���";
            changeInt += 1;
        }
        else if (changeInt == 3)
        {
            squatTextExp4.text = "�C�c�����������ƕ��s�ɂȂ�܂ŉ����A�������ƌ��̎p���ɖ߂�";
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
