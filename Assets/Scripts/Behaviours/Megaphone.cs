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

    public float maxVoice = 100;
    public float voiceThreshold = 50;
    public float screamVoiceCost = 15;
    public float voiceRegenerationRate = 10;

    public UnityEvent onScream;
    public Collider2D megaphoneRange;
    public List<MoraleBoostEntry> moraleBoostsEntries;

    [HideInInspector] public float voice;

    private Morale morale;
    private bool isCooldown;

    private void Awake()
    {
        morale = GetComponent<Morale>();
        voice = maxVoice;
    }

    public void Scream()
    {
        if (isCooldown)
        {
            return;
        }

        if (voice < screamVoiceCost)
        {
            voice = 0;
            isCooldown = true;
            return;
        }

        voice -= screamVoiceCost;
        BoostMorale();
        onScream.Invoke();
    }

    private void BoostMorale()
    {
        var overlappingColliders = new List<Collider2D>();
        megaphoneRange.OverlapCollider(new ContactFilter2D(), overlappingColliders);
        var accumulatedBoost = overlappingColliders.Aggregate(1, (currentProduct, nextCollider) =>
        {
            var entry = moraleBoostsEntries.SingleOrDefault(entry => nextCollider.CompareTag(entry.tag));
            return currentProduct * (entry?.boost ?? 1);
        });
        morale.BoostMorale(accumulatedBoost);
    }

    private void Update()
    {
        voice = Mathf.Min(voice + Time.deltaTime * voiceRegenerationRate, maxVoice);

        if (isCooldown && voice > voiceThreshold)
        {
            isCooldown = false;
        }
    }
}