using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Tạo ra các đợt kẻ thù

public class WaveManager : MonoBehaviour
{
    public static WaveManager main;
    [SerializeField] private WaveSO[] waveSO;
    [SerializeField] private Text waveNumber;
    private float waveInterval = 15f;
    private float spawnTime = 2f;
    private float repeatTime = 0.5f;
    private int currentWaveIndex = 0;
    private int enemyIndex = 0;
    private int[] currentNumberOfEnemies;
    public int lastEnemyCount = 0;
    public bool outOfEnemies = false;

    void Start()
    {   
        main = this;
        SetWaveNumber();
        Initialize();
    }

    public void SpawnEnemy()
    {
        if (currentWaveIndex < waveSO.Length)
        {
            SetWaveNumber();
            if (currentNumberOfEnemies[enemyIndex] > 0)
            {
                Instantiate(waveSO[currentWaveIndex].pfEnemies[enemyIndex], transform.position, Quaternion.identity);
                lastEnemyCount++;
                currentNumberOfEnemies[enemyIndex]--;
            }
            else
            {
                enemyIndex++;
            }
            if (enemyIndex >= waveSO[currentWaveIndex].pfEnemies.Length)
            {
                currentWaveIndex++;
                enemyIndex = 0;
                CancelInvoke("SpawnEnemy");
                if (currentWaveIndex < waveSO.Length)
                {
                    Invoke("Initialize", waveInterval);
                }
                else
                {
                    outOfEnemies = true;
                    Debug.Log("Out of enemy");
                }
            }
        }
    }

    public void Initialize()
    {
        if (currentWaveIndex < waveSO.Length)
        {
            currentNumberOfEnemies = new int[waveSO[currentWaveIndex].numberOfEnemy.Length];
            for (int i = 0; i < waveSO[currentWaveIndex].numberOfEnemy.Length; i++)
            {
                currentNumberOfEnemies[i] = waveSO[currentWaveIndex].numberOfEnemy[i];
            }
        }
        InvokeRepeating("SpawnEnemy", spawnTime, repeatTime);
    }

    public void SetWaveNumber()
    {
        waveNumber.text = (currentWaveIndex + 1).ToString() + "/" + waveSO.Length.ToString();
    }
}
