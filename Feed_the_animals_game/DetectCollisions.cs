using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddScore(); // TO DO: All scripts work seemingly
                                          // ok, without mechanics of adding the score.
        Destroy(gameObject);
        Destroy(other.gameObject);
        

    }
}
