public class RegenerationEffect : AbilityEffect
{
    private int _countPerTurn;
    
    public RegenerationEffect(AbilityEffectType abilityEffectType, string title, int duration, bool isSelf, int countPerTurn) : base(abilityEffectType, title, duration, isSelf)
    {
        _countPerTurn = countPerTurn;
    }

    protected override void OnStart(GameUnit selfUnit)
    {
        
    }

    protected override void OnEnd(GameUnit selfUnit)
    {
        
    }

    protected override void Action(GameUnit selfUnit)
    {
        selfUnit.AddHealth(_countPerTurn);
    }
}