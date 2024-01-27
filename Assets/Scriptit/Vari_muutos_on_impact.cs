using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vari_muutos_on_impact : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        Color colorChange = getColorChange();
        GetComponent<Renderer>().material.color = colorChange;
    }

    // Update is called once per frame
    private Color getColorChange()
    {
        return new Color(
            r: UnityEngine.Random.Range(0f, 1f),
            g: UnityEngine.Random.Range(0f, 1f),
            b: UnityEngine.Random.Range(0f, 1f)
            );
    }
}
