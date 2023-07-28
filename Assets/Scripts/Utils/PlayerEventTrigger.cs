using UnityEngine;
using UnityEngine.Events;

public class PlayerEventTrigger : PlayerTrigger
{
    public UnityEvent @event;


    protected override void Interact(GameObject player)
    {
        @event.Invoke();
    }
}