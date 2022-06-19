using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;



[RequireComponent(typeof(PlayableDirector))]
public class TimeLineManager : MonoBehaviour
{

    public static TimeLineManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �����ɃC���X�y�N�^�[��ł��炩���ߕ����̃Z�b�g
    [SerializeField] private TimelineAsset[] timelines;
    private PlayableDirector director;//PlayableDirector�^�̕ϐ�director��錾


    void Start()
    {
        //�����I�u�W�F�N�g�ɕt���Ă���PlayableDirector�R���|�[�l���g���擾
        director = this.GetComponent<PlayableDirector>();
    }


    //�C�x���g�Đ����\�b�h �{�^���Ɋ��蓖�Ă�
    /// <summary>
    /// TimeLineManager�ɃZ�b�g����TimeLine���Đ�����
    /// </summary>
    /// <param name="id">�Đ�������TimeLine�̔ԍ�</param>
    public void EventPlay(int id)
    {

        //�{�^���̈����ɂ���ă^�C�����C�����w�肵�čĐ�
        switch (id)
        {
            case 1:
                // �Đ��������^�C�����C����PlayableDirector�ɍĐ�������
                director.Play(timelines[0]);
                break;

            //�m�[�}���X�N���b�g
            case 2:
                // �Đ��������^�C�����C����PlayableDirector�ɍĐ�������
                director.Play(timelines[1]);
                break;

            //�N�I�[�^�[�X�N���b�g
            case 3:
                // �Đ��������^�C�����C����PlayableDirector�ɍĐ�������
                director.Play(timelines[2]);
                break;

            //���C�h�X�N���b�g
            case 4:
                // �Đ��������^�C�����C����PlayableDirector�ɍĐ�������
                director.Play(timelines[3]);
                break;
            //�I����A�j���[�V����
            case 5:
                director.Play(timelines[4]);
                break;
            case 6:
                director.Play(timelines[5]);
                break;
            case 7:
                director.Play(timelines[6]);
                break;
            case 8:
                director.Play(timelines[7]);
                break;
            case 9:
                director.Play(timelines[8]);
                break;
            //�{��
            case 10:
                director.Play(timelines[9]);
                break;
        }
    }
    public void EventStop()
    {
        director.Stop();
    }

    public void EventPause()
    {
        director.Pause();
    }
}
