using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Megaphone : MonoBehaviour
{
    [Serializable]
    public class MoraleBoostEntry
    {
        public string tag;
        public int boost;
    }

    public UnityEvent onScream;
    public Collider2D megaphoneRange;
    public List<MoraleBoostEntry> moraleBoostsEntries;

    [HideInInspector] public float voice = MaxVoice;

    public const float MaxVoice = 100;
    private const float VoiceThreshold = 50;
    private const float ScreamVoiceCost = 15;
    private const float VoiceRegenerationRate = 10;

    private Morale morale;
    private bool regenerating;

    private void Awake()
    {
        morale = GetComponent<Morale>();
    }

    public void Scream()
    {
        switch (voice)
        {
            case < VoiceThreshold when regenerating:
                return;
            case < ScreamVoiceCost:
                voice = 0;
                regenerating = true;
                return;
        }

        onScream.Invoke();
        BoostMorale();
        voice -= ScreamVoiceCost;
    }

    private void BoostMorale()
    {
        var overlappingColliders = new List<Collider2D>();
        megaphoneRange.OverlapCollider(new ContactFilter2D(), overlappingColliders);
        var accumulatedBoost = overlappingColliders.Aggregate(1, (currentProduct, nextCollider) =>
        {
            var entry = moraleBoostsEntries.SingleOrDefault(entry => nextCollider.CompareTag(entry.tag));
            return currentProduct * entry?.boost ?? 1;
        });
        morale.BoostMorale(accumulatedBoost);
    }

    private void Update()
    {
        voice = Mathf.Min(voice + Time.deltaTime * VoiceRegenerationRate, MaxVoice);

        if (regenerating)
        {
            regenerating = voice < VoiceThreshold;
        }
    }
}