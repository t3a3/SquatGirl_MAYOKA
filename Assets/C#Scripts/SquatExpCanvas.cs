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
        sqwaTextExp1.text = "①足を肩幅くらいに開く";
        sqwaTextExp2.text = "②手は床と平行になるよう前に出し胸を張る";
        sqwaTextExp3.text = "③お尻を後ろへ突き出すように、股関節から折り曲げる";
        if (LoadScene.selectSquat == 1)
        {
            sqwaTextExp4.text = "④太ももが床と平行になるまで下げ、ゆっくりと元の姿勢に戻す";
        }
        else if (LoadScene.selectSquat == 2)
        {
            sqwaTextExp4.text = "④…膝の角度が45度になったら、ゆっくりと元の姿勢に戻す";
        }
        else if (LoadScene.selectSquat == 3)
        {
            sqwaTextExp4.text = "④…太ももが床と平行になるまで下げ、ゆっくりと元の姿勢に戻す";
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
