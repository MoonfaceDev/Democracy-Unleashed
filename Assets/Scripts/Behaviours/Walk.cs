using System;
using UnityEngine;

public enum LookDirection
{
    Left = 0,
    Up = 1,
    Right = 2,
    Down = 3
}

[RequireComponent(typeof(Rigidbody2D))]
public class Walk : MonoBehaviour
{
    public float speed;
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public LookDirection lookDirection;

    private static readonly LookDirection[] Directions = Enum.GetValues(typeof(LookDirection)) as LookDirection[];
    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var newLookDirection = GetLookDirection(direction);
        if (newLookDirection != null)
        {
            lookDirection = (LookDirection)newLookDirection;
        }
    }

    private static LookDirection? GetLookDirection(Vector2 walkDirection)
    {
        if (walkDirection == Vector2.zero)
        {
            return null;
        }

        var angle = 360-Vector2.SignedAngle(Vector2.left, walkDirection);
        var directionIndex = Mathf.RoundToInt(angle / 90) % 4;
        return Directions[directionIndex];
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed;
    }
}