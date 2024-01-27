using UnityEngine;

public class MaleDummy : MonoBehaviour
{
    // The initial rotation of the character
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Save the initial rotation of the character
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the character's rotation to the initial rotation
        transform.localRotation = initialRotation;
    }
}

