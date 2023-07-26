using UnityEngine;
using UnityEngine.Events;

public class PoliceBarrierTrigger : MonoBehaviour
{
    public UnityEvent onBlockedInteraction;
    public UnityEvent onRetreatInteraction;
    public int requiredCrowd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var crowd = collision.gameObject.GetComponent<PeopleInventory>();
            var crowdSize = crowd.crowdSize;

            if (crowdSize >= requiredCrowd)
            {
                onRetreatInteraction.Invoke();
            }
            else
            {
                onBlockedInteraction.Invoke();
            }
        }
    }
}