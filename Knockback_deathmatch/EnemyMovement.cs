using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _speed = 1.5f;

    private Rigidbody _ememyRb;

    private GameObject _player;
   

    // Start is called before the first frame update
    void Start()
    {
        _ememyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
        
    }

    void Update()
    {
        if (_player != null) 
        {
            Vector3 lookAtPlayer = _player.transform.position - transform.position;
            _ememyRb.AddForce(lookAtPlayer * _speed * Time.deltaTime, ForceMode.Impulse);
        }
        
    }
}
