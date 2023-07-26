using System;
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

    private void OnDisable()
    {
        walk.direction = Vector2.zero;
    }
}