using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private StarSO starSO;
    [SerializeField] private LevelSO[] levelSO;
    [SerializeField] private LevelSO[] defaultLevelSO;
    [SerializeField] private SkillsSO[] skillsSO;
    [SerializeField] private SkillsSO[] defaultSkillsSO;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultData()
    {
        var skillsData = GameManager.Instance.GenerateSkillUpgradeData(GameManager.Instance.defaultSkillsSO);
        var levelsData = GameManager.Instance.GenerateLevelData(GameManager.Instance.defaultLevelSO);
        GameData gameData = new GameData(5, skillsData, levelsData);
        FileHandler.SaveToJSON<GameData>( gameData, "DefaultGameData.json");
    }

    public void SaveData()
    {
        var skillsData = GameManager.Instance.GenerateSkillUpgradeData(GameManager.Instance.skillsSO);
        var levelsData = GameManager.Instance.GenerateLevelData(GameManager.Instance.levelSO);
        GameData gameData = new GameData(GameManager.Instance.starSO.starCurrent, skillsData, levelsData);
        FileHandler.SaveToJSON<GameData>(gameData, "GameData.json");
    }

    public void LoadData()
    {
        // Đọc dữ liệu từ file JSON
        GameData gameData = FileHandler.ReadFromJSON<GameData>("GameData.json");

        // Áp dụng dữ liệu vào các ScriptableObject hoặc thuộc tính trong GameManager
        starSO.starCurrent = gameData.starCurrency;

        for (int i = 0; i < gameData.skills.Count; i++)
        {
            if (i < skillsSO.Length)
            {
                skillsSO[i].skillName = gameData.skills[i].skillName;
                skillsSO[i].cooldown = gameData.skills[i].cooldown;
                skillsSO[i].damage = gameData.skills[i].damage;
                skillsSO[i].level = gameData.skills[i].level;
                skillsSO[i].range = gameData.skills[i].range;
            }
        }

        for (int i = 0; i < gameData.levels.Count; i++)
        {
            if (i < levelSO.Length)
            {
                levelSO[i].islock = gameData.levels[i].islock;
                levelSO[i].star = gameData.levels[i].star;
                levelSO[i].lives = gameData.levels[i].lives;
                levelSO[i].currency = gameData.levels[i].currency;
            }
        }
    }

    public void GetDefaultData()
    {
        // Đọc dữ liệu từ file JSON
        GameData gameData = FileHandler.ReadFromJSON<GameData>("DefaultGameData.json");

        // Áp dụng dữ liệu vào các ScriptableObject hoặc thuộc tính trong GameManager
        starSO.starCurrent = gameData.starCurrency;

        for (int i = 0; i < gameData.skills.Count; i++)
        {
            if (i < skillsSO.Length)
            {
                skillsSO[i].skillName = gameData.skills[i].skillName;
                skillsSO[i].cooldown = gameData.skills[i].cooldown;
                skillsSO[i].damage = gameData.skills[i].damage;
                skillsSO[i].level = gameData.skills[i].level;
                skillsSO[i].range = gameData.skills[i].range;
            }
        }

        for (int i = 0; i < gameData.levels.Count; i++)
        {
            if (i < levelSO.Length)
            {
                levelSO[i].islock = gameData.levels[i].islock;
                levelSO[i].star = gameData.levels[i].star;
                levelSO[i].lives = gameData.levels[i].lives;
                levelSO[i].currency = gameData.levels[i].currency;
            }
        }
    }

    // tao ra danh sach skilldata
    private List<SkillUpgradeData> GenerateSkillUpgradeData(SkillsSO[] skills)
    {
        List<SkillUpgradeData> upgradeDataList = new List<SkillUpgradeData>();
        foreach (var skill in skills)
        {
            upgradeDataList.Add(new SkillUpgradeData(skill.skillName, skill.cooldown, skill.damage, skill.level, skill.range));
        }
        return upgradeDataList;
    }

    // tao ra danh sach leveldata
    private List<LevelData> GenerateLevelData(LevelSO[] levels)
    {
        List<LevelData> levelDataList = new List<LevelData>();
        foreach (var level in levels)
        {
            levelDataList.Add(new LevelData(level.islock, level.star, level.lives, level.currency));
        }
        return levelDataList;
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
