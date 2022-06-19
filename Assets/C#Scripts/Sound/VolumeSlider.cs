using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    /*���֘A*/
    GameObject Find_SoundManager;
    AudioSource audioSource;


    void Start()
    {
        
        //SoundManager�I�u�W�F�N�g�A�I�[�f�B�I�\�[�X�擾
        Find_SoundManager = GameObject.Find("SoundManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();

        //�X���C�_�[��value��SoundManager.cs��bgmVol�ɍ��킹��
        Slider slider = this.gameObject.GetComponentInChildren<Slider>();
        slider.value = SoundManager.bgmVol;


        //�I�[�f�B�I�\�[�X�̉��ʂƁASoundManager.cs��bgmVol�����킹��
        audioSource.volume = SoundManager.bgmVol;
     
        //�X���C�_�[�𓮂����ƁASoundManager�̃I�[�f�B�I�\�[�X��Volume�Ɠ���������
        slider.onValueChanged.AddListener((float value) => {
            audioSource.volume = value;
            SoundManager.bgmVol = audioSource.volume;
            PlayerPrefs.SetFloat("BGM", SoundManager.bgmVol);
            PlayerPrefs.Save();
        });
    }
}
