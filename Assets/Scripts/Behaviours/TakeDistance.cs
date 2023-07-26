using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Walk))]
public class TakeDistance : MonoBehaviour
{
    public Collider2D closeRange;

    private Walk walk;

    private void Awake()
    {
        walk = GetComponent<Walk>();
    }

    private void FixedUpdate()
    {
        var overlappingColliders = new List<Collider2D>();
        closeRange.OverlapCollider(new ContactFilter2D(), overlappingColliders);
        var centerOfGravity = overlappingColliders
            .Where(collider => collider.gameObject != gameObject)
            .Select(collider => collider.transform.position)
            .Aggregate(Vector3.zero, (average, position) => average + position) / overlappingColliders.Count;
        walk.direction = (transform.position - centerOfGravity).normalized;
    }
}