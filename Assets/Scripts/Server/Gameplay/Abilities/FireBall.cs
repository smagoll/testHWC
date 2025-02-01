public class FireBall : Ability
{
    private int _damage;
    
    public FireBall(AbilityType abilityType, string title, int maxCooldown, AbilityEffect[] effects, int damage) : base(abilityType, title, maxCooldown, effects)
    {
    }

    protected override void Action(GameUnit selfUnit, GameUnit targetUnit)
    {
        targetUnit.TakeDamage(_damage);
    }
}