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

        //SceneManager.LoadSceneAsync("GameScene")の返り値(型はAsyncOperation)を変数NextSceneに代入
        NextScene = SceneManager.LoadSceneAsync("FitnessRoom");

        //AsyncOperationの中の変数allowSceneActivationをfalseにする
        //これがtrueになるとシーン移動する
        NextScene.allowSceneActivation = false;

    }

    public void SQ_Loadseane(int number)
    {
        LoadScene.selectSquat = number;
      NextScene.allowSceneActivation = true;

    }


    }
