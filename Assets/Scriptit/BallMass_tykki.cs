using UnityEngine;
using UnityEngine.UI;

public class BallMass_tykki : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    [SerializeField] private InputField massInputField;

    public void ApplyNewMass()
    {
        float newMass;
        if (float.TryParse(massInputField.text, out newMass))
        {
            ballRigidbody.mass = newMass;
        }
        else
        {
            Debug.LogError("Invalid input for mass.");
        }
    }
}