using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoginBonus : MonoBehaviour
{
    public GameObject FirstLoginCanvas;
    private enum LOGIN_TYPE
    {
        FIRST_USER_LOGIN, //���񃍃O�C��
        TODAY_LOGIN,      //���O�C��
        ALREADY_LOGIN,    //���O�C����
        ERROR_LOGIN       //�s�����O�C��
    }

    private int todayDate = 0;
    private int lastDate;
    private LOGIN_TYPE judge_type;

    public static int LoginInt;

    void Start()
    {
        
        DateTime now = DateTime.Now;//�[���̌��ݎ����̎擾        
        todayDate = now.Year * 10000 + now.Month * 100 + now.Day;//���t�𐔒l���@2020�N9��1������20200901�ɂȂ�

        //�O�񃍃O�C�����̓��t�f�[�^�����[�h �f�[�^���Ȃ��ꍇ��FIRST_USER_LOGIN��0
        lastDate = PlayerPrefs.GetInt("LastGetDate", (int)LOGIN_TYPE.FIRST_USER_LOGIN);


        //�O��ƍ���̓��t�f�[�^��r

        if (lastDate < todayDate)//���t���i��ł���ꍇ
        {
            judge_type = LOGIN_TYPE.TODAY_LOGIN;
            
        }
        else if (lastDate == todayDate)//���t���i��ł��Ȃ��ꍇ
        {
            judge_type = LOGIN_TYPE.ALREADY_LOGIN;
        }
        else if (lastDate > todayDate)//���t���t�]���Ă���ꍇ
        {
            judge_type = LOGIN_TYPE.ERROR_LOGIN;
        }


        switch (judge_type)
        {
            //���O�C���{�[�i�X
            case LOGIN_TYPE.TODAY_LOGIN:

                //�����O�C���{�[�i�X�@lastDate��0�������Ă����珈�����s
                if (lastDate == (int)LOGIN_TYPE.FIRST_USER_LOGIN)
                {
                    //�����O�C���{�[�i�X����
                    Invoke("FirstLogin", 1.0f);
                }
                else
                {
                    LoginInt = PlayerPrefs.GetInt("LoginPoint", 0);
                    LoginInt += 1;
                    PlayerPrefs.SetInt("LoginPoint", LoginInt);
                    PlayerPrefs.Save();
                    //���ʂ̃��O�C���{�[�i�X����
                    Invoke("Login", 1.0f);
                   
                }

                break;

            //���łɃ��O�C���ς�
            case LOGIN_TYPE.ALREADY_LOGIN:
                //�Ȃɂ����Ȃ�
                LoginInt = PlayerPrefs.GetInt("LoginPoint", 0);
                PlayerPrefs.SetInt("LoginPoint", LoginInt);
                PlayerPrefs.Save();
                break;

            //�s�����O�C��
            case LOGIN_TYPE.ERROR_LOGIN:
                //�s�����O�C�����̏���
                break;
        }

        //����擾�������t���Z�[�u
        PlayerPrefs.SetInt("LastGetDate", todayDate);
        PlayerPrefs.Save();
    }
    public void FirstLogin()
    {
        VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.FirstLogin);
        FirstLoginCanvas.SetActive(true);
    }
    public void Login()
    {
        VoiceManager.Instance.PlayVoice(VoiceSoundData.Voice.Login);

    }
}


