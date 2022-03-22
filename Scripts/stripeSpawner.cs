using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float repeatTime = 0.4f;
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
            Instantiate(prefab, transform.position, Quaternion.identity);
            repeatTime = 0.4f;
        }
    }
}