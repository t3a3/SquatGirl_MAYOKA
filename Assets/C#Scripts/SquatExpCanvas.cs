using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquatExpCanvas : MonoBehaviour
{
    public GameObject canvasMove;

    public Text sqwaTextExp1;
    public Text sqwaTextExp2;
    public Text sqwaTextExp3;
    public Text sqwaTextExp4;

    public void SkipAnime()
    {
        sqwaTextExp1.text = "�@�����������炢�ɊJ��";
        sqwaTextExp2.text = "�A��͏��ƕ��s�ɂȂ�悤�O�ɏo�����𒣂�";
        sqwaTextExp3.text = "�B���K�����֓˂��o���悤�ɁA�Ҋ֐߂���܂�Ȃ���";
        if (LoadScene.selectSquat == 1)
        {
            sqwaTextExp4.text = "�C�����������ƕ��s�ɂȂ�܂ŉ����A�������ƌ��̎p���ɖ߂�";
        }
        else if (LoadScene.selectSquat == 2)
        {
            sqwaTextExp4.text = "�C�c�G�̊p�x��45�x�ɂȂ�����A�������ƌ��̎p���ɖ߂�";
        }
        else if (LoadScene.selectSquat == 3)
        {
            sqwaTextExp4.text = "�C�c�����������ƕ��s�ɂȂ�܂ŉ����A�������ƌ��̎p���ɖ߂�";
        }

        TimeLineManager.Instance.EventStop();
        SquatTimelineSignal.changeInt = 0;
        SquatTimelineSignal.squatExpEndBool = true;
        SquatTimelineSignal.squatOrderText = false;
        SquatGameSystem.squatGameClear = false;

    }
    public void onClick_CanvasMove(float y)
    {
        canvasMove.transform.position = new Vector3(-0.6f, y, 0.3f);
    }

}
