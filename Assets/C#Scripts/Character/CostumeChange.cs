using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeChange : MonoBehaviour
{
    public static CostumeChange Instance;

    /*3DModel(IMERIS)に関連する変数類*/
    GameObject Imeris;
    GameObject costumeBodyTag;
    SkinnedMeshRenderer body_skinnedmeshRenderer;
    SkinnedMeshRenderer foot_skinnedmeshRenderer;
    public int B_Index;
    public int F_Index;
    public static bool hadakaBool = false;

    /*解放通知に関連する変数類*/
    public GameObject releaseFolder;
    public static bool release = false;

    /*各衣装に定められた整数*/
    public static int costumeNumber;

    /*衣装の名前*/
    [SerializeField] Text[] cosName;
    /*デフォルトのボタンイメージ*/
    [SerializeField] Image[] defaultButtonImage;
    /*解放後のボタンイメージ*/
    [SerializeField] Sprite[] changeButtonImage;
    /*衣装変更時のエフェクト*/
    [SerializeField] ParticleSystem costumeChangeParticle;

    /*音関連*/
    public AudioSource audioSource;
    GameObject Find_SoundManager;

    void Start()
    {
        Imeris = GameObject.Find("IMERIS_Assemble");
        Find_SoundManager = GameObject.Find("SEManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();


        //-----ゲーム開始時。前回ゲームを終了した時の衣装を呼び込む処理-----//
        costumeNumber = PlayerPrefs.GetInt("Cosnumber", 0);
        switch (costumeNumber)
        {
            case 0:
                ChangeCos_summerD();
                break;
            case 1:
                ChangeCos_NurseD();
                break;
            case 2:
                ChangeCos_DefUnderD();
                break;
            case 3:
                ChangeCos_SlingSweater_BeigeD();
                break;
            case 4:
                ChangeCos_SlingSweater_BlackD();
                break;
            case 5:
                ChangeCos_SlingSweater_WhiteD();
                break;
            case 6:
                ChangeCos_BurumaD();
                break;
            case 7:
                ChangeCos_BikiniWD();
                break;
            case 8:
                ChangeCos_BikiniBD();
                break;
            case 9:
                ChangeCos_BeltSailorBD();
                break;
            case 10:
                ChangeCos_BeltSailorRD();
                break;
            case 11:
                ChangeCos_BunnyD();
                break;
            case 12:
                ChangeCos_BunnyLaceD();
                break;
            case 13:
                ChangeCos_ReBunnyD();
                break;
            case 14:
                ChangeCos_MikoWD();
                break;
            case 15:
                ChangeCos_MikoBD();
                break;
            case 16:
                ChangeCos_JiangshiD();
                break;
            case 17:
                ChangeCos_hadakaD();
                break;
        }


        //-----各スクワットの回数による衣装開放に関する処理-----//
        CharacterManager.NormalSquatTotal = PlayerPrefs.GetInt("NormalSqwat", 0);
        CharacterManager.quarterSquatTotal = PlayerPrefs.GetInt("QuarterSqwat", 0);
        CharacterManager.wideSquatTotal = PlayerPrefs.GetInt("WideSqwat", 0);
        CharacterManager.allSquatTotal = PlayerPrefs.GetInt("AllSqwat", 0);

        // ノーマルスクワット
        if (CharacterManager.NormalSquatTotal >= 1)
        {
            cosName[0].text = "セーター(白)";
            defaultButtonImage[0].sprite = changeButtonImage[0];
        }
        if (CharacterManager.NormalSquatTotal >= 3)
        {
            cosName[4].text = "ビキニ(白)";
            defaultButtonImage[4].sprite = changeButtonImage[4];
        }
        if (CharacterManager.NormalSquatTotal >= 5)
        {
            cosName[5].text = "ビキニ(黒)";
            defaultButtonImage[5].sprite = changeButtonImage[5];
        }

        // クオータースクワット
        if (CharacterManager.quarterSquatTotal >= 1)
        {
            cosName[1].text = "セーター(黒)";
            defaultButtonImage[1].sprite = changeButtonImage[1];
        }
        if (CharacterManager.quarterSquatTotal >= 3)
        {
            cosName[6].text = "ベルトセーラー(黒)";
            defaultButtonImage[6].sprite = changeButtonImage[6];
        }
        if (CharacterManager.quarterSquatTotal >= 5)
        {
            cosName[7].text = "ベルトセーラー(赤)";
            defaultButtonImage[7].sprite = changeButtonImage[7];
        }

        //　ワイドスクワット
        if (CharacterManager.wideSquatTotal >= 1)
        {
            cosName[2].text = "セーター(ベージュ)";
            defaultButtonImage[2].sprite = changeButtonImage[2];
        }
        if (CharacterManager.wideSquatTotal >= 3)
        {
            cosName[11].text = "巫女(白)";
            defaultButtonImage[11].sprite = changeButtonImage[11];
        }
        if (CharacterManager.wideSquatTotal >= 5)
        {
            cosName[12].text = "巫女(黒)";
            defaultButtonImage[12].sprite = changeButtonImage[12];
        }

        // オールスクワットトータル
        if (CharacterManager.allSquatTotal >= 5)
        {
            cosName[3].text = "ブルマ";
            defaultButtonImage[3].sprite = changeButtonImage[3];
        }
        if (CharacterManager.allSquatTotal >= 10)
        {
            cosName[13].text = "キョンシー";
            defaultButtonImage[13].sprite = changeButtonImage[13];
        }
        if (CharacterManager.allSquatTotal >= 20)
        {
            cosName[14].text = "裸";
            defaultButtonImage[14].sprite = changeButtonImage[14];
        }


        //-----ログイン日数による衣装開放の処理-----//
        if (LoginBonus.LoginInt >= 1)
        {
            cosName[8].text = "バニー";
            defaultButtonImage[8].sprite = changeButtonImage[8];
        }
        if (LoginBonus.LoginInt >= 3)
        {
            cosName[9].text = "バニー（レース）";
            defaultButtonImage[9].sprite = changeButtonImage[9];
        }
        if (LoginBonus.LoginInt >= 7)
        {
            cosName[10].text = "逆バニー";
            defaultButtonImage[10].sprite = changeButtonImage[10];
        }


        //-----衣装開放通知の処理-----//
        if (release == true)
        {
            // ノーマルスクワットの回数による解放通知
            if (CharacterManager.NormalSquatTotal == 1 || CharacterManager.NormalSquatTotal == 3 || CharacterManager.NormalSquatTotal == 5)
            {
                CostumeOpen();
            }

            // クオータースクワットの回数による解放通知
            if (CharacterManager.quarterSquatTotal == 1 || CharacterManager.quarterSquatTotal == 3 || CharacterManager.quarterSquatTotal == 5)
            {
                CostumeOpen();
            }

            // ワイドスクワットの回数による解放通知
            if (CharacterManager.wideSquatTotal == 1 || CharacterManager.wideSquatTotal == 3 || CharacterManager.wideSquatTotal == 5)
            {
                CostumeOpen();
            }


            // 全スクワットのトータルの回数による解放通知
            if (CharacterManager.allSquatTotal == 5 || CharacterManager.allSquatTotal == 10 || CharacterManager.allSquatTotal == 20)
            {
                CostumeOpen();
            }


        }

        // ログイン日数の経過日による解放通知
        if (LoginBonus.LoginInt == 1)
        {
            CostumeOpen();
            LoginBonus.LoginInt++;
            PlayerPrefs.SetInt("LoginPoint", LoginBonus.LoginInt);
            PlayerPrefs.Save();
        }
        if (LoginBonus.LoginInt == 4)
        {
            CostumeOpen();
            LoginBonus.LoginInt++;
            PlayerPrefs.SetInt("LoginPoint", LoginBonus.LoginInt);
            PlayerPrefs.Save();
        }
        if (LoginBonus.LoginInt == 8)
        {
            CostumeOpen();
            LoginBonus.LoginInt++;
            PlayerPrefs.SetInt("LoginPoint", LoginBonus.LoginInt);
            PlayerPrefs.Save();
        }
    }

    public void CostumeOpen()
    {
        if (SEManager.SEOnOff == true)
        {
            audioSource.volume = SEManager.SeVol;
            SEManager.Instance.PlaySE(SESoundData.SE.release);
        }
        releaseFolder.SetActive(true);
        release = false;
    }

    /// <summary>
    /// IMERISの胸の大きさを変更する処理
    /// </summary>
    /// <param name="B">胸の大きさの値</param>
    public void hadaka_cos(int B)
    {
        costumeBodyTag = GameObject.FindGameObjectWithTag("body");
        body_skinnedmeshRenderer = costumeBodyTag.GetComponent<SkinnedMeshRenderer>();
        B_Index = body_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Breast_big");
        body_skinnedmeshRenderer.SetBlendShapeWeight(B_Index, B);
    }

    /// <summary>
    /// IMERISの足の角度を調整する処理
    /// </summary>
    /// <param name="F">足の角度の値</param>
    public void foot(int F)
    {
        costumeBodyTag = GameObject.FindGameObjectWithTag("body");
        foot_skinnedmeshRenderer = costumeBodyTag.GetComponent<SkinnedMeshRenderer>();
        F_Index = foot_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Foot_hill");
        foot_skinnedmeshRenderer.SetBlendShapeWeight(F_Index, F);
    }


    /// <summary>
    /// 任意の衣装に着替える
    /// </summary>
    /// <param name="footP">足の角度の値</param>
    /// <param name="hadakaP">胸の大きさの値</param>
    public void CosChange(int cosNum, int footP, int hadakaP)
    {
        hadakaBool = false;
        Imeris.GetComponent<Animator>().SetTrigger("OneAnime");
        GameObject[] items = GameObject.FindGameObjectsWithTag("Costume");
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
        costumeNumber = cosNum;
        PlayerPrefs.SetInt("Cosnumber", cosNum);
        PlayerPrefs.Save();
        foot(footP);
        hadaka_cos(hadakaP);
        costumeChangeParticle.Play();
    }



    /// <summary>
    /// 裸になる　cosname5
    /// </summary>
    public void ChangeCos_hadaka()
    {
        if (CharacterManager.allSquatTotal >= 20)
        {
            CosChange(17, 0, 100);
            hadakaBool = true;
        }
    }


    /// <summary>
    /// summerに着替える
    /// </summary>
    public void ChangeCos_summer()
    {
        CosChange(0, 50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Summer);
    }


    /// <summary>
    /// nurseに着替える
    /// </summary>
    public void ChangeCos_Nurse()
    {
        CosChange(1, 50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Nurse);

    }


    /// <summary>
    /// デフォルトの下着に着替える
    /// </summary>
    public void ChangeCos_DefUnder()
    {
        CosChange(2, 0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Def_Under);
    }


    /// <summary>
    /// マイクロビキニ_白に着替える cosname0
    /// </summary>
    public void ChangeCos_BikiniW()
    {
        if (CharacterManager.NormalSquatTotal >= 3)
        {
            CosChange(7, 0, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_W);
        }
    }


    /// <summary>
    /// マイクロビキニ_黒に着替える cosname1
    /// </summary>
    public void ChangeCos_BikiniB()
    {
        if (CharacterManager.NormalSquatTotal >= 5)
        {
            CosChange(8, 0, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_B);
        }
    }


    /// <summary>
    /// ミコ服白に着替える cosname2
    /// </summary>
    public void ChangeCos_MikoW()
    {
        if (CharacterManager.wideSquatTotal >= 3)
        {
            CosChange(14, 0, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_W);
        }
    }


    /// <summary>
    /// ミコ服黒に着替える cosname3
    /// </summary>
    public void ChangeCos_MikoB()
    {
        if (CharacterManager.wideSquatTotal >= 5)
        {
            CosChange(15, 0, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_B);
        }
    }


    /// <summary>
    /// バニー服に着替える cosname4
    /// </summary>
    public void ChangeCos_Bunny()
    {
        if (LoginBonus.LoginInt >= 1)
        {
            CosChange(11, 100, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny);
        }
    }


    /// <summary>
    /// バニー服レースに着替える cosname5
    /// </summary>
    public void ChangeCos_BunnyLace()
    {

        if (LoginBonus.LoginInt >= 3)
        {
            CosChange(12, 100, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny_Lace);
        }
    }


    /// <summary>
    /// 逆バニーに着替える cosname6
    /// </summary>
    public void ChangeCos_ReBunny()
    {
        if (LoginBonus.LoginInt >= 7)
        {
            CosChange(13, 0, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.ReBunny);
        }
    }


    /// <summary>
    /// ブルマに着替える cosname7
    /// </summary>
    public void ChangeCos_Buruma()
    {
        if (CharacterManager.allSquatTotal >= 5)
        {
            CosChange(6, 0, 90);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Buruma);
        }
    }


    /// <summary>
    /// ベルトセーラー黒に着替える cosname8
    /// </summary>
    public void ChangeCos_BeltSailorB()
    {
        if (CharacterManager.quarterSquatTotal >= 3)
        {
            CosChange(9, 0, 90);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_B);
        }
    }


    /// <summary>
    /// ベルトセーラー赤に着替える cosname9
    /// </summary>
    public void ChangeCos_BeltSailorR()
    {
        if (CharacterManager.quarterSquatTotal >= 5)
        {
            CosChange(10, 0, 90);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_R);
        }
    }


    /// <summary>
    /// キョンシーに着替える cosname10
    /// </summary>
    public void ChangeCos_Jiangshi()
    {
        if (CharacterManager.allSquatTotal >= 10)
        {
            CosChange(16, 0, 95);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.Jiangshi);
        }
    }


    /// <summary>
    /// セーターベージュに着替える cosname11
    /// </summary>
    public void ChangeCos_SlingSweater_Beige()
    {
        if (CharacterManager.wideSquatTotal >= 1)
        {
            CosChange(3, 0, 90);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Beige);
        }
    }

    /// <summary>
    /// セーター黒に着替える cosname12
    /// </summary>
    public void ChangeCos_SlingSweater_Black()
    {
        if (CharacterManager.quarterSquatTotal >= 1)
        {
            CosChange(4, 0, 90);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Black);
        }
    }


    /// <summary>
    /// セーター白に着替える cosname13
    /// </summary>
    public void ChangeCos_SlingSweater_White()
    {
        if (CharacterManager.NormalSquatTotal >= 1)
        {
            CosChange(5, 0, 90);
            CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_White);
        }
    }
    /// <summary>
    /// ログインした時、前回終了時の衣装に着替える
    /// </summary>
    /// <param name="footP">足の角度の値</param>
    /// <param name="hadakaP">胸の大きさの値</param>
    public void LoginCostume(int footP, int hadakaP)
    {
        hadakaBool = false;
        GameObject[] items = GameObject.FindGameObjectsWithTag("Costume");
        foreach (GameObject item in items)
        {
            Debug.Log(item.name);
            item.SetActive(false);
        }
        foot(footP);
        hadaka_cos(hadakaP);
    }

    /// <summary>
    /// 裸になる　cosname5
    /// </summary>
    public void ChangeCos_hadakaD()
    {
        LoginCostume(0, 100);
        hadakaBool = true;
    }


    /// <summary>
    /// summerに着替える
    /// </summary>
    public void ChangeCos_summerD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Summer);
    }


    /// <summary>
    /// nurseに着替える
    /// </summary>
    public void ChangeCos_NurseD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Nurse);
    }


    /// <summary>
    /// デフォルトの下着に着替える
    /// </summary>
    public void ChangeCos_DefUnderD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Def_Under);
    }


    /// <summary>
    /// マイクロビキニ_白に着替える cosname0
    /// </summary>
    public void ChangeCos_BikiniWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_W);
    }


    /// <summary>
    /// マイクロビキニ_黒に着替える cosname1
    /// </summary>
    public void ChangeCos_BikiniBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_B);
    }


    /// <summary>
    /// ミコ服白に着替える cosname2
    /// </summary>
    public void ChangeCos_MikoWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_W);
    }


    /// <summary>
    /// ミコ服黒に着替える cosname3
    /// </summary>
    public void ChangeCos_MikoBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_B);
    }


    /// <summary>
    /// バニー服に着替える cosname4
    /// </summary>
    public void ChangeCos_BunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny);
    }


    /// <summary>
    /// バニー服レースに着替える cosname5
    /// </summary>
    public void ChangeCos_BunnyLaceD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny_Lace);
    }


    /// <summary>
    /// 逆バニーに着替える cosname6
    /// </summary>
    public void ChangeCos_ReBunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.ReBunny);
    }


    /// <summary>
    /// ブルマに着替える cosname7
    /// </summary>
    public void ChangeCos_BurumaD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Buruma);
    }


    /// <summary>
    /// ベルトセーラー黒に着替える cosname8
    /// </summary>
    public void ChangeCos_BeltSailorBD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_B);
    }


    /// <summary>
    /// ベルトセーラー赤に着替える cosname9
    /// </summary>
    public void ChangeCos_BeltSailorRD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_R);
    }


    /// <summary>
    /// キョンシーに着替える cosname10
    /// </summary>
    public void ChangeCos_JiangshiD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Jiangshi);
    }


    /// <summary>
    /// セーターベージュに着替える cosname11
    /// </summary>
    public void ChangeCos_SlingSweater_BeigeD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Beige);
    }


    /// <summary>
    /// セーター黒に着替える cosname12
    /// </summary>
    public void ChangeCos_SlingSweater_BlackD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Black);
    }


    /// <summary>
    /// セーター白に着替える cosname13
    /// </summary>
    public void ChangeCos_SlingSweater_WhiteD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_White);
    }
}
