using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("-------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sFXSource;


    [Header("-------------Audio Clip-------------")]
    public AudioClip background;
    public AudioClip click;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
    private void PlaySound()
    {
        sFXSource.clip = click;
        sFXSource.PlayOneShot(click);
    }
    
        public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
