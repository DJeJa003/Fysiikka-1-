using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nopeus : MonoBehaviour
{   private Rigidbody _rigidbody;
    private float speed;
    private float kiiht;
    private bool showGUI;
    private float aikaisempiNopeus;
    private float speed_avg;
    private float aikaisempiAika;
    private bool alkaa;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.isKinematic = true;
        aikaisempiNopeus = _rigidbody.velocity.magnitude;
        speed_avg = aikaisempiNopeus;
        aikaisempiAika = Time.time;
        showGUI = true;
        alkaa = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            alkaa = true;
            //_rigidbody.isKinematic = false;
        }

        if (alkaa)
        {
            float delta_time = Time.time - aikaisempiAika;
            float alpha = Mathf.Exp(-delta_time / 0.5f);
            speed_avg = alpha * speed_avg + (1 - alpha) * _rigidbody.velocity.magnitude;

            speed = _rigidbody.velocity.magnitude;
            kiiht = (speed_avg - aikaisempiNopeus) / delta_time;

            aikaisempiNopeus = speed_avg;
            aikaisempiAika = Time.time;
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            showGUI = !showGUI;
        }
    }
    void OnGUI()
    {
        if (showGUI)
        {
            GUI.Box(new Rect(10, 10, 100, 90), "Pallon nopeus");
            GUI.Label(new Rect(20, 40, 80, 20), speed + "m/s");
            GUI.Box(new Rect(10, 100, 100, 90), "Kiihtyvyys");
            GUI.Label(new Rect(20, 130, 80, 20), kiiht + "m/s^2");

            //GUI.Box(new Rect(10, 280, 100, 90), "Syötä arvot");
            //speed = float.Parse(GUI.TextField(new Rect(20, 300, 80, 20), speed.ToString()));
            //kiiht = float.Parse(GUI.TextField(new Rect(20, 330, 80, 20), kiiht.ToString()));
            //_rigidbody.velocity = new Vector3(0, -speed, 0);
            //_rigidbody.AddForce(Vector3.down / kiiht, ForceMode.Acceleration);
        }
    }

}
