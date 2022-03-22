using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthText : MonoBehaviour
{
    public Text health;



    // Update is called once per frame
    void Update()
    {
        health.text = FindObjectOfType<carController>().health.ToString();
    }
}
