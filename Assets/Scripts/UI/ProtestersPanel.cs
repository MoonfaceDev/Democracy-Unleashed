using System;
using System.Collections.Generic;
using UnityEngine;

public class ProtestersPanel : MonoBehaviour
{
    [Serializable]
    public class ProtesterLabel
    {
        public ProtesterType type;
        public Sprite emoji;
        public string label;
    }

    public PeopleInventory inventory;
    public GameObject protesterEntryPrefab;
    public List<ProtesterLabel> protesterLabels;
    public Transform layout;
    
    private void Awake()
    {
        var entries = new Dictionary<ProtesterType, ProtesterEntry>();
        
        foreach (var label in protesterLabels)
        {
            var entry = Instantiate(protesterEntryPrefab, layout).GetComponent<ProtesterEntry>();
            entry.emoji = label.emoji;
            entry.label = label.label;
            entries[label.type] = entry;
        }

        inventory.onGainProtester.AddListener(type => entries[type].unlocked = true);
    }
}