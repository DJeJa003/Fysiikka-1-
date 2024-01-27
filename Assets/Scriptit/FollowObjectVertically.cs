using UnityEngine;

public class FollowObjectVertically : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;
    public float distance = 10.0f;

    private void Update()
    {
        Vector3 position = transform.position;

        float targetY = target.position.y + distance;
        Vector3 targetPosition = new Vector3(position.x, targetY, position.z);

        transform.position = Vector3.Lerp(position, targetPosition, speed * Time.deltaTime);
    }
}
