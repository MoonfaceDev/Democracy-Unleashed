using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Charge : MonoBehaviour
{
    public GameObject targetObject;
    [FormerlySerializedAs("speed")] public float speedMultiplier = 1;
    [FormerlySerializedAs("OnTargetArrived")]
    public UnityEvent onTargetArrived;

    private Vector2 target;
    private Walk walk;

    private void Awake()
    {
        walk = GetComponent<Walk>();
    }

    private void OnEnable()
    {
        target = targetObject.transform.position;
        var direction = target - (Vector2)transform.position;
        walk.direction = direction;
        walk.speed *= speedMultiplier;
    }

    private void OnDisable()
    {
        walk.direction = Vector2.zero;
        walk.speed /= speedMultiplier;
    }

    private void Update()
    {
        var distanceFromTarget = Vector2.Distance(transform.position, target);

        if (distanceFromTarget < 0.2f)
        {
            onTargetArrived.Invoke();
        }
    }
}