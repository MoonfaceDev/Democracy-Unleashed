using System.Collections.Generic;
using UnityEngine;

public class DialogEvent : MonoBehaviour
{
    public Dialog dialog;
    public List<string> messages;


    public void Invoke()
    {
        dialog.ShowMessages(messages);
    }

    public void Invoke(Callback callback)
    {
        dialog.endConversationCallback = callback;
        dialog.ShowMessages(messages);
    }
}

public delegate void Callback();