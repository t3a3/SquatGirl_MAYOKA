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

        // �E��g���K�[����������U�����J�n
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
        // ����g���K�[����������U�����J�n
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
           
        }

        // �E��g���K�[�𗣂�����U�����~
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {

            anim.SetBool("VibeOnOFF", false);
        }
        // ����g���K�[�𗣂�����U�����~
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
   
        }
    }
}
