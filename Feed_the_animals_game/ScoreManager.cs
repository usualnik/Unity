using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    int scoreCounter = 0;

    public void AddScore()
    {
        scoreCounter++;
        Debug.Log($"score: {scoreCounter}");
    }

}
