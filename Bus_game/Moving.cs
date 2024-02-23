using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float speed = 20f;
    private float verticalInput;
    //private float turnSpeed = 10f;
    private float horizontalInput;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical") * speed;
        horizontalInput = Input.GetAxis("Horizontal") * speed;

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime);
    }
}
