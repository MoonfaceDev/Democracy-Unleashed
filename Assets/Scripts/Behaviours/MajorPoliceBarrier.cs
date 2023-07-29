public class MajorPoliceBarrier : PoliceBarrier
{
    protected override bool HasRequirements(PeopleInventory inventory)
    {
        return base.HasRequirements(inventory) && inventory.HasRequiredProtesters();
    }
}