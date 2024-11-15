using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour
{
    public static bool IsMapUnlocked(int mapLevel)
    {
        return PlayerPrefs.GetInt($"MapUnlocked_Level{mapLevel}", 0) == 1; //default = 0 
    }

    //unlock map

    public static void UnlockMap(int mapLevel)
    {
        PlayerPrefs.SetInt($"MapUnlocked_Level{mapLevel}", 1);
        PlayerPrefs.Save();
    }

    //delete all data
    public static void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
