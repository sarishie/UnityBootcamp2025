using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Reference")]
    public Transform[] spawnPointsTransform;
    public GameObject[] enemyPrefabs;

    [Header("Runtime Tracking")]
    public List<EnemyBase> listActiveEnemies = new List<EnemyBase>();


    [Header("Spawn Stats")]
    public int spawnInterval;
    public int maxEnemyInArea;

    [Header("Requirement")]
    public bool isEnemySpawned = false;
    
    

    private void Start()
    {
        isEnemySpawned = false;
    }

    private void Update()
    {
        if (!isEnemySpawned && listActiveEnemies.Count < maxEnemyInArea)
        {
            StartCoroutine(SpawnEnemy());
        }

        TestDamage();
    }

    private IEnumerator SpawnEnemy()
    {
        isEnemySpawned = true;
        int randomSpawnNumber;
        int randomEnemyPrefab;

        // Acak Spawn Points dan Enemy Prefab
        randomSpawnNumber = Random.Range(0, spawnPointsTransform.Length);
        randomEnemyPrefab = Random.Range(0, enemyPrefabs.Length);

        // instantiate Enemy acak di spawn point yang telah diacak
        EnemyBase newEnemy = Instantiate(enemyPrefabs[randomEnemyPrefab], spawnPointsTransform[randomSpawnNumber]).GetComponent<EnemyBase>();

        // Add Enemy who appear in the hierarchy into List
        listActiveEnemies.Add(newEnemy);

        newEnemy.OnDeath += OnEnemyDied;

        yield return new WaitForSeconds(spawnInterval);

        isEnemySpawned = false;
    }

    public void OnEnemyDied(EnemyBase e)
    {
        if (listActiveEnemies.Contains(e))
        {
            listActiveEnemies.Remove(e);
        }
    }

    public void TestDamage()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (EnemyBase enemy in listActiveEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(50);
            }
        }
    }
}
