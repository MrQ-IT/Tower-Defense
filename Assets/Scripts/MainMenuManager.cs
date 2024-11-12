using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Các phương thức cho các nút
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

   public void SettingGame()
    {
        SceneManager.LoadScene("AudioSetting");
    }

       public void AchivementGame()
    {
        SceneManager.LoadScene("AchievementsScene");
    }

   public void EncyclopediaGame()
    {
        SceneManager.LoadScene("EncyclopediaScene");
    }

   public void QuitGame()
    {
        // Thoát ứng dụng
        Application.Quit();
        #if UNITY_EDITOR
        // Chỉ hoạt động trong Unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/profile.php?id=100041599939052");
    }

    public void OpenZalo()
    {
        Application.OpenURL("https://zalo.me/g/igzuxk242");
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/MrQ-IT/Project1");
    }
}
