using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public enum ProtesterType
{
    Pilot,
    Maid,
    HiTech,
    Lawyer,
    Doctor,
}

public class PeopleInventory : MonoBehaviour
{
    [HideInInspector] public int crowdSize;
    public UnityEvent<ProtesterType> onGainProtester;

    private Dictionary<ProtesterType, bool> protesters;

    private void Awake()
    {
        protesters = Enum.GetValues(typeof(ProtesterType))
            .Cast<ProtesterType>()
            .ToDictionary(keySelector: leader => leader, elementSelector: _ => false);
    }

    public void GainProtester(ProtesterType protesterType)
    {
        protesters[protesterType] = true;
        onGainProtester.Invoke(protesterType);
    }

    public bool HasAllProtesters()
    {
        return protesters.Values.All(value => value);
    }
}