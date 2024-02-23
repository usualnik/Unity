using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonView : MonoBehaviour
{
    public GameObject vehicle;
    Vector3 firstpersonView = new Vector3(0, 2, 1);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.transform.position = vehicle.transform.position + firstpersonView;
    }
}
