﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500f;    
    private float boostedSpeed = 1000f;
    private GameObject focalPoint;
    

    public ParticleSystem smokeEffect;
    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 0.5f; // how hard to hit enemy without powerup
    private float powerupStrength = 1f; // how hard to hit enemy with powerup

    private void OnEnable()
    {
        smokeEffect.Pause();
    }


    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
       
        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            smokeEffect.Play();
            GetBoost();
        }
        else
        {
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

        }

    }


    private void GetBoost()
    {
        
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * (speed + boostedSpeed) * Time.deltaTime);
        

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine("PowerupCooldown");
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  transform.position + other.gameObject.transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
