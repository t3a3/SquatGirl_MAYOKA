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

        //SceneManager.LoadSceneAsync("GameScene")�̕Ԃ�l(�^��AsyncOperation)��ϐ�NextScene�ɑ��
        NextScene = SceneManager.LoadSceneAsync("FitnessRoom");

        //AsyncOperation�̒��̕ϐ�allowSceneActivation��false�ɂ���
        //���ꂪtrue�ɂȂ�ƃV�[���ړ�����
        NextScene.allowSceneActivation = false;

    }

    public void SQ_Loadseane(int number)
    {
        LoadScene.selectSquat = number;
      NextScene.allowSceneActivation = true;

    }


    }
