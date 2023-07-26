using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PeopleInventory : MonoBehaviour
{
    public List<Leader> leaders;
    public int crowdSize;
    public CrowdCounter crowdUI;

    private void Update()
    {
        crowdUI.SetScore(crowdSize);
    }

    //if player unlocked the pilot he will gain another one each milestone
    public void GainLeaders()
    {
        foreach (var leader in leaders.Where(leader => leader.unlocked))
        {
            leader.amount++;
        }
    }

    public void UnlockLeader(LeaderType leaderType)
    {
        leaders.Find(leader => leader.leaderType == leaderType).unlocked = true;
    }

    //returns if the player have the leaders required for a block
    public bool UseProtesters(List<Leader> requiredProtesters)
    {
        //check if player have the leaders required
        foreach (var requiredLeader in requiredProtesters)
        {
            var myLeader = leaders.Find(leader => leader.leaderType == requiredLeader.leaderType);

            if (!myLeader.unlocked || myLeader.amount < requiredLeader.amount)
                return false;
        }

        //player have the leaders required
        //update amounts accordingly
        foreach (var requiredLeader in requiredProtesters)
        {
            var myLeader = leaders.Find(leader => leader.leaderType == requiredLeader.leaderType);
            myLeader.amount -= requiredLeader.amount;
        }

        return true;
    }
}