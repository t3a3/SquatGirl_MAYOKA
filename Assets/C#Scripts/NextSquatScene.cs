using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSquatScene : MonoBehaviour
{


    //[SerializeField] GameObject canvas;
    //[SerializeField] Slider slider;

    AsyncOperation NextScene;

    private void Start()
    {

        //SceneManager.LoadSceneAsync("GameScene")‚Ì•Ô‚è’l(Œ^‚ÍAsyncOperation)‚ğ•Ï”NextScene‚É‘ã“ü
        NextScene = SceneManager.LoadSceneAsync("FitnessRoom");

        //AsyncOperation‚Ì’†‚Ì•Ï”allowSceneActivation‚ğfalse‚É‚·‚é
        //‚±‚ê‚ªtrue‚É‚È‚é‚ÆƒV[ƒ“ˆÚ“®‚·‚é
        NextScene.allowSceneActivation = false;

    }

    public void SQ_Loadseane(int number)
    {
        LoadScene.selectSquat = number;
      NextScene.allowSceneActivation = true;

    }


    }
