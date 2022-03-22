using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backLightScriptPlayer : MonoBehaviour
{
    private void FixedUpdate()
    {

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
