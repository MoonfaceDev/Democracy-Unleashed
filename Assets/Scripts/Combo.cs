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

    public void Proceed(KeyCode inputKey)
    {
        if (sequence[sequenceIndex] != inputKey)
        {
            ResetCombo();
            return;
        }

        sequenceIndex++;

        if (sequenceIndex == sequence.Length)
        {
            ResetCombo();
            onCompleted.Invoke();
        }
    }

    public void ResetCombo()
    {
        sequenceIndex = 0;
    }

    public bool IsFirst(KeyCode inputKey)
    {
        return sequence[0] == inputKey;
    }
}