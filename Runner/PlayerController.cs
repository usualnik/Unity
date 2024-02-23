using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;

    //Particles
    private ParticleSystem _exposionOnCollision;
    public ParticleSystem _dirtWhileRunning;

    //Sounds
    private AudioSource _audioSource;

    public AudioClip jumpSound;
    public AudioClip crashSound;


    //Forces
    private float _jumpForce;   
    [SerializeField] private float _gravityMod;

    public bool _gameOver = false;
    public bool _isGrounded = false;

    private bool _doubleJump = false;
    private bool _canJump = true;
    

    private Animator _animator;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _exposionOnCollision = GameObject.Find("FX_Explosion_Smoke").GetComponent<ParticleSystem>();

        _audioSource = GetComponent<AudioSource>();       

        Physics.gravity *= _gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameOver)
        {
            PlayerJump(jumpForce: 20f);           
        }
    }

    private void PlayerJump(float jumpForce)
    {
        _jumpForce = jumpForce;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_doubleJump && !_isGrounded)
            {
                _doubleJump = false;

                _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);

                _audioSource.PlayOneShot(jumpSound);
                _dirtWhileRunning.Stop();

            }
            else if (_canJump && _isGrounded)
            {
                _doubleJump = true;
                _isGrounded = false;

                _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);

                _audioSource.PlayOneShot(jumpSound);
                _animator.SetTrigger("Jump_trig");
                _dirtWhileRunning.Stop();
            }

        }

    }

   
    private void OnCollisionEnter(Collision collision)
    {


        _dirtWhileRunning.Play();

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("GAME OVER!");
            _gameOver = true;
            _audioSource.PlayOneShot(crashSound);
            _animator.Play("Death_01");
            _exposionOnCollision.Play();
            _dirtWhileRunning.Stop();

        }
        if (collision.gameObject.CompareTag("ground"))
        {
            _isGrounded = true;
        }


    }
}
