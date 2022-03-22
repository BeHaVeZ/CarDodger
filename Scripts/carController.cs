using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class carController : MonoBehaviour
{
    public Rigidbody rb;
    public float movingSpeed = 8f;
    Vector3 startingPosition = new Vector3(0, 0, 2.64f);
    public GameObject crashEffect;
    public int health = 1;
    float screenWidth;
    private void Start()
    {
        health = 1;
        gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = false;
        rb.freezeRotation = true;
        screenWidth = Screen.width;
    }
    private void Update()
    {
        int i = 0;
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, 0) * movingSpeed * Time.deltaTime);

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > Screen.width / 2)
            {
                MoveCar(1f);
            }
            if (Input.GetTouch(i).position.x < Screen.width / 2)
            {
                MoveCar(-1f);
            }
        }


    }
    void FixedUpdate()
    {
        if (transform.position.x >= 2.64f)
        {
            transform.Translate(startingPosition * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vehicle" || collision.gameObject.tag == "StoneSlab")
        {
            enabled = false;
            health--;
            rb.freezeRotation = false;
            FindObjectOfType<gameManager>().EndGame();
            FindObjectOfType<AudioManager>().Play("Hit");
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            foreach (ContactPoint contact in collision.contacts)
            {
                GameObject effectIns = (GameObject)Instantiate(crashEffect, contact.point, Quaternion.identity);
                Destroy(effectIns, 2f);
            }
            gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = true;
            this.GetComponent<Rigidbody>().AddForce(dir * 25);
            this.GetComponent<Rigidbody>().AddForce(Vector3.left * 150);
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
            this.transform.Rotate(dir);

        }
    }
    private void MoveCar(float Input)
    {
        transform.Translate(new Vector3(Input, 0, 0) * movingSpeed * Time.deltaTime);
    }
}
    