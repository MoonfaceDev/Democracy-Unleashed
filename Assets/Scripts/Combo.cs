using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ExtEvents;

[System.Serializable]
public class Combo 
{
    public ExtEvent OnCompleted;
    public KeyCode[] sequence;

    private int sequenceIndex;
    [HideInInspector]
    public bool isActive;

    public void Proceed(KeyCode inputKey)
    {
        if (sequence[sequenceIndex] != inputKey)
        {
            isActive = false;
            sequenceIndex = 0;
            return;
        }

        isActive = true;
        sequenceIndex++;

        Debug.Log("combo proceed");

        if (sequenceIndex == sequence.Length)
        {
            Debug.Log("finished");
            isActive = false;
            sequenceIndex = 0;
            OnCompleted.Invoke();
        }
    }

    public bool isStartingThisCombo(KeyCode inputKey)
    {
        return sequence[0] == inputKey;
    }
}
