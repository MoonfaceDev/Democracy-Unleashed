using UnityEngine;
using UnityEngine.Events;

public class CatchPlayer : MonoBehaviour
{
    public int crowdTaken;
    public MonoBehaviour chasingBehaviour;
    public UnityEvent onCatch;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (chasingBehaviour.enabled && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PeopleInventory>().TakeCrowd(crowdTaken);
            onCatch.Invoke();
        }
    }
}