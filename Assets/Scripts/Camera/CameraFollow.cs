using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followDelay;
    public Transform target;
    public Rect bounds;

    private Vector3 offset;
    private Vector3 velocity;

    private static float CameraHeight => 2f * Camera.main.orthographicSize;
    private static float CameraWidth => CameraHeight * Camera.main.aspect;
    private static Vector2 CameraSize => new(CameraWidth, CameraHeight);

    private Rect Bounds => new(bounds.min + CameraSize / 2, bounds.size - CameraSize);

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        var smoothTarget = Vector3.SmoothDamp(
            transform.position,
            target.position + offset,
            ref velocity,
            followDelay
        );
        transform.position = new Vector3(
            Mathf.Clamp(smoothTarget.x, Bounds.xMin, Bounds.xMax),
            Mathf.Clamp(smoothTarget.y, Bounds.yMin, Bounds.yMax),
            smoothTarget.z
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bounds.position + bounds.size / 2, bounds.size);
    }
}