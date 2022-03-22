using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Light>().enabled = false;

    }
    private void FixedUpdate()
    {
        if (FindObjectOfType<carController>().health > 1)
        {
            this.GetComponent<Light>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<Light>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vehicle")
        {
            Destroy(other.gameObject);
            FindObjectOfType<carController>().health--;
            other.gameObject.GetComponent<vehichle>().CreateDestroyEffect();
        }
        if(other.gameObject.tag == "StoneSlab")
        {
            FindObjectOfType<carController>().health--;
        }
    }

}
