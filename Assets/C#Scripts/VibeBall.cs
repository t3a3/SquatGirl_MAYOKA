using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeBall : MonoBehaviour
{
    public GameObject M;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerStay(Collider other)
    {

        // 右手トリガーを引いたら振動を開始
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (other.gameObject.tag == "CupM")
            {
                M.SetActive(true);
            }
            if (other.gameObject.tag == "CupO")
            {
                M.SetActive(true);
            }
            anim.SetBool("VibeOnOFF", true);
        }
        // 左手トリガーを引いたら振動を開始
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
           
        }

        // 右手トリガーを離したら振動を停止
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {

            anim.SetBool("VibeOnOFF", false);
        }
        // 左手トリガーを離したら振動を停止
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
   
        }
    }
}
