using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public Text highestScore;


    // Start is called before the first frame update
    void Start()
    {
        highestScore.text = "Highscore: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("F1") + " km";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FindObjectOfType<score>().currentScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", FindObjectOfType<score>().currentScore);
            highestScore.text = "Highscore: " + FindObjectOfType<score>().currentScore.ToString("F1") + " km";
        }
        if (Input.GetKey("o"))
        {
            PlayerPrefs.DeleteAll();
            highestScore.text = "Highscore: 0" + " km";
        }
    }
    
}
