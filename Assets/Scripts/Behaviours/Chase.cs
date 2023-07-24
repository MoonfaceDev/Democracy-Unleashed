using UnityEngine;

[RequireComponent(typeof(Walk))]
public class Chase : MonoBehaviour
{
    public Transform target;

    private Walk walk;

    private void Awake()
    {
        walk = GetComponent<Walk>();
    }

    private void FixedUpdate()
    {
        walk.direction = (target.position - transform.position).normalized;
    }
}