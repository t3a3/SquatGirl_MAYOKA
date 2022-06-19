using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqwatExpNextBack : MonoBehaviour
{
    public GameObject targetObj;
    public int X;
    void Start()
    {
        //int X = ChangeSquatIImage_Signal.changeInt;
        targetObj = GameObject.Find("TimeLineManager");
        
    }
    //public void onNext()
    //{
    //    //ChangeSquatIImage_Signal.Instance.NormalSquat_ChangeImageD(1);
    //    if (LoadScene.selectSquat == 1)
    //    {
    //        targetObj.GetComponent<ChangeSquatIImage_Signal>().NormalSquat_ChangeImageD(1);
    //        X += 1;

    //    }
    //    else if (LoadScene.selectSquat == 2)
    //    {

    //    }
    //    else if (LoadScene.selectSquat == 3)
    //    {

    //    }
    //    else if (LoadScene.selectSquat == 4)
    //    {

    //    }
    //}
    //public void onBack()
    //{
   
    //    if (LoadScene.selectSquat == 1)
    //    {
            
    //        ChangeSquatIImage_Signal.Instance.NormalSquat_ChangeImageD(X);
    //        X -= 1;

    //    }
    //    else if (LoadScene.selectSquat == 2)
    //    {

    //    }
    //    else if (LoadScene.selectSquat == 3)
    //    {

    //    }
    //    else if (LoadScene.selectSquat == 4)
    //    {

    //    }
    //}
}
