using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _obstacles = new GameObject[6];
    private Quaternion _rotation;

    private PlayerController _playerController;

    private void SpawnObstacles()
    {
        Vector3 _spawnPos = new Vector3(100, 0.5f, 0);

        if (_playerController._gameOver == false)
        {
            Instantiate(_obstacles[Random.Range(0, 6)], _spawnPos, _rotation);
        }
             
    }



    void Start()
    {
        InvokeRepeating("SpawnObstacles", 2, 2);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

}
