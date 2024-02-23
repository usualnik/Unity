using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    

    private float _startDelay = 3f;
    private float _spawnInterval = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalVertical", _startDelay, _spawnInterval);
        InvokeRepeating("SpawnRandomAnimalHorizontal", _startDelay, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
           
       
    }

    void SpawnRandomAnimalVertical()
    {
        float _spawnPosX = 20.0f;
        float _spawnPosZ = 35.0f;

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnLocation = new Vector3(Random.Range(-_spawnPosX, _spawnPosX), 0, _spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnLocation, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalHorizontal()
    {
        float _spawnPosX = 25.0f;
        float _spawnPosZ = 10.0f;
        
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        
        //calculating X-value of spawnlocation
        Vector3 spawnLocation = new Vector3(Random.Range(1, 3), 0, 0);
        Vector3 leftSpawnRotation = new Vector3(0,-90,0);
        Vector3 rightSpawnRotation = new Vector3(0, 90, 0);

        if (spawnLocation.x == 1)
        {
            spawnLocation = new Vector3(_spawnPosX, 0, Random.Range(-_spawnPosZ, _spawnPosZ));
            Instantiate(animalPrefabs[animalIndex], spawnLocation, Quaternion.Euler(leftSpawnRotation));


        }
        else
        {
            spawnLocation = new Vector3(-_spawnPosX, 0, Random.Range(-_spawnPosZ, _spawnPosZ));
            Instantiate(animalPrefabs[animalIndex], spawnLocation, Quaternion.Euler(rightSpawnRotation));
            
        }


    }
}
