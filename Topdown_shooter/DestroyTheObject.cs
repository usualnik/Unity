using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DestroyTheObject : MonoBehaviour
{
    private float outOfBounds = 40f;
 
    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    //Out of map
    private void DestroyOutOfBounds()
    {
        if (transform.position.x > outOfBounds
            || transform.position.x < -outOfBounds)
            Destroy(gameObject);
        if (transform.position.z > outOfBounds
            || transform.position.z < -outOfBounds)
            Destroy(gameObject);
    }

    //Destroing the object when bullet collides whith enemy
   

    
}
