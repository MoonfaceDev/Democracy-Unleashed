using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogEvent : MonoBehaviour
{
    public List<string> messages;
    public UnityEvent onConversationEnd;

    public void Invoke()
    {
        if (!enabled)
        {
            return;
        }
        Dialog.Instance.StartConversation(messages, () => onConversationEnd.Invoke());
    }
}