using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public float speed = 2.0f;
    RaycastHit hit;
    public GameObject pickUpEffect;
    Vector3 pos;
    void Start()
    {
        speed = Random.Range(2f, 5f);
        transform.Rotate(0, -180, 0);
        pos = GetComponent<Transform>().position = new Vector3(transform.position.x, -3.62f, transform.position.z + 1.705f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x > 10f)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (FindObjectOfType<carController>().enabled == false)
        {
            enabled = false;
            Invoke("RemoveObject", 2f);
        }
    }
    void RemoveObject()
    {
        Destroy(gameObject);
        Instantiate(pickUpEffect,transform.Find("health").position,Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<carController>().health++;
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("PickUp");
        GameObject effectIns = (GameObject)Instantiate(pickUpEffect, transform.Find("health").position, Quaternion.identity);
        Destroy(effectIns, 2f);
    }


}
