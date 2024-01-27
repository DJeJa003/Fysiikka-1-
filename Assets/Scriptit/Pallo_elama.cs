using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallo_elama : MonoBehaviour
{

    public float lifetime;
    public GameObject Ball; 

    void Awake()
    {
        Destroy(Ball, lifetime);
    }
}
