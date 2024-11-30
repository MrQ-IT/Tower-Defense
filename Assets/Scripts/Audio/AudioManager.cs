using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    [Header("-------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource gameMusicSource;
    [SerializeField] AudioSource sFXSource;



    [Header("-------------Audio Clip-------------")]
    public AudioClip background;
    public AudioClip gameMusic;
    public AudioClip click;

    public static AudioManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Hủy đối tượng mới tạo nếu đã có instance tồn tại
            return;
        }
        SetBackgroundMusic();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SetBackgroundMusic();
    }

    public void SetBackgroundMusic()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex >= 6)
        {
            if (gameMusicSource != null && gameMusicSource.clip != gameMusic)
            {
                if (musicSource != null && musicSource.isPlaying)
                {
                    musicSource.Stop();
                    musicSource.clip = null;
                }
                gameMusicSource.clip = gameMusic;
                gameMusicSource.Play();
            }
        }
        else
        {
            if (musicSource != null && musicSource.clip != background)
            {
                if (gameMusicSource != null && gameMusicSource.isPlaying)
                {
                    gameMusicSource.Stop();
                    gameMusicSource.clip = null;
                }

                musicSource.clip = background;
                if (!musicSource.isPlaying)
                {
                    musicSource.Play();
                }
            }
        }
    }


    private void PlaySound()
    {
        sFXSource.clip = click;
        sFXSource.PlayOneShot(click);
    }

}
