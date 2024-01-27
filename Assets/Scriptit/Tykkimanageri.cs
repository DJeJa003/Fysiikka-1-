using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Tykkimanageri : MonoBehaviour
{
    public GameObject Ball; 
    public Transform LaunchPoint;

    private const int N_TRAJECTORY_POINTS = 10;

    private Camera _cam;
    private bool _pressingMouse = false;

    private Vector3 _initialVelocity;


    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            _pressingMouse = true;
        }
        if(Input.GetMouseButtonUp(1)){
            _pressingMouse = false;
            _Fire();

        }
        if(_pressingMouse) {
            Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            transform.LookAt(mousePos);

            _initialVelocity = mousePos - LaunchPoint.position;

        }
    }

    private void _Fire() {

        GameObject cannonBall = Instantiate(Ball, LaunchPoint.position, Quaternion.identity);

        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        rb.AddForce(_initialVelocity, ForceMode.Impulse);

    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 280, 100, 90), "Lähtönopeus: ");
        if (_pressingMouse)
        {
            GUI.Label(new Rect(20, 300, 80, 20), (_initialVelocity.magnitude).ToString("F2") + " m/s");
        }
    }
}
