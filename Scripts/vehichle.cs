using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class vehichle : MonoBehaviour
{
    public float speed = 2.0f;
    public float force = 100f;
    Rigidbody rb;
    bool backwards = true;
    RaycastHit hit;
    public bool isHit = false;
    public GameObject destroyEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (gameObject.name.Contains("Bus") || gameObject.name.Contains("Truck"))
        {
            speed = Random.Range(5f, 7f);
        }
        else
        {
            speed = Random.Range(2f, 5f);
        }
        transform.Rotate(0, -180, 0);
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(this.transform.position, Vector3.left * 5f, Color.cyan);
        Ray ray = new Ray(this.transform.position, Vector3.left * 5f);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Vehicle" && this.speed <= hit.transform.gameObject.GetComponent<vehichle>().speed)
            {
                this.GetComponent<vehichle>().speed = hit.transform.gameObject.GetComponent<vehichle>().speed;
                isHit = true;
            }
            if (hit.transform.gameObject.tag == "Player")
            {
                isHit = true;
            }
        }
        if (FindObjectOfType<carController>().enabled == false)
        {
            backwards = false;
        }
    }
    void Update()
    {
        if (backwards == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x > 10f)
            {
                Destroy(this.gameObject);
            }
        }
        if (backwards == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * 2);
            if (transform.position.x < -10f)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Vehicle")
        {
            this.enabled = false;
            rb.freezeRotation = false;
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * force);
            rb.AddForce(Vector3.left * force);
            this.transform.Rotate(dir * force);
            Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Hit");
        }
    }
    public void CreateDestroyEffect()
    {
        Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("CarDestroy");
    }
}
