using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
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
        //PlayerPref lưu dữ liệu value của thanh slider
        float saveMusicValue = PlayerPrefs.GetFloat("MusicVolume", 1f); //default is 1 if not saved
        float saveSFXValue = PlayerPrefs.GetFloat("SFXVolume", 1f);

        int saveMuteMusic = PlayerPrefs.GetInt("MuteMusic", 1);
        int saveMuteSFX = PlayerPrefs.GetInt("MuteSFX", 1);

        musicSlider.value = saveMusicValue;
        sfxSlider.value = saveSFXValue;

        // Đặt trạng thái âm thanh
        if (saveMuteMusic == 1) // Nếu trạng thái là muted (1)
        {
            isToggledMusic = true;
            musicOld.sprite = musicNew; // Biểu tượng Muted
            mixer.SetFloat("music", -80f); // Tắt âm thanh
            musicSlider.value = 0; // Đặt giá trị slider
            musicSlider.enabled = false;
        }
        else // Nếu trạng thái là unmute (0)
        {
            isToggledMusic = false;
            musicOld.sprite = musicOriginal; // Biểu tượng Unmuted
            mixer.SetFloat("music", Mathf.Log10(saveMusicValue) * 20); // Áp dụng âm lượng
        }

        if (saveMuteSFX == 1) // Nếu trạng thái là muted (1)
        {
            isToggledSFX = true;
            sFXOld.sprite = sFXNew; // Biểu tượng Muted
            mixer.SetFloat("sfx", -80f); // Tắt hiệu ứng
            sfxSlider.value = 0; // Đặt giá trị slider
            sfxSlider.enabled = false;
        }
        else // Nếu trạng thái là unmute (0)
        {
            isToggledSFX = false;
            sFXOld.sprite = sFXOriginal; // Biểu tượng Unmuted
            mixer.SetFloat("sfx", Mathf.Log10(saveSFXValue) * 20); // Áp dụng âm lượng
        }

        //sFXOriginal = sFXOld.sprite;
        //musicOriginal = musicOld.sprite;
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
            PlayerPrefs.SetFloat("SFXVolume", 1f);
            PlayerPrefs.SetInt("MuteSFX", 0);
        }
        else
        {
            sFXOld.sprite = sFXNew;
            isToggledSFX = true;
            mixer.SetFloat("sfx", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20 - 80);
            sfxSlider.value = 1/1000;
            sfxSlider.enabled = false;
            PlayerPrefs.SetFloat("SFXVolume", 1/1000);
            PlayerPrefs.SetInt("MuteSFX", 1);
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
            PlayerPrefs.SetFloat("MusicVolume", 1f);
            PlayerPrefs.SetInt("MuteMusic", 0);
        }
        else
        {
            
            musicOld.sprite = musicNew;
            isToggledMusic = true;
            mixer.SetFloat("music", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20 - 80);
            musicSlider.value = 0;
            musicSlider.enabled = false;
            PlayerPrefs.SetFloat("MusicVolume", 1/1000);
            PlayerPrefs.SetInt("MuteMusic", 1);
        }
    }
    public void SetVollumeMusic()
    {
        float value = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void SetVollumeSFX()
    {
        float value = sfxSlider.value;
        mixer.SetFloat("sfx", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    // back button
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
