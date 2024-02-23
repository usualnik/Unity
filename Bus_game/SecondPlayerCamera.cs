using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerCamera : MonoBehaviour
{
    public GameObject vehicle2;
    Vector3 thirdPersonViewSecondPlayer = new Vector3(9,4, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.position = vehicle2.transform.position + thirdPersonViewSecondPlayer;
    }
}
