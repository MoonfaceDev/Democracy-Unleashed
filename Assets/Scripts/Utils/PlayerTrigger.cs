using UnityEngine;

public abstract class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Interact(collision.gameObject);
        }
    }

    protected abstract void Interact(GameObject player);
}