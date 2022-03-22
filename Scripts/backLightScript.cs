using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backLightScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Light>().intensity = 0.5f;
    }

    private void Update()
    {
        if (GetComponentInParent<vehichle>().isHit == true)
        {
            GetComponent<Light>().enabled = true;
        }
    }
    private void FixedUpdate()
    {
        if (GetComponentInParent<vehichle>().isHit == true)
        {
            GetComponent<Light>().intensity = 5f;
        }

        if (FindObjectOfType<LightingManager>().TimeOfDay > 18 || FindObjectOfType<LightingManager>().TimeOfDay < 6)
        {
            GetComponent<Light>().enabled = true;
        }
        else
        {
            GetComponent<Light>().enabled = false;
        }
    }
}
