using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Policeman : MonoBehaviour
{
    public GameObject target;

    public Collider2D attentionRange;
    public Collider2D attackRange;

    public float speed;
    private bool chasing;

    void FixedUpdate()
    {
        if (attentionRange.OverlapPoint(target.transform.position))
            chasing = true;
        else
            chasing = false;

        if (chasing)
        {
            Vector3 dir = target.transform.position - transform.position;
            transform.right = dir;
            transform.Translate(transform.right * Time.deltaTime * speed);
        }
    }
}
