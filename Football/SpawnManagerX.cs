using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyX[] enemysRef;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount = 1;
    public int waveCount = 1;
    
    public bool newWaveJustSpawned;
   
    public GameObject player;

    void Update()
    {
        enemysRef = FindObjectsOfType<EnemyX>();
        enemyCount = enemysRef.Length;
        
        //Debug.Log(newWaveJustSpawned);

        if (enemyCount == 0 && !newWaveJustSpawned)        
        {
            SpawnEnemyWave(waveCount, true);
        }
        else
        {
            newWaveJustSpawned = false;
        }
        
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            SpawnPowerUp();
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn, bool isNewWave)
    {
        newWaveJustSpawned = isNewWave; 
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        foreach (EnemyX enemy in enemysRef)
        {

            enemy.speed = 500f;
        }


        waveCount++;
        ResetPlayerPosition(); // put player back at start
        
    }

    private void SpawnPowerUp()
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end
        Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        ResetPlayerPosition();
    }



    // Move player back to position in front of own goal
    void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
