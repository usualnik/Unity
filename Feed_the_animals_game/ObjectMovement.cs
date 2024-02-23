using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectMovement : MonoBehaviour
{
    public float speed;
   
    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

}
