using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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
    [FormerlySerializedAs("Combos")] public Combo[] combos;

    [HideInInspector] public float voice;

    private Morale morale;
    private bool isCooldown;
    private Combo currentCombo;

    private void Awake()
    {
        morale = GetComponent<Morale>();
        voice = maxVoice;
    }

    public void Scream(KeyCode inputKey)
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

        ProceedCombo(inputKey);
    }

    private void ProceedCombo(KeyCode inputKey)
    {
        //check if starting a combo
        if (combos.All(combo => !combo.isActive))
        {
            //check which one to start
            currentCombo = combos.Aggregate(currentCombo,
                (current, nextCombo) => nextCombo.IsFirst(inputKey) ? nextCombo : current
            );
        }

        currentCombo?.Proceed(inputKey);
    }

    private void BoostMorale()
    {
        var overlappingColliders = new List<Collider2D>();
        megaphoneRange.OverlapCollider(new ContactFilter2D(), overlappingColliders);
        var accumulatedBoost = overlappingColliders.Aggregate(0, (currentProduct, nextCollider) =>
        {
            var entry = moraleBoostsEntries.SingleOrDefault(entry => nextCollider.CompareTag(entry.tag));
            return currentProduct + (entry?.boost ?? 0);
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