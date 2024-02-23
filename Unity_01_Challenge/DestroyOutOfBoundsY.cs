using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsY : MonoBehaviour
{
    private float leftLimitY = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.y < leftLimitY)
        {
            Destroy(gameObject);
        }


    }
}
