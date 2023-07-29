using UnityEngine;
using UnityEngine.Events;

public class PoliceBarrier : PlayerTrigger
{
    public UnityEvent onBlockedInteraction;
    public UnityEvent onRetreatInteraction;
    public int requiredCrowd;

    protected virtual bool HasRequirements(PeopleInventory inventory)
    {
        return inventory.CrowdSize >= requiredCrowd;
    }

    protected override void Interact(GameObject player)
    {
        var inventory = player.GetComponent<PeopleInventory>();
        if (HasRequirements(inventory))
        {
            onRetreatInteraction.Invoke();
        }
        else
        {
            onBlockedInteraction.Invoke();
        }
    }
}