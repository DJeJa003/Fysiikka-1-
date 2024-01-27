using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class törmäysvoima : MonoBehaviour
{
    public float impactForceThreshold = 10f;
    public float forceMultiplier = 1f;
    private float impactForce = 0f;
    private bool useTheForce = false;
    private bool ekatormays = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!ekatormays)
        {
            impactForce = collision.impulse.magnitude / Time.fixedDeltaTime;

            if (impactForce >= impactForceThreshold)
            {
                //Debug.Log("Impact force: " + impactForce * forceMultiplier + " N");
                useTheForce = true;
            }
            ekatormays = true;
        }
        
    }
    private void OnGUI()
    {
        if (useTheForce)
        {
            GUI.Box(new Rect(10, 190, 100, 90), "Voima: ");
            GUI.Label(new Rect(30, 210, 80, 20), (impactForce * forceMultiplier).ToString("F2") + " N");
        }
    }
}
