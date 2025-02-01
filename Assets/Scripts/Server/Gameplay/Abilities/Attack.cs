public class Attack : Ability
{
    private int _damage;
    
    public Attack(AbilityType abilityType, string title, int maxCooldown, AbilityEffectType[] effects, int damage) : base(abilityType, title, maxCooldown, effects)
    {
        _damage = damage;
    }

    protected override void Action(GameUnit selfUnit, GameUnit targetUnit)
    {
        targetUnit.TakeDamage(_damage);
    }
}