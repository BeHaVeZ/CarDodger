using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;
    public float currentScore;
    public float overTimeIncreasedScore = 1f;
    private void Start()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString("F1") + " km";
    }
    private void FixedUpdate()
    {
        if (FindObjectOfType<carController>().enabled == false)
        {
            enabled = false;
        }
        currentScore += overTimeIncreasedScore * Time.deltaTime;
        scoreText.text = currentScore.ToString("F1") + " km";
    }
}
