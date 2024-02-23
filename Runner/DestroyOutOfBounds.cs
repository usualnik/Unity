using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _destroyRangeX = -15;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _destroyRangeX)
        {
            Destroy(gameObject);
        }
    }
}
