using UnityEngine;

[RequireComponent(typeof(Walk))]
public class Chase : MonoBehaviour
{
    public Transform target;
    public float speedMultiplier = 1;

    private Walk walk;

    private void Awake()
    {
        walk = GetComponent<Walk>();
    }

    private void FixedUpdate()
    {
        walk.direction = (target.position - transform.position).normalized;
    }

    private void OnEnable()
    {
        walk.speed *= speedMultiplier;
    }

    private void OnDisable()
    {
        walk.speed /= speedMultiplier;
        walk.direction = Vector2.zero;
    }
}