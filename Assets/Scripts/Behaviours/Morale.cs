using System.Collections;
using ExtEvents;
using UnityEngine;

[RequireComponent(typeof(PeopleInventory))]
public class Morale : MonoBehaviour
{
    public int[] milestones;
    public float moraleDecay;
    public ExtEvent onLevelUp; //TODO: play protesting sound (whistle)

    [Header("Turbo")] public float turboMultiplier = 1;
    public float turboDuration;
    public ExtEvent onTurboStart;
    public ExtEvent onTurboEnd;

    [HideInInspector] public float points;
    [HideInInspector] public int currentMilestone;
    [HideInInspector] public float multiplier = 1;

    private PeopleInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<PeopleInventory>();
    }

    private void Update()
    {
        points = Mathf.Max(points - Time.deltaTime * moraleDecay, 0);
    }

    public void BoostMorale(int boost)
    {
        if (currentMilestone >= milestones.Length)
        {
            return;
        }

        points += boost * multiplier;
        if (points > milestones[currentMilestone])
        {
            LevelUp();
        }
    }

    public void ApplyTurbo()
    {
        StartCoroutine(MultiplierCoroutine());
    }

    private IEnumerator MultiplierCoroutine()
    {
        multiplier *= turboMultiplier;
        onTurboStart.Invoke();
        yield return new WaitForSeconds(turboDuration);
        multiplier /= turboMultiplier;
        onTurboEnd.Invoke();
    }

    private void LevelUp()
    {
        points = 0;
        currentMilestone++;
        inventory.GainCrowd(currentMilestone);
        onLevelUp.Invoke();
    }

    public float ProgressToNextMilestone =>
        currentMilestone < milestones.Length ? points / milestones[currentMilestone] : 0;
}