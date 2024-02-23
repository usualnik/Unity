using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.Rendering.VirtualTexturing;

public class SpawnCubes : MonoBehaviour
{
    public GameObject[] cubeVariants;
    
    
    Vector2 offset = new Vector2(0, -1.5f);
    Vector2 spawnPosition;

    void Update()
    {
        spawnPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {

            GenerateCube();

        }

    }


    private void GenerateCube()
    {
       
       Instantiate(cubeVariants[UnityEngine.Random.Range(0, 5)], spawnPosition + offset, Quaternion.identity);
       
    }

    public void GenerateNewCube(int firstValue, Vector3 newSpawnPosition)
    {

        int resultValue = firstValue + firstValue;

        int[] indexArray = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048};

        for (int i = 0; i <= indexArray.Length; i++)
        {
            if (indexArray[i] == resultValue)
            {
                Instantiate(cubeVariants[i], newSpawnPosition, Quaternion.identity);
            }
        }

       


        

        
    }
  

}
