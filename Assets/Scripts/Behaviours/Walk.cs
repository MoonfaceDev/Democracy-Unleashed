using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Walk : MonoBehaviour
{
    public float speed;
    [HideInInspector] public Vector2 direction;

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed;
    }
}