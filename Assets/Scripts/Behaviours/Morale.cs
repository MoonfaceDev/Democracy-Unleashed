using System.Collections;
using ExtEvents;
using UnityEngine;

[RequireComponent(typeof(PeopleInventory))]
public class Morale : MonoBehaviour
{
    public int[] milestones;
    public float moraleDecay;
    public ExtEvent onLevelUp; //TODO: play protesting sound (whistle)
    [HideInInspector] public float points;

    [HideInInspector] public int currentMilestone;

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

    public void MultiplyMorale(float multiplier)
    {
        BoostMorale((int)(points * multiplier - points));
    }

    private void LevelUp()
    {
        points = 0;
        currentMilestone++;
        inventory.GainCrowd(currentMilestone);
        onLevelUp.Invoke();
    }

    public void ResetMorale()
    {
        points = 0;
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public float ProgressToNextMilestone =>
        currentMilestone < milestones.Length ? points / milestones[currentMilestone] : 0;
}