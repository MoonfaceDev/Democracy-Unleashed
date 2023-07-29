using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : SingletonBehaviour<Dialog>
{
    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public float characterRate;
    public float continueFlickerRate;
    public UnityEvent onDialogShow;
    public UnityEvent onDialogHide;

    private const string ContinueSymbol = " >>";
    private const int ContinueFlickerCount = 4;

    private bool skipEnabled;
    private Queue<string> messageQueue;
    [CanBeNull] private Action onCurrentConversationEnd;
    private Coroutine messageCoroutine;

    protected override void Awake()
    {
        base.Awake();
        messageQueue = new Queue<string>();
    }

    public void StartConversation(IEnumerable<string> messages, Action onConversationEnd = null)
    {
        if (messageQueue.Count != 0)
        {
            return; // Cannot add messages mid-conversation
        }

        foreach (var message in messages)
        {
            messageQueue.Enqueue(message);
        }

        onCurrentConversationEnd = onConversationEnd;
        dialogPanel.SetActive(true);
        onDialogShow.Invoke();
        ShowNextMessage();
    }

    private void Update()
    {
        if (skipEnabled && Input.GetButtonUp("Continue"))
        {
            ShowNextMessage();
        }
    }

    private void ShowNextMessage()
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        if (messageQueue.Count == 0)
        {
            dialogPanel.SetActive(false);
            onDialogHide.Invoke();
            onCurrentConversationEnd?.Invoke();
            onCurrentConversationEnd = null;
            return;
        }

        var message = messageQueue.Dequeue();
        messageCoroutine = StartCoroutine(ShowMessageCoroutine(message));
    }

    private IEnumerator ShowMessageCoroutine(string message)
    {
        text.text = "";

        skipEnabled = false;
        foreach (var character in message)
        {
            yield return new WaitForSeconds(characterRate);
            text.text += character;
        }
        skipEnabled = true;

        for (var i = 0; i < ContinueFlickerCount; i++)
        {
            yield return new WaitForSeconds(continueFlickerRate);
            text.text = message;
            yield return new WaitForSeconds(continueFlickerRate);
            text.text = message + ContinueSymbol;
        }
        
        ShowNextMessage();
    }
}