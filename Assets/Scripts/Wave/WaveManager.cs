using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// Tạo ra các đợt kẻ thù

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveSO[] waveSO;
    [SerializeField] private Text waveNumber;
    [SerializeField] private Text waveTimer;

    private float waveInterval = 4f;
    private float spawnTime = 0f;
    private float repeatTime = 0.5f;
    private int currentWaveIndex = 0;
    private int enemyIndex = 0;
    private int[] currentNumberOfEnemies;

    void Start()
    {
        SetWaveNumber();
        StartCoroutine(CountdownToNextWave());
    }

    public void SpawnEnemy()
    {
        if (currentWaveIndex < waveSO.Length)
        {
            SetWaveNumber();
            if (currentNumberOfEnemies[enemyIndex] > 0)
            {
                GameObject enemy = Instantiate(waveSO[currentWaveIndex].pfEnemies[enemyIndex], transform.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().waypointManager = transform.GetComponentInParent<WaypointManager>();
                InGameManager.main.lastEnemyCount++;
                currentNumberOfEnemies[enemyIndex]--;
            }
            else
            {
                enemyIndex++;
            }
            if (enemyIndex >= waveSO[currentWaveIndex].pfEnemies.Length)
            {
                enemyIndex = 0;
                if (InGameManager.main.lastEnemyCount == 0)
                {
                    currentWaveIndex++;
                    CancelInvoke("SpawnEnemy");
                    if (currentWaveIndex < waveSO.Length)
                    {
                        if ( currentWaveIndex == 14)
                        {
                            InGameManager.main.outOfEnemies = true;
                            Debug.Log("Out of enemy");
                        }
                        StartCoroutine(CountdownToNextWave());
                    }
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

    private IEnumerator CountdownToNextWave()
    {
        float remainingTime = waveInterval;

        while (remainingTime > 0)
        {
            if (waveTimer != null)
                waveTimer.text = "Next wave in: " + Mathf.CeilToInt(remainingTime).ToString() + "s";
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        if (waveTimer != null)
            waveTimer.text = ""; // Xóa text khi thời gian đếm ngược kết thúc
        Initialize(); // Bắt đầu wave tiếp theo
    }

    public void SetWaveNumber()
    {
        waveNumber.text = (currentWaveIndex + 1).ToString() + "/" + waveSO.Length.ToString();
    }
}
