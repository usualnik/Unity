using UnityEngine;

public class SpawnMovement : MonoBehaviour
{
    private bool _dirRight = true;
    public float speed = 1.5f;

    void Update()
    {

        SpawnerMovement();

    }

    private void SpawnerMovement()
    {
        if (_dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -4.0f)
        {
            _dirRight = false;
        }

        if (transform.position.x >= 4.0f)
        {
            _dirRight = true;
        }
    }

}
