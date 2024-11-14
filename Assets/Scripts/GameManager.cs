using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int starCurrency { get; set; }
    public List<SkillUpgradeData> skills = new List<SkillUpgradeData>();

    private void Start()
    {
        if ( Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
