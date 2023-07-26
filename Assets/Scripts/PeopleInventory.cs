using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInventory : MonoBehaviour
{
    public List<Leader> leaders;
    public int crowdSize;

    //if player unlocked the pilot he will gain another one each milestone
    public void GainLeaders()
    {
        foreach (Leader leader in leaders)
        {
            if (leader.unlocked)
                leader.amount++;
        }
    }

    public void UnlockLeader(LeaderType leaderType)
    {
        leaders.Find(leader => leader.leaderType == leaderType).unlocked = true;
    }

    //returns if the player have the leaders required for a block
    public bool UseProtesters(List<Leader> RequiredProtesters)
    {
        //check if player have the leaders required
        foreach (Leader requiredLeader in RequiredProtesters)
        {
            Leader myLeader = leaders.Find(leader => leader.leaderType == requiredLeader.leaderType);

            if (!myLeader.unlocked || myLeader.amount < requiredLeader.amount)
                return false;
        }

        //player have the leaders required
        //update amounts acordingly
        foreach (Leader requiredLeader in RequiredProtesters)
        {
            Leader myLeader = leaders.Find(leader => leader.leaderType == requiredLeader.leaderType);
            myLeader.amount -= requiredLeader.amount;
        }

        return true;
    }
}
