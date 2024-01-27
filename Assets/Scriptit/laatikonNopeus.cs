using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laatikonNopeus : MonoBehaviour
{
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private float speed;
    void Update()
    {
        speed = _rigidbody.velocity.magnitude;
    }
    void OnGUI()
    {
        GUI.Box(new Rect(150, 10, 100, 90), "Laatikon nopeus");
        GUI.Label(new Rect(160, 40, 80, 20), speed + "m/s");
    }

}
