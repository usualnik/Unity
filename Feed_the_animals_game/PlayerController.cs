using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30.0f;

    private float horizontalInput;
    private float verticalInput;

    private float mapBoundsX = 25;
    private float mapBoundsZ = 10;

    private Vector3 ammoOffset = new Vector3(0,0,1.2f);

    public GameObject ammo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    
    void Update()
    {


        if (transform.position.x < -mapBoundsX)
            transform.position = new Vector3(-mapBoundsX, transform.position.y, transform.position.z);
        else if (transform.position.x > mapBoundsX)
            transform.position = new Vector3(mapBoundsX, transform.position.y, transform.position.z);

        if (transform.position.z < -mapBoundsZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, -mapBoundsZ);
        else if (transform.position.z > mapBoundsZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, mapBoundsZ);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(ammo, transform.position + ammoOffset, ammo.transform.rotation);
        }

    }






}
