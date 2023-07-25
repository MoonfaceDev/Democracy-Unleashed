using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knockback : MonoBehaviour
{
    public float walkCooldownDuration;

    private new Rigidbody2D rigidbody;
    private Walk walk;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        walk = GetComponent<Walk>();
    }

    public void Apply(Vector2 force)
    {
        rigidbody.AddForce(force, ForceMode2D.Impulse);
        StartCoroutine(WalkCooldown());
    }

    private IEnumerator WalkCooldown()
    {
        walk.enabled = false;
        yield return new WaitForSeconds(walkCooldownDuration);
        walk.enabled = true;
    }
}