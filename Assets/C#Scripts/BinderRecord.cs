using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BinderRecord : MonoBehaviour
{
    /*日にちの変数*/
    public Text todayText;

    /*各スクワットのトータルの変数*/
    public Text normalSquatTotal;
    public Text quaterSquatTotal;
    public Text wideSquatTotal;


    // Start is called before the first frame update
    void Start()
    {

        SquatGameSystem.squatGameClear = true;
        
        //保存している値を取得する処理
        CharacterManager.allSquatTotal = PlayerPrefs.GetInt("AllSqwat", 0);
        CharacterManager.NormalSquatTotal = PlayerPrefs.GetInt("NormalSqwat", 0);
        CharacterManager.quarterSquatTotal = PlayerPrefs.GetInt("QuarterSqwat", 0);
        CharacterManager.wideSquatTotal = PlayerPrefs.GetInt("WideSqwat", 0);
        
        //今日の日付をテキスト表示
        DateTime TodayNow = DateTime.Now;
        todayText.text = TodayNow.Year.ToString() + "年" + TodayNow.Month.ToString() + "月" + TodayNow.Day.ToString() + "日";

        //各スクワットの記録をテキスト表示
        normalSquatTotal.text = CharacterManager.NormalSquatTotal + "回";
        quaterSquatTotal.text = CharacterManager.quarterSquatTotal + "回";
        wideSquatTotal.text = CharacterManager.wideSquatTotal + "回";
    }
}
