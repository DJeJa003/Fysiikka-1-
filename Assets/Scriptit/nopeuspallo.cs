using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nopeuspallo : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float speed;
    private float kiiht;
    private bool showGUI = true;
    private float aikaisempiNopeus;
    private float speed_avg;
    private float aikaisempiAika;
    private bool alkaa = false;
    private bool osuma = false;
    private float nopeusOnCollision;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        aikaisempiNopeus = _rigidbody.velocity.magnitude;
        speed_avg = aikaisempiNopeus;
        aikaisempiAika = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            alkaa = true;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.left * _rigidbody.mass, ForceMode.Impulse);
        }

        if (alkaa && !osuma)
        {
            UpdatePhysics();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            showGUI = !showGUI;
        }
    }

    void UpdatePhysics()
    {
        float delta_time = Time.time - aikaisempiAika;
        float alpha = Mathf.Exp(-delta_time / 0.5f);
        speed_avg = alpha * speed_avg + (1 - alpha) * _rigidbody.velocity.magnitude;
        speed = _rigidbody.velocity.magnitude;
        kiiht = (speed_avg - aikaisempiNopeus) / delta_time;
        aikaisempiNopeus = speed_avg;
        aikaisempiAika = Time.time;

        _rigidbody.velocity = new Vector3(0, -speed, 0);
        float minKiiht = 0.01f;
        _rigidbody.AddForce(Vector3.down / Mathf.Max(kiiht, minKiiht), ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            osuma = true;
            nopeusOnCollision = speed;
        }
    }

    void OnGUI()
    {
        if (showGUI)
        {
            DrawGUI();
        }
    }

    void DrawGUI()
    {
        if (!osuma)
        {
            GUI.Box(new Rect(10, 10, 100, 90), "Pallon nopeus");
            GUI.Label(new Rect(20, 40, 80, 20), speed.ToString("F2") + "m/s");
            GUI.Box(new Rect(10, 100, 100, 90), "Kiihtyvyys");
            GUI.Label(new Rect(20, 130, 80, 20), kiiht.ToString("F2") + "m/s^2");

            //GUI.Box(new Rect(10, 280, 100, 90), "Syötä arvot");
            //speed = float.Parse(GUI.TextField(new Rect(20, 300, 80, 20), speed.ToString("F2")));
            //kiiht = float.Parse(GUI.TextField(new Rect(20, 330, 80, 20), kiiht.ToString("F2")));
        }
        else
        {
            GUI.Box(new Rect(10, 10, 122, 90), "Nopeus\n törmäyshetkellä:");
            GUI.Label(new Rect(45, 60, 80, 20), nopeusOnCollision.ToString("F2") + "m/s");
        }
        
    }
}
