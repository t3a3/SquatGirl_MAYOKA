using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenu : MonoBehaviour
{
    public static bool onClick;
    public GameObject UI;
    public GameObject UIAnchor;
    private bool UIActive;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        UIActive = false;
        onClick = false;
        SquatTimelineSignal.SubmenuOnOFF = true;
    }

    // Update is called once per frame
    void Update()
    {
        //text01.text = "ƒVƒOƒiƒ‹‚ÌINT" + ChangeSquatIImage_Signal.changeInt;
        if (OVRInput.GetDown(OVRInput.RawButton.Start)&&SquatTimelineSignal.SubmenuOnOFF==true)
        {
            onClick = !onClick;
            UIActive = !UIActive;
            UI.SetActive(UIActive);
            
        }

        if (UIActive)
        {
            UI.transform.position = UIAnchor.transform.position;
            UI.transform.eulerAngles = new Vector3(UIAnchor.transform.eulerAngles.x, UIAnchor.transform.eulerAngles.y, 0);
        }

        if (onClick==true)
        {
            SquatGameSystem.r18ModeBool = false;
            switch (LoadScene.selectSquat)
            {
                case 1:
                    SquatPrepPosition.girlAnimation.SetBool("Squat_bool", false);
                    break;
                case 2:
                    SquatPrepPosition.girlAnimation.SetBool("QuaterSq", false);
                    break;
                case 3:
                    SquatPrepPosition.girlAnimation.SetBool("WideSq", false);
                    break;
                case 4:
                    SquatPrepPosition.girlAnimation.SetBool("OHSq", false);
                    break;
            }
        }
        else if (onClick == false&&SquatGameSystem.squatGameClear==false&& SquatTimelineSignal.squatExpEndBool == false)
        {
            switch (LoadScene.selectSquat)
            {
                case 1:
                    SquatPrepPosition.girlAnimation.SetBool("Squat_bool", true);
                    break;
                case 2:
                    SquatPrepPosition.girlAnimation.SetBool("QuaterSq", true);
                    break;
                case 3:
                    SquatPrepPosition.girlAnimation.SetBool("WideSq", true);
                    break;
                case 4:
                    SquatPrepPosition.girlAnimation.SetBool("OHSq", true);
                    break;
            }
        }

        if (SquatTimelineSignal.squatExpEndBool == true )
        {
            switch (LoadScene.selectSquat)
            {
                case 1:
                    SquatPrepPosition.girlAnimation.SetBool("Squat_bool", false);
                    break;
                case 2:
                    SquatPrepPosition.girlAnimation.SetBool("QuaterSq", false);
                    break;
                case 3:
                    SquatPrepPosition.girlAnimation.SetBool("WideSq", false);
                    break;
                case 4:
                    SquatPrepPosition.girlAnimation.SetBool("OHSq", false);
                    break;
            }
        }
    }


}

