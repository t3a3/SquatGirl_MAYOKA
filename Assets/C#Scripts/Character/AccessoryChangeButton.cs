using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryChangeButton : MonoBehaviour
{


    /// <summary>
    /// �A�N�Z�T���[�Ȃ�
    /// </summary>
    public void ChangeAcc_none()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Accessory");
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
    }


    /// <summary>
    /// �b�ɒ��ւ���
    /// </summary>
    public void ChangeAcc_kemono()
    {
        ChangeAcc_none();
        CharacterManager.Instance.OnAccessory(AccessoryData.Accessory.Kemono);

    }


    /// <summary>
    /// �����ɒ��ւ���
    /// </summary>
    public void ChangeAcc_demon()
    {
        ChangeAcc_none();
        CharacterManager.Instance.OnAccessory(AccessoryData.Accessory.Demon);
    }

}
