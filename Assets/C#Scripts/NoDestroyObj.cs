using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroyObj : MonoBehaviour
{
    public static NoDestroyObj instance;
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
    public void subroutine()
    {
        Debug.Log("サブルーチンコール");
    }
}
