using UnityEngine;
using UnityEngine.UI;


public class HpBar : MonoBehaviour
{
    private Slider hpBar;
    

    private void Start()
    {
        hpBar = GetComponentInChildren<Slider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            hpBar.value -= 0.5f;

            if (hpBar.value == 0)
            {
                ScoreManager.scoreValue++;
                Destroy(gameObject);

            }

        }
    }
}



