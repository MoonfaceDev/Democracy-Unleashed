using UnityEngine;

[RequireComponent(typeof(PeopleInventory))]
public class Morale : MonoBehaviour
{
    //each milestone gives the player new protester
    public int[] milestones;
    public float moraleDecay;

    [HideInInspector] public float points;

    private int currentMilestone;

    private PeopleInventory crowd;

    private void Awake()
    {
        crowd = GetComponent<PeopleInventory>();
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

    private void LevelUp()
    {
        points = 0;
        currentMilestone++;
        crowd.crowdSize += currentMilestone;
        //TODO: play protesting sound (whistle)
    }

    public float ProgressToNextMilestone =>
        currentMilestone < milestones.Length ? points / milestones[currentMilestone] : 0;
}