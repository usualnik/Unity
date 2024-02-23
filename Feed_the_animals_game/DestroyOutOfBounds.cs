using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _maxRangeZ = 35.0f;
    private float _minRangeZ = -20.0f;
    private float _maxRangeX = 45.0f;
    private float _minRangeX = -45.0f;

    

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.z > _maxRangeZ)
        {
            Destroy(gameObject);
            
        }
        else if (transform.position.z < _minRangeZ)
        {
            Destroy(gameObject);
            
        }
        else if (transform.position.x >_maxRangeX )
        {
            Destroy(gameObject);
            
        }
        else if (transform.position.x < _minRangeX)
        {
            Destroy(gameObject);
           
        }


    }
}
