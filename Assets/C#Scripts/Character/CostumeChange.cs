using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeChange : MonoBehaviour
{
    public static CostumeChange Instance;

    /*3DModel(IMERIS)�Ɋ֘A����ϐ���*/
    GameObject Imeris;
    GameObject costumeBodyTag;
    SkinnedMeshRenderer body_skinnedmeshRenderer;
    SkinnedMeshRenderer foot_skinnedmeshRenderer;
    public int B_Index;
    public int F_Index;
    public static bool hadakaBool = false;

    /*����ʒm�Ɋ֘A����ϐ���*/
    public GameObject releaseFolder;
    public static bool release = false;

    /*�e�ߑ��ɒ�߂�ꂽ����*/
    public static int costumeNumber;

    /*�ߑ��̖��O*/
    [SerializeField] Text[] cosName;
    /*�f�t�H���g�̃{�^���C���[�W*/
    [SerializeField] Image[] defaultButtonImage;
    /*�����̃{�^���C���[�W*/
    [SerializeField] Sprite[] changeButtonImage;
    /*�ߑ��ύX���̃G�t�F�N�g*/
    [SerializeField] ParticleSystem costumeChangeParticle;

    /*���֘A*/
    public AudioSource audioSource;
    GameObject Find_SoundManager;

    void Start()
    {
        Imeris = GameObject.Find("IMERIS_Assemble");
        Find_SoundManager = GameObject.Find("SEManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();


        //-----�Q�[���J�n���B�O��Q�[�����I���������̈ߑ����Ăэ��ޏ���-----//
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


        //-----�e�X�N���b�g�̉񐔂ɂ��ߑ��J���Ɋւ��鏈��-----//
        CharacterManager.NormalSquatTotal = PlayerPrefs.GetInt("NormalSqwat", 0);
        CharacterManager.quarterSquatTotal = PlayerPrefs.GetInt("QuarterSqwat", 0);
        CharacterManager.wideSquatTotal = PlayerPrefs.GetInt("WideSqwat", 0);
        CharacterManager.allSquatTotal = PlayerPrefs.GetInt("AllSqwat", 0);

        // �m�[�}���X�N���b�g
        if (CharacterManager.NormalSquatTotal >= 1)
        {
            cosName[0].text = "�Z�[�^�[(��)";
            defaultButtonImage[0].sprite = changeButtonImage[0];
        }
        if (CharacterManager.NormalSquatTotal >= 3)
        {
            cosName[4].text = "�r�L�j(��)";
            defaultButtonImage[4].sprite = changeButtonImage[4];
        }
        if (CharacterManager.NormalSquatTotal >= 5)
        {
            cosName[5].text = "�r�L�j(��)";
            defaultButtonImage[5].sprite = changeButtonImage[5];
        }

        // �N�I�[�^�[�X�N���b�g
        if (CharacterManager.quarterSquatTotal >= 1)
        {
            cosName[1].text = "�Z�[�^�[(��)";
            defaultButtonImage[1].sprite = changeButtonImage[1];
        }
        if (CharacterManager.quarterSquatTotal >= 3)
        {
            cosName[6].text = "�x���g�Z�[���[(��)";
            defaultButtonImage[6].sprite = changeButtonImage[6];
        }
        if (CharacterManager.quarterSquatTotal >= 5)
        {
            cosName[7].text = "�x���g�Z�[���[(��)";
            defaultButtonImage[7].sprite = changeButtonImage[7];
        }

        //�@���C�h�X�N���b�g
        if (CharacterManager.wideSquatTotal >= 1)
        {
            cosName[2].text = "�Z�[�^�[(�x�[�W��)";
            defaultButtonImage[2].sprite = changeButtonImage[2];
        }
        if (CharacterManager.wideSquatTotal >= 3)
        {
            cosName[11].text = "�ޏ�(��)";
            defaultButtonImage[11].sprite = changeButtonImage[11];
        }
        if (CharacterManager.wideSquatTotal >= 5)
        {
            cosName[12].text = "�ޏ�(��)";
            defaultButtonImage[12].sprite = changeButtonImage[12];
        }

        // �I�[���X�N���b�g�g�[�^��
        if (CharacterManager.allSquatTotal >= 5)
        {
            cosName[3].text = "�u���}";
            defaultButtonImage[3].sprite = changeButtonImage[3];
        }
        if (CharacterManager.allSquatTotal >= 10)
        {
            cosName[13].text = "�L�����V�[";
            defaultButtonImage[13].sprite = changeButtonImage[13];
        }
        if (CharacterManager.allSquatTotal >= 20)
        {
            cosName[14].text = "��";
            defaultButtonImage[14].sprite = changeButtonImage[14];
        }


        //-----���O�C�������ɂ��ߑ��J���̏���-----//
        if (LoginBonus.LoginInt >= 1)
        {
            cosName[8].text = "�o�j�[";
            defaultButtonImage[8].sprite = changeButtonImage[8];
        }
        if (LoginBonus.LoginInt >= 3)
        {
            cosName[9].text = "�o�j�[�i���[�X�j";
            defaultButtonImage[9].sprite = changeButtonImage[9];
        }
        if (LoginBonus.LoginInt >= 7)
        {
            cosName[10].text = "�t�o�j�[";
            defaultButtonImage[10].sprite = changeButtonImage[10];
        }


        //-----�ߑ��J���ʒm�̏���-----//
        if (release == true)
        {
            // �m�[�}���X�N���b�g�̉񐔂ɂ�����ʒm
            if (CharacterManager.NormalSquatTotal == 1 || CharacterManager.NormalSquatTotal == 3 || CharacterManager.NormalSquatTotal == 5)
            {
                CostumeOpen();
            }

            // �N�I�[�^�[�X�N���b�g�̉񐔂ɂ�����ʒm
            if (CharacterManager.quarterSquatTotal == 1 || CharacterManager.quarterSquatTotal == 3 || CharacterManager.quarterSquatTotal == 5)
            {
                CostumeOpen();
            }

            // ���C�h�X�N���b�g�̉񐔂ɂ�����ʒm
            if (CharacterManager.wideSquatTotal == 1 || CharacterManager.wideSquatTotal == 3 || CharacterManager.wideSquatTotal == 5)
            {
                CostumeOpen();
            }


            // �S�X�N���b�g�̃g�[�^���̉񐔂ɂ�����ʒm
            if (CharacterManager.allSquatTotal == 5 || CharacterManager.allSquatTotal == 10 || CharacterManager.allSquatTotal == 20)
            {
                CostumeOpen();
            }


        }

        // ���O�C�������̌o�ߓ��ɂ�����ʒm
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
    /// IMERIS�̋��̑傫����ύX���鏈��
    /// </summary>
    /// <param name="B">���̑傫���̒l</param>
    public void hadaka_cos(int B)
    {
        costumeBodyTag = GameObject.FindGameObjectWithTag("body");
        body_skinnedmeshRenderer = costumeBodyTag.GetComponent<SkinnedMeshRenderer>();
        B_Index = body_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Breast_big");
        body_skinnedmeshRenderer.SetBlendShapeWeight(B_Index, B);
    }

    /// <summary>
    /// IMERIS�̑��̊p�x�𒲐����鏈��
    /// </summary>
    /// <param name="F">���̊p�x�̒l</param>
    public void foot(int F)
    {
        costumeBodyTag = GameObject.FindGameObjectWithTag("body");
        foot_skinnedmeshRenderer = costumeBodyTag.GetComponent<SkinnedMeshRenderer>();
        F_Index = foot_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Foot_hill");
        foot_skinnedmeshRenderer.SetBlendShapeWeight(F_Index, F);
    }


    /// <summary>
    /// �C�ӂ̈ߑ��ɒ��ւ���
    /// </summary>
    /// <param name="footP">���̊p�x�̒l</param>
    /// <param name="hadakaP">���̑傫���̒l</param>
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
    /// ���ɂȂ�@cosname5
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
    /// summer�ɒ��ւ���
    /// </summary>
    public void ChangeCos_summer()
    {
        CosChange(0, 50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Summer);
    }


    /// <summary>
    /// nurse�ɒ��ւ���
    /// </summary>
    public void ChangeCos_Nurse()
    {
        CosChange(1, 50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Nurse);

    }


    /// <summary>
    /// �f�t�H���g�̉����ɒ��ւ���
    /// </summary>
    public void ChangeCos_DefUnder()
    {
        CosChange(2, 0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Def_Under);
    }


    /// <summary>
    /// �}�C�N���r�L�j_���ɒ��ւ��� cosname0
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
    /// �}�C�N���r�L�j_���ɒ��ւ��� cosname1
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
    /// �~�R�����ɒ��ւ��� cosname2
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
    /// �~�R�����ɒ��ւ��� cosname3
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
    /// �o�j�[���ɒ��ւ��� cosname4
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
    /// �o�j�[�����[�X�ɒ��ւ��� cosname5
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
    /// �t�o�j�[�ɒ��ւ��� cosname6
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
    /// �u���}�ɒ��ւ��� cosname7
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
    /// �x���g�Z�[���[���ɒ��ւ��� cosname8
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
    /// �x���g�Z�[���[�Ԃɒ��ւ��� cosname9
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
    /// �L�����V�[�ɒ��ւ��� cosname10
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
    /// �Z�[�^�[�x�[�W���ɒ��ւ��� cosname11
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
    /// �Z�[�^�[���ɒ��ւ��� cosname12
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
    /// �Z�[�^�[���ɒ��ւ��� cosname13
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
    /// ���O�C���������A�O��I�����̈ߑ��ɒ��ւ���
    /// </summary>
    /// <param name="footP">���̊p�x�̒l</param>
    /// <param name="hadakaP">���̑傫���̒l</param>
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
    /// ���ɂȂ�@cosname5
    /// </summary>
    public void ChangeCos_hadakaD()
    {
        LoginCostume(0, 100);
        hadakaBool = true;
    }


    /// <summary>
    /// summer�ɒ��ւ���
    /// </summary>
    public void ChangeCos_summerD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Summer);
    }


    /// <summary>
    /// nurse�ɒ��ւ���
    /// </summary>
    public void ChangeCos_NurseD()
    {
        LoginCostume(50, 80);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Nurse);
    }


    /// <summary>
    /// �f�t�H���g�̉����ɒ��ւ���
    /// </summary>
    public void ChangeCos_DefUnderD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Def_Under);
    }


    /// <summary>
    /// �}�C�N���r�L�j_���ɒ��ւ��� cosname0
    /// </summary>
    public void ChangeCos_BikiniWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_W);
    }


    /// <summary>
    /// �}�C�N���r�L�j_���ɒ��ւ��� cosname1
    /// </summary>
    public void ChangeCos_BikiniBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bikini_B);
    }


    /// <summary>
    /// �~�R�����ɒ��ւ��� cosname2
    /// </summary>
    public void ChangeCos_MikoWD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_W);
    }


    /// <summary>
    /// �~�R�����ɒ��ւ��� cosname3
    /// </summary>
    public void ChangeCos_MikoBD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Miko_B);
    }


    /// <summary>
    /// �o�j�[���ɒ��ւ��� cosname4
    /// </summary>
    public void ChangeCos_BunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny);
    }


    /// <summary>
    /// �o�j�[�����[�X�ɒ��ւ��� cosname5
    /// </summary>
    public void ChangeCos_BunnyLaceD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Bunny_Lace);
    }


    /// <summary>
    /// �t�o�j�[�ɒ��ւ��� cosname6
    /// </summary>
    public void ChangeCos_ReBunnyD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.ReBunny);
    }


    /// <summary>
    /// �u���}�ɒ��ւ��� cosname7
    /// </summary>
    public void ChangeCos_BurumaD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Buruma);
    }


    /// <summary>
    /// �x���g�Z�[���[���ɒ��ւ��� cosname8
    /// </summary>
    public void ChangeCos_BeltSailorBD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_B);
    }


    /// <summary>
    /// �x���g�Z�[���[�Ԃɒ��ւ��� cosname9
    /// </summary>
    public void ChangeCos_BeltSailorRD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.BeltSailor_R);
    }


    /// <summary>
    /// �L�����V�[�ɒ��ւ��� cosname10
    /// </summary>
    public void ChangeCos_JiangshiD()
    {
        LoginCostume(0, 95);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.Jiangshi);
    }


    /// <summary>
    /// �Z�[�^�[�x�[�W���ɒ��ւ��� cosname11
    /// </summary>
    public void ChangeCos_SlingSweater_BeigeD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Beige);
    }


    /// <summary>
    /// �Z�[�^�[���ɒ��ւ��� cosname12
    /// </summary>
    public void ChangeCos_SlingSweater_BlackD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_Black);
    }


    /// <summary>
    /// �Z�[�^�[���ɒ��ւ��� cosname13
    /// </summary>
    public void ChangeCos_SlingSweater_WhiteD()
    {
        LoginCostume(0, 90);
        CharacterManager.Instance.OnCostume(CostumeData.Costume.SlingSweater_White);
    }
}
