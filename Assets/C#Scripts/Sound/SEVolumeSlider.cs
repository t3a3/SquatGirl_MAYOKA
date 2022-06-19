using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SEVolumeSlider : MonoBehaviour
{
    /*���֘A*/
    GameObject Find_SoundManager;
    AudioSource audioSource;


    void Start()
    {
        //�X���C�_�[��value��SoundManager.cs��bgmVol�ɍ��킹��
        Slider slider = this.gameObject.GetComponentInChildren<Slider>();
        slider.value = SEManager.SeVol;

        //SoundManager�I�u�W�F�N�g�A�I�[�f�B�I�\�[�X�擾
        Find_SoundManager = GameObject.Find("SEManager");
        audioSource = Find_SoundManager.GetComponent<AudioSource>();

        //�I�[�f�B�I�\�[�X�̉��ʂƁASoundManager.cs��SeVol�����킹��
        audioSource.volume = SEManager.SeVol;

        //�X���C�_�[�𓮂����ƁASoundManager�̃I�[�f�B�I�\�[�X��Volume�Ɠ���������
        slider.onValueChanged.AddListener((float value) => {
            
            if (SEManager.SEOnOff==true)
            {
                audioSource.volume = value;
                SEManager.SeVol = audioSource.volume;
                PlayerPrefs.SetFloat("SE", SEManager.SeVol);
                PlayerPrefs.Save();

            }
        });
    }
}
