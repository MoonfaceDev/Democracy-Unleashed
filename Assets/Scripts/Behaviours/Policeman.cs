using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Policeman : MonoBehaviour
{
    public GameObject player;

    public Collider2D attentionRange;
    public Collider2D attackRange;
    public LineRenderer trail;

    public float speed;
    private bool chasing;

    //follow this current point => switch to next => follow line
    //saving also in order to skip this point in search for next closest point
    private int currentLinePointIndex;
    private Vector3 currentLinePoint;

    private Vector3 target;

    private void Awake()
    {
        currentLinePoint = GetNewClosestPoint();
    }

    void FixedUpdate()
    {
        if (attentionRange.OverlapPoint(player.transform.position))
            chasing = true;
        else
            chasing = false;

        if (chasing)
            target = player.transform.position;

        //follow trail
        else
        {
            target = currentLinePoint;

            //check if reached target point
            if (Vector2.Distance(transform.position, target) < 0.1f)
            {

                currentLinePointIndex++;

                //reset count loop
                if (currentLinePointIndex == trail.positionCount)
                    currentLinePointIndex = 0;

                currentLinePoint = trail.GetPosition(currentLinePointIndex);
            }
        }

        Vector2 dir = target - transform.position;
        transform.right = dir;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    Vector2 GetNewClosestPoint()
    {
        //find the closest point in line
        Vector2 closestPoint = trail.GetPosition(0), curPoint;
        float minDistance = float.MaxValue, curDistance;
        int closestPointIndex = 0;

        for (int i = 1; i < trail.positionCount; i++)
        {
            curPoint = trail.GetPosition(i);
            curDistance = Vector2.Distance(transform.position, curPoint);

            //skip current point
            if (curDistance < minDistance && i != currentLinePointIndex)
            {
                closestPoint = curPoint;
                minDistance = curDistance;
                closestPointIndex = i;
            }
        }

        currentLinePointIndex = closestPointIndex;
        return closestPoint;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            currentLinePoint = GetNewClosestPoint();
        }
    }
}
