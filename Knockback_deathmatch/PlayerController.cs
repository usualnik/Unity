using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 20;
    private float knokBackPower = 10f;
    [SerializeField] private bool hasPowerUp = false;
    public GameObject powerUpIndicator;   

    private Rigidbody _playerRb;
    private GameObject _focalPoint;


    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point"); 
        powerUpIndicator.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
        PlayerMove();
        powerUpIndicator.transform.position = _playerRb.transform.position;
    }

    private void PlayerMove()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * verticalInput * _speed * Time.deltaTime, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);

            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayFromPlayer * knokBackPower, ForceMode.Impulse);
        }
    }
}
