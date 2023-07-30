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

    public UnityEvent onScream;
    public Collider2D megaphoneRange;
    public List<MoraleBoostEntry> moraleBoostsEntries;
    [FormerlySerializedAs("Combos")] public Combo[] combos;

    [HideInInspector] public float voice;
    [HideInInspector] public bool canCombo;

    private Morale morale;
    private bool isCooldown;

    private void Awake()
    {
        morale = GetComponent<Morale>();
        voice = maxVoice;
        canCombo = true;
        foreach (var combo in combos)
        {
            combo.onCompleted += () =>
            {
                ResetCombos();
                canCombo = false;
                morale.MultiplyMorale(2);
            };
        }

        morale.onLevelUp += () => canCombo = true;
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
        BoostMorale();
        onScream.Invoke();
        
        ProceedCombo(inputKey);
    }

    private void ProceedCombo(KeyCode inputKey)
    {
        if (!canCombo) return;
        foreach (var combo in combos)
        {
            combo.Proceed(inputKey);
        }
    }

    private void BoostMorale()
    {
        var overlappingColliders = new List<Collider2D>();
        megaphoneRange.OverlapCollider(new ContactFilter2D(), overlappingColliders);

        KnockbackPolice(overlappingColliders);

        var accumulatedBoost = overlappingColliders.Aggregate(0, (currentProduct, nextCollider) =>
        {
            var entry = moraleBoostsEntries.SingleOrDefault(entry => nextCollider.CompareTag(entry.tag));
            return currentProduct + (entry?.boost ?? 0);
        });
        morale.BoostMorale(accumulatedBoost);
    }

    private void KnockbackPolice(List<Collider2D> collisions)
    {
        foreach (Collider2D collision in collisions)
        {
            GameObject obj = collision.gameObject;

            if (obj.tag == "Policeman")
            {
                print("add force");

                obj.GetComponent<Rigidbody2D>().AddForce((obj.transform.position - transform.position) * 500, ForceMode2D.Force);
            }

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