using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GravityType
{
    Earth,
    Moon,
    Mars
}
public class GravityChange : MonoBehaviour
{
    public float weight = 1.0f;
    public GravityType gravityType;
    public Image backgroundImage;

    public Sprite earthBackground;
    public Sprite moonBackground;
    public Sprite marsBackground;

    private Rigidbody _rigidbody;
    private GameObject _background;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _background = GameObject.FindWithTag("Background");
    }

    void OnGUI()
    {
        GUI.Box(new Rect(300, 10, 200, 60), "Aseta paino");
        weight = float.Parse(GUI.TextField(new Rect(310, 35, 180, 20), weight.ToString()));
        if (GUI.Button(new Rect(300, 70, 200, 20), "Vahvista"))
        {
            AsetaPaino();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gravityType = GravityType.Earth;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gravityType = GravityType.Moon;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gravityType = GravityType.Mars;
        }

        if (_background != null)
        {
            switch (gravityType)
            {
                case GravityType.Earth:
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                    backgroundImage.sprite = earthBackground;
                    break;
                case GravityType.Moon:
                    Physics.gravity = new Vector3(0, -1.62f, 0);
                    backgroundImage.sprite = moonBackground;
                    break;
                case GravityType.Mars:
                    Physics.gravity = new Vector3(0, -3.71f, 0);
                    backgroundImage.sprite = marsBackground;
                    break;
                default:
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                    backgroundImage.sprite = earthBackground;
                    break;
            }
        }
        
        
    }
    private void AsetaPaino()
    {
        _rigidbody.mass = weight;
    }
}
