using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followDelay;
    public Transform target;

    private Vector3 offset;
    private Vector3 velocity;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position + offset,
            ref velocity,
            followDelay
        );
    }
}