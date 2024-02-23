using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 _moveLeft = Vector3.left;

    private PlayerControllerX _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }
    private void Update()
    {
         if (!_playerController.gameOver && _playerController != null)
             transform.Translate(_moveLeft * speed * Time.deltaTime);
       
    }





}
