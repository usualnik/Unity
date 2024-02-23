using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour
{
    public GameObject vehicle;
    Vector3 thirdpersonView = new Vector3(-9, 4, 0);
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.transform.position = vehicle.transform.position + thirdpersonView;
        transform.transform.rotation = vehicle.transform.rotation;
    }
}
