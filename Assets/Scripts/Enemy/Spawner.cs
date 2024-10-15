using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// su dung class nay de sinh ra ke dich

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnTime = 2f;
    private float repeatTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemies());
        InvokeRepeating("SpawnEnemy", spawnTime, repeatTime);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
