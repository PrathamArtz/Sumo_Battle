using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public int enemyCount;
    public int wavNumber = 1;
    private float spawnrange = 9.0f;

    void Start()
    {
        SpawnEnemyWave(wavNumber);
        Instantiate(powerUpPrefab, GenrateRandomPosition(), powerUpPrefab.transform.rotation);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            wavNumber++;
            SpawnEnemyWave(wavNumber);
            Instantiate(powerUpPrefab, GenrateRandomPosition(),powerUpPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiestospawn)
    {
        for (int i = 0; i < enemiestospawn; i++)
        {
            Instantiate(enemyPrefab, GenrateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenrateRandomPosition()
    {

        float spawnX = Random.Range(-spawnrange, spawnrange);
        float spawnZ = Random.Range(-spawnrange, spawnrange);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }

}
