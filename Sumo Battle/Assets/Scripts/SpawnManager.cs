using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float spawnrange = 9.0f;

     void Start()
    {
        float spawnX = Random.Range(-spawnrange, spawnrange);
        float spawnZ = Random.Range(-spawnrange, spawnrange);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);

        Instantiate(enemyPrefab, randomPos , enemyPrefab.transform.rotation);
    }
}