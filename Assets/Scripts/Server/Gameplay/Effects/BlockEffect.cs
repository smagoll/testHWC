public class BlockEffect : AbilityEffect
{
    public int BlockDamage { get; set; }
    
    public BlockEffect(AbilityEffectType abilityEffectType, string title, int duration, bool isSelf, int blockDamage) : base(abilityEffectType, title, duration, isSelf)
    {
        BlockDamage = blockDamage;
    }

    public override void Use(GameUnit selfUnit)
    {
        
    }
}