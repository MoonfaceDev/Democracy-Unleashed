using UnityEngine;

[RequireComponent(typeof(Walk))]
[RequireComponent(typeof(MegaPhone))]
public class PlayerController : MonoBehaviour
{
    private Walk walk;
    private MegaPhone megaphone;

    private void Awake()
    {
        walk = GetComponent<Walk>();
        megaphone = GetComponent<MegaPhone>();
    }

    private void Update()
    {
        UpdateWalkDirection();

        if (Input.GetKeyDown(KeyCode.F))
        {
            megaphone.Scream();
        }
    }

    private void UpdateWalkDirection()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        walk.direction = new Vector2(horizontal, vertical).normalized;
    }
}