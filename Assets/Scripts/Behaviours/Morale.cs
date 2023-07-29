using UnityEngine;
using UnityEngine.Events;
using ExtEvents;

[RequireComponent(typeof(PeopleInventory))]
public class Morale : MonoBehaviour
{
    public int[] milestones;
    public float moraleDecay;
    public ExtEvent onLevelUp; //TODO: play protesting sound (whistle)
    [HideInInspector] public float points;

    private int currentMilestone;

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

        points += boost;
        if (points > milestones[currentMilestone])
        {
            LevelUp();
        }
    }

    public void BoostMoraleMultiplier(float multiplier)
    {
        if (currentMilestone >= milestones.Length)
        {
            return;
        }

        points = (int)(points * multiplier);
        if (points > milestones[currentMilestone])
        {
            LevelUp();
        }
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