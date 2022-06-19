using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BinderRecord : MonoBehaviour
{
    /*���ɂ��̕ϐ�*/
    public Text todayText;

    /*�e�X�N���b�g�̃g�[�^���̕ϐ�*/
    public Text normalSquatTotal;
    public Text quaterSquatTotal;
    public Text wideSquatTotal;


    // Start is called before the first frame update
    void Start()
    {

        SquatGameSystem.squatGameClear = true;
        
        //�ۑ����Ă���l���擾���鏈��
        CharacterManager.allSquatTotal = PlayerPrefs.GetInt("AllSqwat", 0);
        CharacterManager.NormalSquatTotal = PlayerPrefs.GetInt("NormalSqwat", 0);
        CharacterManager.quarterSquatTotal = PlayerPrefs.GetInt("QuarterSqwat", 0);
        CharacterManager.wideSquatTotal = PlayerPrefs.GetInt("WideSqwat", 0);
        
        //�����̓��t���e�L�X�g�\��
        DateTime TodayNow = DateTime.Now;
        todayText.text = TodayNow.Year.ToString() + "�N" + TodayNow.Month.ToString() + "��" + TodayNow.Day.ToString() + "��";

        //�e�X�N���b�g�̋L�^���e�L�X�g�\��
        normalSquatTotal.text = CharacterManager.NormalSquatTotal + "��";
        quaterSquatTotal.text = CharacterManager.quarterSquatTotal + "��";
        wideSquatTotal.text = CharacterManager.wideSquatTotal + "��";
    }
}
