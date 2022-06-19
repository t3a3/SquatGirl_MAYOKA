using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //全トレーニングのクリア回数の合計
    public static int allSquatTotal=0;
    //各トレーニングのクリア回数の合計
    public static int NormalSquatTotal=0;
    public static int quarterSquatTotal=0;
    public static int wideSquatTotal=0;
    public static int overHeadSquatTotal=0;
    public static int countGameTotal = 0;

    [SerializeField] List<CostumeData> CostumeDatas;
    [SerializeField] List<AccessoryData> AccessoryDatas;
    public static CharacterManager Instance { get; private set; }

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

    public void OnCostume(CostumeData.Costume costume)
    {
        CostumeData data = CostumeDatas.Find(data => data.costume == costume);
        data.CosgameObject.SetActive(true);
    }
    public void OnAccessory(AccessoryData.Accessory accessory)
    {
        AccessoryData data = AccessoryDatas.Find(data => data.accessory == accessory);
        data.AccgameObject.SetActive(true);
    }
}

[System.Serializable]
public class CostumeData
{
    public enum Costume
    {
        Hadaka,
        Def_Under,
        Summer,
        Nurse,
        Miko_W,
        Miko_B,
        Bikini_W,
        Bikini_B,
        Bunny,
        Bunny_Lace,
        ReBunny,
        Buruma,
        BeltSailor_B,
        BeltSailor_R,
        Jiangshi,
        SlingSweater_Beige,
        SlingSweater_Black,
        SlingSweater_White
    }

    public Costume costume;
    public GameObject CosgameObject;
    public bool CosOnOff = false;
}
[System.Serializable]
public class AccessoryData
{
    public enum Accessory
    {
        None,
        Kemono,
        Demon
    }

    public Accessory accessory;
    public GameObject AccgameObject;
}
