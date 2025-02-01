public class RegenerationEffect : AbilityEffect
{
    public RegenerationEffect(AbilityEffectType abilityEffectType, string title, int duration, bool isSelf, int count) : base(abilityEffectType, title, duration, isSelf)
    {
    }

    public override void Use(GameUnit unitId)
    {
        
    }
}