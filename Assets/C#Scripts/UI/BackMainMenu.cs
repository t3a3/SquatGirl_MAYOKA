using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{

    public void onClick()
    {
        
        SceneManager.sceneLoaded += main_SceneLoaded;
        SceneManager.LoadScene("MainMenu");   
    }

    void main_SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        TimeLineManager.Instance.EventStop();
        SquatGameSystem.r18ModeBool = false;
        LeftHandFollowObj.girlFaceChangeBool = false;
        SquatTimelineSignal.squatExpEndBool = false;
        LeftHandFollowObj.girlAnimationStopBool = false;
        LeftHandFollowObj.GetLeftHand = false;
        RightHandFollowObj.GetRightHand = false;
        HeadFollowObj.GetHead = false;
        SquatTimelineSignal.changeInt = 0;
        LeftHandFollowObj.girlAngryCount = 0;
    }
}
