using UnityEngine;
using UnityEngine.Events;

public class CatchPlayer : MonoBehaviour
{
    public MonoBehaviour chasingBehaviour;
    public UnityEvent onCatch;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (chasingBehaviour.enabled && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Morale>().ResetMorale();
            onCatch.Invoke();
        }
    }
}