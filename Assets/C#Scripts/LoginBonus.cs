using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoginBonus : MonoBehaviour
{
    public GameObject FirstLoginCanvas;
    private enum LOGIN_TYPE
    {
        FIRST_USER_LOGIN, //初回ログイン
        TODAY_LOGIN,      //ログイン
        ALREADY_LOGIN,    //ログイン済
        ERROR_LOGIN       //不正ログイン
    }

    private int todayDate = 0;
    private int lastDate;
    private LOGIN_TYPE judge_type;

    public static int LoginInt;

    void Start()
    {
        
        DateTime now = DateTime.Now;//端末の現在時刻の取得        
        todayDate = now.Year * 10000 + now.Month * 100 + now.Day;//日付を数値化　2020年9月1日だと20200901になる

        //前回ログイン時の日付データをロード データがない場合はFIRST_USER_LOGINで0
        lastDate = PlayerPrefs.GetInt("LastGetDate", (int)LOGIN_TYPE.FIRST_USER_LOGIN);


        //前回と今回の日付データ比較

        if (lastDate < todayDate)//日付が進んでいる場合
        {
            judge_type = LOGIN_TYPE.TODAY_LOGIN;
            
        }
        else if (lastDate == todayDate)//日付が進んでいない場合
        {
            judge_type = LOGIN_TYPE.ALREADY_LOGIN;
        }
        else if (lastDate > todayDate)//日付が逆転している場合
        {
            judge_type = LOGIN_TYPE.ERROR_LOGIN;
        }


        switch (judge_type)
        {
            //ログインボーナス
            case LOGIN_TYPE.TODAY_LOGIN:

                //初ログインボーナス　lastDateに0が入っていたら処理実行
                if (lastDate == (int)LOGIN_TYPE.FIRST_USER_LOGIN)
                {
                    //初ログインボーナス処理
                    Invoke("FirstLogin", 1.0f);
                }
                else
                {
                    LoginInt = PlayerPrefs.GetInt("LoginPoint", 0);
                    LoginInt += 1;
                    PlayerPrefs.SetInt("LoginPoint", LoginInt);
                    PlayerPrefs.Save();
                    //普通のログインボーナス処理
                    Invoke("Login", 1.0f);
                   
                }

                break;

            //すでにログイン済み
            case LOGIN_TYPE.ALREADY_LOGIN:
                //なにもしない
                LoginInt = PlayerPrefs.GetInt("LoginPoint", 0);
                PlayerPrefs.SetInt("LoginPoint", LoginInt);
                PlayerPrefs.Save();
                break;

            //不正ログイン
            case LOGIN_TYPE.ERROR_LOGIN:
                //不正ログイン時の処理
                break;
        }

        //今回取得した日付をセーブ
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


