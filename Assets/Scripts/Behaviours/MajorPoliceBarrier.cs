using System;
using System.Collections.Generic;

[Serializable]
public class ProtesterRequirement
{
    public ProtesterGroup.Type type;
    public int size;
}

public class MajorPoliceBarrier : PoliceBarrier
{
    public List<ProtesterRequirement> requiredProtesters;

    protected override bool HasRequirements(PeopleInventory inventory)
    {
        return base.HasRequirements(inventory) && inventory.HasRequiredProtesters(requiredProtesters);
    }

    protected override void Retreat(PeopleInventory inventory)
    {
        inventory.UseProtesters(requiredProtesters);
        base.Retreat(inventory);
    }
}