using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;

public class CubeData : MonoBehaviour
{
    public int cubeIndex;
    private SpawnCubes spawnCubes;
    private bool allowSpawnNewCubes = false;


    private void Start()
    {
        spawnCubes = GameObject.Find("Spawn").GetComponent<SpawnCubes>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (cubeIndex.ToString() == collision.gameObject.tag)
        {
            

            //Destroy(gameObject);

            //spawnCubes.GenerateNewCube(cubeIndex, collision.gameObject.transform.position);
        }
    }



    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (cubeIndex.ToString() == collision.gameObject.tag)
    //    {
    //        Debug.Log("Collision");

    //        //Destroy(gameObject);

    //        //spawnCubes.GenerateNewCube(cubeIndex, collision.gameObject.transform.position);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (cubeIndex.ToString() == other.gameObject.tag)
    //    {
    //        Debug.Log("Trigger");

    //        //Destroy(gameObject);

    //        //spawnCubes.GenerateNewCube(cubeIndex, collision.gameObject.transform.position);
    //    }
    //}


}
