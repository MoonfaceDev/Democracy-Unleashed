using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Notice))]
public class Charge : MonoBehaviour
{
    public float speedMultiplier = 1;
    public UnityEvent onTargetArrived;

    private Notice notice;
    private Walk walk;

    private void Awake()
    {
        walk = GetComponent<Walk>();
        notice = GetComponent<Notice>();
    }

    private void OnEnable()
    {
        walk.direction = notice.direction;
        walk.speed *= speedMultiplier;
    }

    private void OnDisable()
    {
        walk.direction = Vector2.zero;
        walk.speed /= speedMultiplier;
    }

    private void Update()
    {
        var distanceFromTarget = Vector2.Distance(transform.position, notice.target);

        if (distanceFromTarget < 0.5f)
        {
            onTargetArrived.Invoke();
        }
    }
}