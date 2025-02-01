public class Purge : Ability
{
    public Purge(AbilityType abilityType, string title, int maxCooldown, AbilityEffect[] effects) : base(abilityType, title, maxCooldown, effects)
    {
    }

    protected override void Action(GameUnit selfUnit, GameUnit targetUnit)
    {
        selfUnit.ClearEffects();
    }
}