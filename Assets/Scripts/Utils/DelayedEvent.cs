using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour
{
    public float delay;
    public UnityEvent @event;

    public void Invoke()
    {
        StartCoroutine(InvokeDelayed());
    }

    private IEnumerator InvokeDelayed()
    {
        yield return new WaitForSeconds(delay);
        @event.Invoke();
    }
}