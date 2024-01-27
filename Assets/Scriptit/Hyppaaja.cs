using UnityEngine;
using UnityEngine.UI;

public class Hyppaaja : MonoBehaviour

{
    // The minimum and maximum rotation angles for the x-axis
    public float minXAngle = -15.0f;
    public float maxXAngle = 6.0f;


    // Start is called before the first frame update
    void Start()
    {
        // No initialization required
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Get the current rotation of the capsule object
        Quaternion currentRotation = transform.rotation;

        // Calculate the clamped x-axis rotation
        float clampedXRotation = Mathf.Clamp(currentRotation.eulerAngles.x, minXAngle, maxXAngle);

        // Create a new rotation with the clamped x-axis rotation and the original y and z rotations
        Quaternion newRotation = Quaternion.Euler(clampedXRotation, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);

        // Set the new rotation of the capsule object
        transform.rotation = newRotation;

        float speed = GetComponent<Rigidbody>().velocity.magnitude;

       
    }
}




