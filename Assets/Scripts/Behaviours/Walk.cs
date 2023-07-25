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
        switch (walkDirection.x)
        {
            case > 0:
                return LookDirection.Right;
            case < 0:
                return LookDirection.Left;
        }
        
        switch (walkDirection.y)
        {
            case > 0:
                return LookDirection.Up;
            case < 0:
                return LookDirection.Down;
        }

        return null;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed;
    }
}