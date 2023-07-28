using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public GameObject targetObject;
    public float speed;

    private Vector2 target;
    private Vector2 direction;
    private float distanceFromTarget;

    private void OnEnable()
    {
        target = targetObject.transform.position;
        direction = target - (Vector2)transform.position;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        distanceFromTarget = Vector2.Distance(transform.position, target);
    }
}
