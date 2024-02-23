using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    private Vector3 playerMovementRestrictions = new Vector3(19f, 1, 11);
    private float speed = 15f;


    private void Start()
    {
        

    }



    void Update()
    {
        

        PlayerMovement();
        PlayerShooting();
        
        
    }

    private void PlayerMovement()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 playerMovement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(playerMovement.normalized * speed * Time.deltaTime);


        //Keep the player inside gameing screen
        if (transform.position.x > playerMovementRestrictions.x)
            transform.position = new Vector3(playerMovementRestrictions.x, transform.position.y, transform.position.z);
        if (transform.position.y > playerMovementRestrictions.y)
            transform.position = new Vector3(transform.position.x, playerMovementRestrictions.y, transform.position.z);
        if (transform.position.z > playerMovementRestrictions.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, playerMovementRestrictions.z);

        if (transform.position.x < -playerMovementRestrictions.x)
            transform.position = new Vector3(-playerMovementRestrictions.x, transform.position.y, transform.position.z);
        if (transform.position.y < -playerMovementRestrictions.y)
            transform.position = new Vector3(transform.position.x, -playerMovementRestrictions.y, transform.position.z);
        if (transform.position.z < -playerMovementRestrictions.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, -playerMovementRestrictions.z);

    }


    private void PlayerShooting()
    {
        Vector3 offset = new Vector3(transform.position.x,transform.position.y, transform.position.z + 1);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet,offset,transform.rotation);
        }

    }

    //Collisions with enemys

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Lives.lives--;
            if (Lives.lives == 0)
            {
                Debug.Log("GAME OVER");
                Destroy(gameObject);
            }
                
        }
    }


}
