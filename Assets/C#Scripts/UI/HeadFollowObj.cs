using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollowObj : MonoBehaviour
{
    /*メインカメラとそのポジションの各座標の変数類*/
    GameObject mainCameraObj;
    float mainCameraPosition_X;
    float mainCameraPosition_Y;
    float mainCameraPosition_Z;
    public static bool GetHead;

    // シングルトン
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

        // R18モードではない(通常時)
        if (SquatGameSystem.r18ModeBool == false)
        {
            HeadFollow();
        }
        // R18モード
        else if (SquatGameSystem.r18ModeBool == true)
        {
            GameObject.Find("HeadFollowObj").transform.position = new Vector3(mainCameraPosition_X, mainCameraPosition_Y, mainCameraPosition_Z);
        }

    }

    /// <summary>
    /// メインカメラの座標とゲームオブジェクトの位置を合わせる処理
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
