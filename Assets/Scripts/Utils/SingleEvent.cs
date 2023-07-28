using UnityEngine;
using UnityEngine.Events;

public class SingleEvent : MonoBehaviour
{
    public UnityEvent @event;

    private bool alreadyInvoked;

    public void Invoke()
    {
        if (alreadyInvoked) return;
        @event.Invoke();
        alreadyInvoked = true;
    }
}