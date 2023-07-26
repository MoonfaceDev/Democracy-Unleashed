using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dialog system that is turned on when player is in trigger range
public class TriggerDialog : MonoBehaviour
{
    public DialogEvent dialogEvent;

    //dialog will not be activated multiple times
    public float cooldown;
    protected bool enabled;
    protected float timer;

    private void Awake()
    {
        enabled = true;
        timer = cooldown;
    }

    private void Update()
    {
        if (!enabled)
            timer -= Time.deltaTime;
        if (timer < 0)
            enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (enabled)
            {
                dialogEvent.Invoke();
                enabled = false;
                timer = cooldown;
            }
        }
    }
}
