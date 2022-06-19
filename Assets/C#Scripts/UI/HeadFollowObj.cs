using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollowObj : MonoBehaviour
{
    /*���C���J�����Ƃ��̃|�W�V�����̊e���W�̕ϐ���*/
    GameObject mainCameraObj;
    float mainCameraPosition_X;
    float mainCameraPosition_Y;
    float mainCameraPosition_Z;
    public static bool GetHead;

    // �V���O���g��
    public static HeadFollowObj instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SquatGameSystem.r18ModeBool = false;
        GetHead = false;
        mainCameraObj = Camera.main.gameObject;
        HeadFollow();
    }


    // Update is called once per frame
    void Update()
    {

        // R18���[�h�ł͂Ȃ�(�ʏ펞)
        if (SquatGameSystem.r18ModeBool == false)
        {
            HeadFollow();
        }
        // R18���[�h
        else if (SquatGameSystem.r18ModeBool == true)
        {
            GameObject.Find("HeadFollowObj").transform.position = new Vector3(mainCameraPosition_X, mainCameraPosition_Y, mainCameraPosition_Z);
        }

    }

    /// <summary>
    /// ���C���J�����̍��W�ƃQ�[���I�u�W�F�N�g�̈ʒu�����킹�鏈��
    /// </summary>
    public void HeadFollow()
    {
        if (!GetHead)
        {
            mainCameraObj = Camera.main.gameObject;
            GetHead = true;
        }
        mainCameraPosition_X = mainCameraObj.transform.position.x;
        mainCameraPosition_Y = mainCameraObj.transform.position.y;
        mainCameraPosition_Z = mainCameraObj.transform.position.z;
        GameObject.Find("HeadFollowObj").transform.position = new Vector3(mainCameraPosition_X, mainCameraPosition_Y, mainCameraPosition_Z);
    }
}
