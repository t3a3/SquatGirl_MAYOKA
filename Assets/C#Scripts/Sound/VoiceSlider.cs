using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceSlider : MonoBehaviour
{
    /*���֘A*/
    GameObject Find_SoundManager;
    AudioSource audioSource;


    void Start()
    {
            //�X���C�_�[��value��SoundManager.cs��bgmVol�ɍ��킹��
            Slider slider = this.gameObject.GetComponentInChildren<Slider>();
            slider.value = VoiceManager.VoiceVol;

            //SoundManager�I�u�W�F�N�g�A�I�[�f�B�I�\�[�X�擾
            Find_SoundManager = GameObject.Find("VoiceManager");
            audioSource = Find_SoundManager.GetComponent<AudioSource>();

            //�I�[�f�B�I�\�[�X�̉��ʂƁASoundManager.cs��bgmVol�����킹��
            audioSource.volume = VoiceManager.VoiceVol;

            //�X���C�_�[�𓮂����ƁASoundManager�̃I�[�f�B�I�\�[�X��Volume�Ɠ���������
            slider.onValueChanged.AddListener((float value) =>
            {
                if (VoiceManager.VoiceOnOff == true)
                {
                    audioSource.volume = value;
                    VoiceManager.VoiceVol = audioSource.volume;
                    PlayerPrefs.SetFloat("VOICE", VoiceManager.VoiceVol);
                    PlayerPrefs.Save();
                }
            });
      
    }
}
