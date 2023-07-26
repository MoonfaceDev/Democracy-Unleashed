using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leader
{
    public LeaderType leaderType;
    public bool unlocked;
    public int amount;
}

public enum LeaderType { pilot, student, maid, lawyer, technician, doctor}
