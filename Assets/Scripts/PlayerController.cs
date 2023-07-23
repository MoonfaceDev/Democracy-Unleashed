using UnityEngine;

[RequireComponent(typeof(Walk))]
public class PlayerController : MonoBehaviour
{
    private Walk walk;

    private void Awake()
    {
        walk = GetComponent<Walk>();
    }

    private void Update()
    {
        UpdateWalkDirection();
    }

    private void UpdateWalkDirection()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        walk.direction = new Vector2(horizontal, vertical).normalized;
    }
}