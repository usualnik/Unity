using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static int lives = 3;

    private Text livesValue;

    private void Start()
    {
        livesValue = GetComponent<Text>();
    }

    private void Update()
    {
        livesValue.text = "Lives: " + lives.ToString();
    }

}
