using UnityEngine;

[RequireComponent(typeof(PeopleInventory))]
public class Morale : MonoBehaviour
{
    //each milestone gives the player new protester
    public int[] milestones;
    public float moraleDecay;

    [HideInInspector] public float points;

    private int moraleLevel;

    PeopleInventory crowd;

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
        points += boost;

        if (points > milestones[moraleLevel])
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        points = 0;
        moraleLevel++;
        crowd.crowdSize += moraleLevel;
        //TODO: play protesting sound (whistle)
    }

    public float ProgressToNextMilestone => points / milestones[moraleLevel];
}