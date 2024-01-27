using UnityEngine;

public class PushToMouse : MonoBehaviour
{
    public float maxForce = 20f;
    public float forceMultiplier = 1f;

    private Vector3 initialPosition;
    private LineRenderer lineRenderer;

    private void Start()
    {
        // Create line renderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = Color.red;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;

        // Store initial position of gameobject
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    private void OnMouseDrag()
    {
        // Draw line towards mouse position
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        // Calculate force based on distance between initial position and current mouse position
        float distance = Vector3.Distance(initialPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float force = Mathf.Min(distance * forceMultiplier, maxForce);

        // Update line width based on force
        lineRenderer.startWidth = 1f * (force / maxForce);
        lineRenderer.endWidth = 5f * (force / maxForce);
    }

    private void OnMouseUp()
    {
        // Calculate force based on distance between initial position and final mouse position
        float distance = Vector3.Distance(initialPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float force = Mathf.Min(distance * forceMultiplier, maxForce);

        // Calculate direction from initial position to final mouse position
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialPosition).normalized;
        direction.z = 0f;

        // Apply force to gameobject
        GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);

        // Disable line renderer
        lineRenderer.enabled = false;
    }
}
