using UnityEngine;

[RequireComponent(typeof(Walk))]
[RequireComponent(typeof(Megaphone))]
public class PlayerController : MonoBehaviour
{
    private Walk walk;
    private Megaphone megaphone;

    private static readonly KeyCode[] MegaphoneKeys = { KeyCode.F, KeyCode.B, KeyCode.S };

    private void Awake()
    {
        walk = GetComponent<Walk>();
        megaphone = GetComponent<Megaphone>();
    }

    private void Update()
    {
        UpdateWalkDirection();

        foreach (var key in MegaphoneKeys)
        {
            if (Input.GetKeyDown(key))
            {
                megaphone.Scream(key);
            }
        }
    }

    private void UpdateWalkDirection()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        walk.direction = new Vector2(horizontal, vertical).normalized;
    }
}