using UnityEngine;

[RequireComponent(typeof(Walk))]
[RequireComponent(typeof(Megaphone))]
public class PlayerController : MonoBehaviour
{
    private Walk walk;
    private Megaphone megaphone;

    private void Awake()
    {
        walk = GetComponent<Walk>();
        megaphone = GetComponent<Megaphone>();
    }

    private void Update()
    {
        UpdateWalkDirection();

        if (Input.GetKeyDown(KeyCode.F))
        {
            megaphone.Scream(KeyCode.F);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            megaphone.Scream(KeyCode.B);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            megaphone.Scream(KeyCode.S);
        }
    }

    private void UpdateWalkDirection()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        walk.direction = new Vector2(horizontal, vertical).normalized;
    }
}