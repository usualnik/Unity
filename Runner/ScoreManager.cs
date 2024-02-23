using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private Text uri;


    private float myCounter = 0;
    private const float dashingModifier = 0.05f;
    private PlayerController _isGameOver;

    private ObjectMovement _isDashing;

    private void Start()
    {
        _isDashing = GameObject.Find("Background").GetComponent<ObjectMovement>();
        _isGameOver = GameObject.Find("Player").GetComponent<PlayerController>();

        scoreText = GetComponent<Text>();
        uri = GetComponent<Text>();
        
    }

    private void Update()
    {
        myCounter += Time.deltaTime;


        if (_isDashing.isDashing && !_isGameOver._gameOver)
        {
            myCounter += dashingModifier;
            scoreText.text = "SCORE:" + myCounter.ToString("0");
        }
        else if(!_isGameOver._gameOver)
        {
            scoreText.text = "SCORE:" + myCounter.ToString("0");
        }
        
            
        


    }


}
