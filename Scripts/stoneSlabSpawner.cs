using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneSlabSpawner : MonoBehaviour
{
    public GameObject stoneSlab;
    public float repeatTime = 0.3f;



    private void Update()
    {
        if (FindObjectOfType<carController>().enabled == false)
        {
            enabled = false;
        }
    }


    void FixedUpdate()
    {
        CreatePrefab();
    }
    void CreatePrefab()
    {
        repeatTime -= Time.deltaTime;
        if (repeatTime <= 0)
        {
            Instantiate(stoneSlab, transform.position, Quaternion.identity);
            repeatTime = 0.3f;
        }
    }
}
