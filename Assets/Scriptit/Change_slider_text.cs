using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeMass : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public Rigidbody rg;

    public Rigidbody rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "insert value type here" + slider.value.ToString();
        rg.mass = slider.value;
        rb.mass = slider.value;
    }
}

