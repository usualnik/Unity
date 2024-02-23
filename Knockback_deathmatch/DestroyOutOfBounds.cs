using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float destroyOutOfYAxis = -2f;
    private SpawnManager enemiesOnTheScene;
    private SpawnManager spawnNewWaveOfEnemies;
    private bool isGameOver = false;
    
    private PlayerController player;

    void Start()
    {
        enemiesOnTheScene = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        spawnNewWaveOfEnemies = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>(); 

    }

  
    void Update()
    {

        if (player.gameObject == null)
        {
            isGameOver = true;
        }


        DestroyOutOfY();
    }

    private void DestroyOutOfY()
    {
        if (transform.position.y < destroyOutOfYAxis)
        {
            Destroy(gameObject);
            enemiesOnTheScene.enemiesOnTheScene--;
        }
        else if (enemiesOnTheScene.enemiesOnTheScene == 0 && !isGameOver)
        {
            spawnNewWaveOfEnemies.SpawnEnemy(spawnNewWaveOfEnemies.enemiesToSpawn++);
        }
    }


}
