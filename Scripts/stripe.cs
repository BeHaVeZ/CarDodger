using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripe : MonoBehaviour
{

    public float speed = 5.0f;

    private void Update()
    {
        if (FindObjectOfType<carController>().enabled == false)
        {
            enabled = false;
        }
    }
    private void Start()
    {
        speed = 5f;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > 10f)
        {
            Destroy(this.gameObject);
        }
    }
    
}
