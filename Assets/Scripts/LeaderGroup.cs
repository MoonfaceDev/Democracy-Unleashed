using System;

[Serializable]
public class LeaderGroup
{
    public LeaderType leaderType;
    public bool unlocked;
    public int amount;
}

public enum LeaderType
{
    Pilot,
    Student,
    Maid,
    Lawyer,
    Technician,
    Doctor
}