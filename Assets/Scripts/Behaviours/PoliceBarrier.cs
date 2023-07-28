using UnityEngine;
using UnityEngine.Events;

public class PoliceBarrier : PlayerTrigger
{
    public UnityEvent onBlockedInteraction;
    public UnityEvent onRetreatInteraction;
    public int requiredCrowd;

    protected virtual bool HasRequirements(PeopleInventory inventory)
    {
        return inventory.crowdSize >= requiredCrowd;
    }

    protected virtual void Block(PeopleInventory inventory)
    {
        onBlockedInteraction.Invoke();
    }

    protected virtual void Retreat(PeopleInventory inventory)
    {
        onRetreatInteraction.Invoke();
    }

    protected override void Interact(GameObject player)
    {
        var inventory = player.GetComponent<PeopleInventory>();
        if (HasRequirements(inventory))
        {
            Retreat(inventory);
        }
        else
        {
            Block(inventory);
        }
    }
}