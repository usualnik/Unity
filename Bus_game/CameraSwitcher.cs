using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject camFirstPerson;
    public GameObject camThirdPerson;



    // Start is called before the first frame update
    void Start()
    {
        camFirstPerson.SetActive(false);
        camThirdPerson.SetActive(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            camFirstPerson.SetActive(true);
            camThirdPerson.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            camFirstPerson.SetActive(false);
            camThirdPerson.SetActive(true);
        }
    }
}
