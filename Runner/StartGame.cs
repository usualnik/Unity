using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // When player reaches this point, game will start
    private float startingPointX = 70f;

    private float startingSpeed = 3f;


    //Reference to all gameplay scripts
    private ObjectMovement objectMovementRef;
    private SpawnManager spawnManagerRef;
    private PlayerController playerControllerRef;
    private ScoreManager scoreManagerRef;




    void Start()
    {
        objectMovementRef = GameObject.Find("Background").GetComponent<ObjectMovement>();
        spawnManagerRef = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        playerControllerRef = GetComponent<PlayerController>();
        scoreManagerRef = GameObject.Find("Canvas").GetComponentInChildren<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startingPointX)
        {
            WalkToStartingPoint();
        }
        else
        {
            RunGame();
        }


    }

    private void WalkToStartingPoint()
    {


        transform.Translate(Vector3.forward * startingSpeed * Time.deltaTime);


    }

    //Turn on all gameplay scripts.
    private void RunGame()
    {
        objectMovementRef.enabled = true;
        spawnManagerRef.enabled = true;
        playerControllerRef.enabled = true;
        scoreManagerRef.enabled = true;

    }

}
