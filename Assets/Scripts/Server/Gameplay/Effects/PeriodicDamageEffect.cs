public class PeriodicDamageEffect : AbilityEffect
{
    private int _damagePerTick;
    
    public PeriodicDamageEffect(AbilityEffectType abilityEffectType, string title, int duration, bool isSelf, int damagePerTick) : base(abilityEffectType, title, duration, isSelf)
    {
        _damagePerTick = damagePerTick;
    }

    protected override void OnStart(GameUnit selfUnit)
    {
        
    }

    protected override void OnEnd(GameUnit selfUnit)
    {
        
    }

    protected override void Action(GameUnit selfUnit)
    {
        selfUnit.TakeDamage(_damagePerTick);
    }
}