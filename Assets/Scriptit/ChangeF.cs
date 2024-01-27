using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeF : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public ConstantForce cf;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "force ->: " + slider.value.ToString();
        cf.force = new Vector3(slider.value, cf.force.y, cf.force.z);
    }
}
