public class BlockEffect : AbilityEffect
{
    public int BlockDamage { get; set; }
    
    public BlockEffect(AbilityEffectType abilityEffectType, string title, int duration, int blockDamage) : base(abilityEffectType, title, duration)
    {
        BlockDamage = blockDamage;
    }
    
    public override void Use(GameUnit unitId)
    {
        
    }
}