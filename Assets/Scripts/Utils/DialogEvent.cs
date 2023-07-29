using System.Collections.Generic;
using ExtEvents;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DialogEvent : MonoBehaviour
{
    public List<string> messages;
    [FormerlySerializedAs("onConversationEndTemp")] public ExtEvent onConversationEnd;

    public void Invoke()
    {
        Dialog.Instance.StartConversation(messages, () => onConversationEnd.Invoke());
    }
}