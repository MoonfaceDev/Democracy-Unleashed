﻿using System;
using System.Collections;
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
    public UnityEvent<ProtesterType> onGainProtester;
    
    public int CrowdSize { get; private set; }

    private Dictionary<ProtesterType, bool> protesters;

    private void Awake()
    {
        protesters = Enum.GetValues(typeof(ProtesterType))
            .Cast<ProtesterType>()
            .ToDictionary(keySelector: leader => leader, elementSelector: _ => false);
    }

    public void GainCrowd(int amount)
    {
        CrowdSize += amount;
    }

    public void TakeCrowd(int amount)
    {
        CrowdSize = Mathf.Max(0, CrowdSize - amount);
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
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