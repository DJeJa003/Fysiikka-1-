using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainoMuutos : MonoBehaviour
{
    public float weight = 1.0f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(300, 10, 60, 60), "Aseta paino");
        weight = float.Parse(GUI.TextField(new Rect(310, 35, 60, 20), weight.ToString()));
        if (GUI.Button(new Rect(300, 70, 60, 20), "Vahvista"))
        {
            AsetaPaino();
        }
    }

    private void AsetaPaino()
    {
        _rigidbody.mass = weight;
    }
}