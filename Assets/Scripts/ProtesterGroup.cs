using System;
using UnityEngine.Serialization;

[Serializable]
public class ProtesterGroup
{
    public enum Type
    {
        Pilot,
        Student,
        Maid,
        Lawyer,
        Technician,
        Doctor
    }

    [FormerlySerializedAs("leaderType")] public Type type;
    public bool unlocked;
    [FormerlySerializedAs("amount")] public int size;

    public ProtesterGroup(Type type)
    {
        this.type = type;
        unlocked = false;
        size = 0;
    }
}