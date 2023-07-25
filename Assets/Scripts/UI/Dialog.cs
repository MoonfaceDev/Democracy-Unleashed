using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public float timeBetweenChars;

    private const string ContinueStr = " >>";

    private Queue<string> messageQueue;
    private Coroutine messageCoroutine;

    private void Awake()
    {
        messageQueue = new Queue<string>();
    }

    public void ShowMessages(IEnumerable<string> messages)
    {
        foreach (var message in messages)
        {
            messageQueue.Enqueue(message);
        }
        ShowNextMessage();
    }

    private void Update()
    {
        if (Input.GetButtonUp("Continue"))
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

        messageCoroutine = StartCoroutine(ShowMessageCoroutine());
    }

    private IEnumerator ShowMessageCoroutine()
    {
        if (messageQueue.Count == 0)
        {
            dialogPanel.SetActive(false);
            yield break;
        }
        
        dialogPanel.SetActive(true);

        text.text = messageQueue.Dequeue();
        text.ForceMeshUpdate();
        
        var totalVisibleCharacters = text.textInfo.characterCount;
        var counter = 0;

        while (true)
        {
            var visibleCount = counter % (totalVisibleCharacters + 1);
            text.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                text.maxVisibleCharacters = visibleCount + 3;

                var textTemp = text.text;
                var textContinue = text.text + ContinueStr;

                while (true)
                {
                    yield return new WaitForSeconds(0.3f);
                    text.text = textContinue;
                    yield return new WaitForSeconds(0.3f);
                    text.text = textTemp;
                }
            }

            counter += 1;
            yield return new WaitForSeconds(timeBetweenChars);
        }
    }
}