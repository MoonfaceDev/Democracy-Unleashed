using System;
using System.Collections.Generic;
using System.Linq;
using ExtEvents.OdinSerializer.Utilities;
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
    public float hitForce;

    public UnityEvent onScream;
    public Collider2D megaphoneRange;
    public List<MoraleBoostEntry> moraleBoostsEntries;
    [FormerlySerializedAs("Combos")] public Combo[] combos;
    public float comboCooldownDuration;

    [HideInInspector] public float voice;

    private Morale morale;
    private bool isCooldown;
    private float lastComboTime;

    private void Awake()
    {
        morale = GetComponent<Morale>();
        voice = maxVoice;
        foreach (var combo in combos)
        {
            combo.onCompleted += () =>
            {
                ResetCombos();
                lastComboTime = Time.time;
                morale.ApplyTurbo();
            };
        }
    }

    private void ResetCombos()
    {
        combos.ForEach(combo => combo.ResetCombo());
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

        var colliders = new List<Collider2D>();
        megaphoneRange.OverlapCollider(new ContactFilter2D(), colliders);
        BoostMorale(colliders);
        Knockback(colliders);

        onScream.Invoke();
        ProceedCombo(inputKey);
    }

    public bool IsComboCooldown()
    {
        return Time.time - lastComboTime < comboCooldownDuration;
    }

    private void ProceedCombo(KeyCode inputKey)
    {
        if (IsComboCooldown()) return;
        foreach (var combo in combos)
        {
            combo.Proceed(inputKey);
        }
    }

    private void BoostMorale(IEnumerable<Collider2D> colliders)
    {
        var accumulatedBoost = colliders.Aggregate(0, (currentProduct, nextCollider) =>
        {
            var entry = moraleBoostsEntries.SingleOrDefault(entry => nextCollider.CompareTag(entry.tag));
            return currentProduct + (entry?.boost ?? 0);
        });
        morale.BoostMorale(accumulatedBoost);
    }

    private void Knockback(IEnumerable<Collider2D> colliders)
    {
        foreach (var hitCollider in colliders.Where(hitCollider => hitCollider.CompareTag("Policeman")))
        {
            hitCollider.GetComponent<Knockback>().Apply(
                hitForce * (hitCollider.transform.position - transform.position)
            );
        }
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