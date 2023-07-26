using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Walk))]
public class Trail : MonoBehaviour
{
    public LineRenderer trail;
    public bool reverseAfterCycle; // if true, switch direction in the end

    private Walk walk;

    private int trailDirection = 1;

    // Follow current point => switch to next => follow trail
    private int currentPointIndex;

    private void Awake()
    {
        walk = GetComponent<Walk>();
    }

    private void Update()
    {
        var target = trail.transform.TransformPoint(trail.GetPosition(currentPointIndex));

        if (Vector2.Distance(transform.position, target) < 0.1f) // reached target point
        {
            var trailEnded = currentPointIndex == trail.positionCount - 1 || currentPointIndex == 0;
            if (trailEnded && reverseAfterCycle)
            {
                trailDirection *= -1;
            }

            currentPointIndex = (currentPointIndex + trailDirection) % trail.positionCount;
        }

        walk.direction = (target - transform.position).normalized;
    }

    // Finds the closest to enter the trail
    private int GetClosestPointIndex()
    {
        var points = new Vector3[trail.positionCount];
        trail.GetPositions(points);
        var worldPoints = points.Select(point => trail.transform.TransformPoint(point));
        var distances = worldPoints.Select(point => Vector2.Distance(transform.position, point)).ToList();
        var minDistance = distances.Where((_, index) => index != currentPointIndex).Min();
        return distances.IndexOf(minDistance);
    }

    private void OnEnable()
    {
        currentPointIndex = GetClosestPointIndex();
    }

    private void OnDisable()
    {
        currentPointIndex = GetClosestPointIndex();
        walk.direction = Vector2.zero;
    }
}