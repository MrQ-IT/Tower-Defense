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

    public Button sFX;
    public Image sFXOld;
    public Sprite sFXNew;
    public Sprite sFXOriginal;

    public Button music;
    public Image musicOld;
    public Sprite musicNew;
    public Sprite musicOriginal;

    private bool isToggledMusic = false;
    private bool isToggledSFX = false;


    public void Start()
    {
        sFXOriginal = sFXOld.sprite;
        musicOriginal = musicOld.sprite;
        sFX.onClick.AddListener(toggleSFXImage);
        music.onClick.AddListener(toggleMusicImage);
    }
    public void toggleSFXImage()
    {
        float value = sfxSlider.value;
        if (isToggledSFX)
        {
            sFXOld.sprite = sFXOriginal;
            isToggledSFX = false;
            mixer.SetFloat("sfx", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
            sfxSlider.value = 1;
            sfxSlider.enabled = true;
            
        }
        else
        {
            sFXOld.sprite = sFXNew;
            isToggledSFX = true;
            mixer.SetFloat("sfx", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20 - 80);
            sfxSlider.value = 1/1000;
            sfxSlider.enabled = false;
        }

    }
    public void toggleMusicImage()
    {
        float value = musicSlider.value;
        if (isToggledMusic)
        {
            musicOld.sprite = musicOriginal;
            isToggledMusic = false;
            mixer.SetFloat("music", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
            musicSlider.value = 1;
            musicSlider.enabled = true;
        }
        else
        {
            
            musicOld.sprite = musicNew;
            isToggledMusic = true;
            mixer.SetFloat("music", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20 - 80);
            musicSlider.value = 0;
            musicSlider.enabled = false;
        }
    }
    public void SetVollumeMusic()
    {
        float value = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);

    }
    public void SetVollumeSFX()
    {
        float value = sfxSlider.value;
        mixer.SetFloat("sfx", Mathf.Log10(value) * 20);
    }
}
