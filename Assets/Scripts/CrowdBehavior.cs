using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdBehavior : MonoBehaviour
{
    public List<ProtesterAnimation> protesters;

    public void AddProtester(ProtesterAnimation protesterAnimation)
    {
        protesters.Add(protesterAnimation);
    }

    public void Cheer()
    {
        foreach (ProtesterAnimation protester in protesters)
            protester.PlayFlag();
    }
}
