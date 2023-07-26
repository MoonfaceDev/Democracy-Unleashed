using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
    public UnityEvent @event;

    private void Start()
    {
        @event.Invoke();
    }
}