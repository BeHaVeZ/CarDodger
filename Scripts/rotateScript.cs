using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour
{
    carController carController;
    Vector3 toLeft = new Vector3(0, -40, 0);
    Vector3 toRight = new Vector3(0, 40, 0);
    Vector3 standard = new Vector3(0, -90, 0);
    public float rotationSpeed = 5f;

    private void Start()
    {
        carController = GetComponentInParent<carController>();
    }

    private void Update()
    {
        if (carController.enabled != true)
        {
            enabled = false;
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(standard);
        if(Input.GetAxis("Horizontal") < 0f)
        {
            transform.Rotate(toLeft * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.Rotate(toRight * Time.deltaTime * rotationSpeed);
        }

    }
}
