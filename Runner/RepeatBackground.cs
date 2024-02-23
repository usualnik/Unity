using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
   

    private float repeatWidth; 

    private void Awake()
    {
        _startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < repeatWidth)
        {
           transform.position = _startPosition;
        }
    }
}
