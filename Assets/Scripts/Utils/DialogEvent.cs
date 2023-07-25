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
}