using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PoliceBarrierTrigger : MonoBehaviour
{
    public UnityEvent onBlockedInteraction;
    public UnityEvent onRetreatInteraction;
    public int requiredCrowd;
    public bool isMajorBarrier;
    public List<LeaderGroup> requiredLeaders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var crowd = collision.gameObject.GetComponent<PeopleInventory>();
            var crowdSize = crowd.crowdSize;

            if (isMajorBarrier)
            {
                if (crowdSize >= requiredCrowd && crowd.UseProtesters(requiredLeaders))
                    onRetreatInteraction.Invoke();
                else
                    onBlockedInteraction.Invoke();
            }

            else
            {
                if (crowdSize >= requiredCrowd)
                    onRetreatInteraction.Invoke();
                else
                    onBlockedInteraction.Invoke();
            }
        }
    }
}