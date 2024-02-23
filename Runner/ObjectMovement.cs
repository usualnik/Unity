using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private float _dashSpeed = 20f;
    private Vector3 movementDir = Vector3.left;    
    private Animator _animator;
    

    private PlayerController _isGameOver;
    private PlayerController _isGrounded;

    public bool isDashing = false;

    private void Start()
    {
        _isGameOver = GameObject.Find("Player").GetComponent<PlayerController>();
        _isGrounded = GameObject.Find("Player").GetComponent <PlayerController>();
       
        _animator = GameObject.Find("Player").GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (_isGameOver._gameOver == false)
        {
            transform.Translate(movementDir * _speed * Time.deltaTime);
            DoubleSpeed();
        }

    }

    private void DoubleSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _isGrounded._isGrounded)
        {
            isDashing = true;
            _animator.SetFloat("Speed_f", 0.6f);
            transform.Translate(movementDir * _dashSpeed * Time.deltaTime);
        }
        else
        {
            isDashing = false;
            _animator.SetFloat("Speed_f", 0.26f);
        }
    }
}
