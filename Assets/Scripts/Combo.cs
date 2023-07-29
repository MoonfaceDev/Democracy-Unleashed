using System;
using ExtEvents;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Combo
{
    [FormerlySerializedAs("OnCompleted")] public ExtEvent onCompleted;
    public KeyCode[] sequence;

    private int sequenceIndex;
    [HideInInspector] public bool isActive;

    public void Proceed(KeyCode inputKey)
    {
        if (sequence[sequenceIndex] != inputKey)
        {
            FinishCombo();
            return;
        }

        isActive = true;
        sequenceIndex++;

        if (sequenceIndex == sequence.Length)
        {
            FinishCombo();
            onCompleted.Invoke();
        }
    }

    private void FinishCombo()
    {
        isActive = false;
        sequenceIndex = 0;
    }

    public bool IsFirst(KeyCode inputKey)
    {
        return sequence[0] == inputKey;
    }
}