using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Android;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 1f;
    private float gravityModifier = 2;
    private Rigidbody playerRb;

    private float upperBorder = 16f;
    private float lowerBorder = 0f;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;

        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        explosionParticle = GameObject.Find("FX_Explosion_Rubble").GetComponent<ParticleSystem>();
        fireworksParticle = GameObject.Find("FX_Fireworks_Yellow_Small").GetComponent<ParticleSystem>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
        }

        if (transform.position.y >= upperBorder)
        {
            transform.position = new Vector3(transform.position.x, upperBorder, transform.position.z);
            playerRb.AddForce(Vector3.down * 30f, ForceMode.Impulse);
        }
        else if (transform.position.y <= lowerBorder && !gameOver)
        {
            
            playerRb.AddForce(Vector3.up * 40f, ForceMode.Impulse);
            
        }

    }


    private void OnCollisionEnter(Collision other)
    {
        //TO DO: explosion particlses must be played before Destroy(gameObject)


        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(playerAudio.clip = explodeSound);
            Destroy(other.gameObject);
            gameOver = true;
        }

        // if player collides with money, fireworks
        if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(playerAudio.clip = moneySound);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerAudio.PlayOneShot(playerAudio.clip = jumpSound);           
        }

    }

}
