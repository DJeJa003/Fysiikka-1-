using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Change_slider_text : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public  Rigidbody rg;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "mass: " + slider.value.ToString();
        rg.mass = slider.value;
    }
}

