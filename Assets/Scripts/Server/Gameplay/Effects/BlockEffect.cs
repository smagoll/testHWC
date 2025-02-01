public class BlockEffect : AbilityEffect
{
    private int _blockDamage;
    
    public BlockEffect(AbilityEffectType abilityEffectType, string title, int duration, bool isSelf, int blockDamage) : base(abilityEffectType, title, duration, isSelf)
    {
        _blockDamage = blockDamage;
    }

    protected override void OnStart(GameUnit selfUnit)
    {
        selfUnit.AddBonusHealth(_blockDamage);
    }

    protected override void OnEnd(GameUnit selfUnit)
    {
        selfUnit.ClearBonusHealth();
    }

    protected override void Action(GameUnit selfUnit)
    {
        if (selfUnit.BonusHealth <= 0)
        {
            selfUnit.RemoveEffect(AbilityEffectType);
        }
    }
}