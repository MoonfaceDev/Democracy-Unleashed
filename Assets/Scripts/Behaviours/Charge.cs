using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Charge : MonoBehaviour
{
    public GameObject targetObject;
    public float speed;
    public UnityEvent OnTargetArrived;

    private Vector2 target;
    private Vector2 direction;
    private float distanceFromTarget;
    private Walk walk;

    private void Awake()
    {
        walk = GetComponent<Walk>();
    }

    private void OnEnable()
    {
        target = targetObject.transform.position;
        direction = target - (Vector2)transform.position;
        walk.direction = direction;
    }

    private void OnDisable()
    {
        walk.direction = Vector2.zero;
    }

    private void Update()
    {
        walk.speed = speed;

        distanceFromTarget = Vector2.Distance(transform.position, target);

        if (distanceFromTarget < 0.2f)
            OnTargetArrived.Invoke();
    }

}
