using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dialog system that is turned on when player is in trigger range
public class TriggerDialog : MonoBehaviour
{
    public DialogEvent dialogEvent;

    //dialog will not be activated multiple times
    public float cooldown;
    protected bool readyForConversation;
    protected float timer;

    protected virtual void Awake()
    {
        readyForConversation = true;
        timer = cooldown;
        print("awake");
    }

    protected virtual void Update()
    {
        if (!readyForConversation)
            timer -= Time.deltaTime;
        if (timer < 0)
        {
            readyForConversation = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (readyForConversation)
            {
                dialogEvent.Invoke();
                readyForConversation = false;
                timer = cooldown;
            }
        }
    }
}
