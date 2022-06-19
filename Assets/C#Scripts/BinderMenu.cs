using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BinderMenu : MonoBehaviour
{
    public GameObject UI;
    public GameObject UIAnchor;
    private bool UIActive ;
    private void Start()
    {
        UI.SetActive(true);
        UIActive = true;
    }
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            UIActive = !UIActive;
            UI.SetActive(UIActive);
        }
        if (UIActive)
        {
            UI.transform.position = UIAnchor.transform.position;
            UI.transform.eulerAngles = new Vector3(UIAnchor.transform.eulerAngles.x, UIAnchor.transform.eulerAngles.y, 0);
        }
    }
}
