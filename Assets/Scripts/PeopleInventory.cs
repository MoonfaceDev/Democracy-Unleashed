using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InsufficientProtestersException : Exception
{
}

public class PeopleInventory : MonoBehaviour
{
    private Dictionary<ProtesterGroup.Type, ProtesterGroup> protesterGroups;
    [HideInInspector] public int crowdSize;

    private void Awake()
    {
        protesterGroups = Enum.GetValues(typeof(ProtesterGroup.Type))
            .Cast<ProtesterGroup.Type>()
            .Select(type => new ProtesterGroup(type))
            .ToDictionary(keySelector: group => group.type);
    }

    //if player unlocked the pilot he will gain another one each milestone
    public void GainProtesters()
    {
        foreach (var group in protesterGroups.Values.Where(group => group.unlocked))
        {
            group.size++;
        }
    }

    public void UnlockGroup(ProtesterGroup.Type type)
    {
        protesterGroups[type].unlocked = true;
    }

    public bool HasRequiredProtesters(IEnumerable<ProtesterRequirement> requiredProtesters)
    {
        return requiredProtesters.All(requirement =>
        {
            var group = protesterGroups[requirement.type];
            return group.unlocked && group.size >= requirement.size;
        });
    }

    public void UseProtesters(List<ProtesterRequirement> requiredProtesters)
    {
        if (!HasRequiredProtesters(requiredProtesters))
        {
            throw new InsufficientProtestersException();
        }

        foreach (var requirement in requiredProtesters)
        {
            protesterGroups[requirement.type].size -= requirement.size;
        }
    }
}