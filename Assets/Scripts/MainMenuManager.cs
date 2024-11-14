using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SkillsSO[] skillsSO;
    private GameData gameData;

    // button event
    public void NewGame()
    {
        SceneManager.LoadScene("Level 1");
        NewGameData();
        FileHandler.SaveToJSON<GameData>(gameData, "GameData.json");
    }

    public void NewGameData()
    {
        List<SkillUpgradeData> upgradeDataList = new List<SkillUpgradeData>();
        foreach (var skill in skillsSO)
        {
            SkillUpgradeData upgradeData = new SkillUpgradeData(skill.skillName, skill.cooldown,
            skill.damage, skill.level, skill.range);
            upgradeDataList.Add(upgradeData);
            gameData = new GameData(1, 20, 500, 0, upgradeDataList);
        }
    }

    public void SettingGame()
    {
        SceneManager.LoadScene("AudioSetting");
    }

    public void Continue()
    {

    }

    public void Ranking()
    {

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
