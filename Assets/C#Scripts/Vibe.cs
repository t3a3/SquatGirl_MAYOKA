using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibe : MonoBehaviour
{

    public GameObject VibeObj;
    private float timeleft;
    public Animator anim;
    public static Slider loveHeartSlider;

    public static Vibe Instance { get; private set; }
    bool TouchSE = false;
    bool rTouch;
    bool lTouch;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        VibeObj.SetActive(false);

    }

    void OnEnable()
    {
        loveHeartSlider = GameObject.Find("LikeSlider").GetComponent<Slider>();
        rTouch = false;
        lTouch = false;
    }

    void Update()
    {

        if (SquatGameSystem.r18ModeBool == true)
        {
            // ‰EèƒgƒŠƒK[‚ğˆø‚¢‚½‚çU“®‚ğŠJn
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) && rTouch == true)
            {
                SEManager.Instance.PlaySE(SESoundData.SE.Vibe);
                OVRInput.SetControllerVibration(0f, 1f, OVRInput.Controller.RTouch);
            }
            // ¶èƒgƒŠƒK[‚ğˆø‚¢‚½‚çU“®‚ğŠJn
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && lTouch == true)
            {
                SEManager.Instance.PlaySE(SESoundData.SE.Vibe);

                OVRInput.SetControllerVibration(0f, 1f, OVRInput.Controller.LTouch);
            }

            // ‰EèƒgƒŠƒK[‚ğ—£‚µ‚½‚çU“®‚ğ’â~
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                SEManager.Instance.StopSE(SESoundData.SE.Vibe);
                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
                rTouch = false;
            }
            // ¶èƒgƒŠƒK[‚ğ—£‚µ‚½‚çU“®‚ğ’â~
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
            {
                SEManager.Instance.StopSE(SESoundData.SE.Vibe);
                OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
                lTouch = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        timeleft -= Time.deltaTime;
        if (other.gameObject.tag == "CupM")
        {
            if (!TouchSE)
            {
                SEManager.Instance.PlaySE(SESoundData.SE.VibeTouch);
                TouchSE = true;
            }
            if (timeleft <= 0.0)
            {
                timeleft = 1.0f;
                loveHeartSlider.value += 5;

            }
        }
        if (other.gameObject.tag == "CupO")
        {
            if (!TouchSE)
            {
                SEManager.Instance.PlaySE(SESoundData.SE.MuneTouch);
                TouchSE = true;
            }
            if (timeleft <= 0.0)
            {
                timeleft = 1.0f;
                loveHeartSlider.value += 5;

            }
        }
        if (other.gameObject.tag == "Rhand") { rTouch = true; }
        if (other.gameObject.tag == "Lhand") { lTouch = true; }
    }

    void OnTriggerExit(Collider other)
    {
        TouchSE = false;

        if (other.gameObject.tag == "CupO")
        {

            SEManager.Instance.StopSE(SESoundData.SE.MuneTouch);
        }
        if (other.gameObject.tag == "CupM")
        {
            SEManager.Instance.StopSE(SESoundData.SE.VibeTouch);
        }
    }
}
