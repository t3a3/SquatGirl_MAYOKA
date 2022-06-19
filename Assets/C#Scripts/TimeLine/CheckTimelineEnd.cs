using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CheckTimelineEnd : MonoBehaviour
{

	private PlayableDirector playableDirector;
	//�@�I�������m�������ǂ���
	private bool isEnd;

	// Use this for initialization
	void Start()
	{
		playableDirector = GetComponent<PlayableDirector>();
		isEnd = false;
	}

	// Update is called once per frame
	void Update()
	{
		//�@�^�C�����C�����I�������玟�̃V�[����ǂݍ���
		if (!isEnd && playableDirector.state != PlayState.Playing)
		{
			isEnd = true;
			StartCoroutine(LoadNextScene());
		}
	}
	//�@���̃V�[���̓ǂݍ���
	IEnumerator LoadNextScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("MainMenu");

		while (true)
		{
			if (!async.isDone)
			{
				yield return null;
			}
		}
	}
}
