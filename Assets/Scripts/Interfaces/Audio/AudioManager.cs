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

    private bool checkQuit = false;

    private static bool musicAlreadyPlaying = false; //biến tính kiểm tra nhạc đã phát chưa nếu rồi thì tiếp tục


    public static AudioManager instance;
    private void Start()
    {
        setBackgroundMusic();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void setBackgroundMusic()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName != "Level 1")
        {
            // Nhạc nền (không phải game)
            if (musicSource != null && musicSource.clip != background)
            {
                musicSource.Stop();
                musicSource.clip = background;
                musicSource.loop = true;
                musicSource.Play();
            }
            if (gameMusicSource != null) gameMusicSource.Stop();
        }
        else
        {
            // Nhạc game (Level 1)
            if (gameMusicSource != null && gameMusicSource.clip != gameMusic)
            {
                if (musicSource != null && musicSource.isPlaying)
                {
                    musicSource.Stop();
                }
                gameMusicSource.clip = gameMusic;
                gameMusicSource.loop = true;
                gameMusicSource.Play();
            }
            if( sceneName != "Level 1")
            {
                musicSource.clip = background;
                musicSource.loop = true;
                musicSource.Play();
            }

        }
    }
    private void PlaySound()
    {
        sFXSource.clip = click;
        sFXSource.PlayOneShot(click);
    }
    private void Awake()
    {
        //if (!musicAlreadyPlaying) {
        //    musicAlreadyPlaying=true;
        //    setBackgroundMusic();
        //}
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        setBackgroundMusic(); // Cập nhật nhạc nền theo Scene
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        checkQuit = true;
    }
}
