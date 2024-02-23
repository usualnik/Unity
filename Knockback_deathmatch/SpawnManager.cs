using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _enemyPrefab;
    public int enemiesToSpawn = 1;
    public int enemiesOnTheScene = 0;

    public GameObject powerUp;

    void Start()
    {
        SpawnEnemy(enemiesToSpawn);
        InvokeRepeating("SpawnPowerUp", 10f, Random.Range(10f, 20f));
    }


    private void Update()
    {
        
    }


    public void SpawnEnemy(int enemiesToSpawn)
    {

        for (int i = 1; i < enemiesToSpawn; i++)
        {
            Instantiate(_enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
            enemiesOnTheScene++;
        }

    }


    private Vector3 GenerateSpawnPosition()
    {
        Vector3 _enemySpawnPosition = new Vector3(Random.Range(-9, 10), 0.3f, Random.Range(-10, 11));
        return _enemySpawnPosition;
    }

    private void SpawnPowerUp()
    {
        Vector3 powerUpSpawnPosition = new Vector3(Random.Range(-9, 10), 0.3f, Random.Range(-10, 11));
        Instantiate(powerUp, powerUpSpawnPosition, Quaternion.identity);
    }

}
