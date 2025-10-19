using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AbaikanSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject[] prefabEnemies;
    public Transform[] spawnPoints;

    [Header("Runtime Checker")]
    public List<GameObject> listActiveEnemies = new List<GameObject>();

    [Header("Spawner Stats")]
    public int maxEnemyCount;
    public float spawnInterval = 3f;

    [Header("Flags")]
    private bool isEnemySpawned;

    private void Start()
    {
        isEnemySpawned = false;
    }

    private void Update()
    {
        if (isEnemySpawned && listActiveEnemies.Count < maxEnemyCount)
        {
            StartCoroutine(enemySpawn());
        }
    }

    private IEnumerator enemySpawn()
    {
        isEnemySpawned =true;

        int randomizerSpawn = Random.Range(0, spawnPoints.Length);
        int randomizerEnemy = Random.Range(0, prefabEnemies.Length);

        GameObject Enemies = Instantiate(prefabEnemies[randomizerEnemy], spawnPoints[randomizerSpawn]);

        listActiveEnemies.Add(Enemies);

        yield return new WaitForSeconds(spawnInterval);

        isEnemySpawned = false;

    }
}
