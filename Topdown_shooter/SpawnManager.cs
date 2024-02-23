using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemy = new GameObject[2];
    
    private void Start()
    {
        InvokeRepeating("EnemySpawn", 1f, 3f);
    }

    private void EnemySpawn()
    {
        //Randomize enemy
        GameObject randomEnemy = enemy[Random.Range(0, enemy.Length)];


        //Variaty of positions to spawn enemy object
        Vector3 spawnPosUp = new Vector3(Random.Range(-30, 30), 1, 30);
        Vector3 spawnPosLeft = new Vector3(-30, 1, Random.Range(-20, 20));
        Vector3 spawnPosRight = new Vector3(30, 1, Random.Range(-20, 20));

        //Choosing random position to spawn enemy
        Vector3[] spawnPosition = {spawnPosUp, spawnPosLeft, spawnPosRight};
        Vector3 randomPosition = spawnPosition[Random.Range(0, spawnPosition.Length)];



        //Handling the rotation, rotation depends on spawn position.

        Quaternion spawnRotation = Quaternion.identity;


        //Upper Spawn
        if (randomPosition == spawnPosition[0])
        {
            spawnRotation = Quaternion.Euler(0, -180, 0);            
        }
        //Left Spawn
        if (randomPosition == spawnPosition[1])
        {
            spawnRotation = Quaternion.Euler(0, 90, 0);
           
        }
        //Right Spawn
        if (randomPosition == spawnPosition[2])
        {
            spawnRotation = Quaternion.Euler(0, -90, 0);
           
        }

        Instantiate(randomEnemy, randomPosition, spawnRotation);
    }
}
