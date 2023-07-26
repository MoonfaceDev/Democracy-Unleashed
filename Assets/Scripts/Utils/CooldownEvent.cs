using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CooldownEvent : MonoBehaviour
{
    public UnityEvent @event;
    //event will not be activated multiple times
    public float cooldown;

    private bool canInvoke = true;

    private IEnumerator Cooldown()
    {
        canInvoke = false;
        yield return new WaitForSeconds(cooldown);
        canInvoke = true;
    }

    public void Invoke()
    {
        if (!canInvoke) return;
        @event.Invoke();
        StartCoroutine(Cooldown());
    }
}