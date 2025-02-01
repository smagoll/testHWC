public class Regeneration : Ability
{
    public Regeneration(AbilityType abilityType, string title, int maxCooldown, AbilityEffectType[] effects) : base(abilityType, title, maxCooldown, effects)
    {
    }

    protected override void Action(GameUnit selfUnit, GameUnit targetUnit)
    {
        
    }
}