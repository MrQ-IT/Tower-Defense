using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VollumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public void SetVollumeMusic()
    {
        float value = musicSlider.value;
        mixer.SetFloat("music",Mathf.Log10(value)*20);
    }
    public void SetVollumeSFX()
    {
        float value = sfxSlider.value;
        mixer.SetFloat("sfx", Mathf.Log10(value) * 20);
    }
}
