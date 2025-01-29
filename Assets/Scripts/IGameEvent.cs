public interface IGameEvent
{
    public string RequestType { get; }
}

public struct AbilityEvent : IGameEvent
{
    public string RequestType { get; }
    public Ability Ability { get; set; }
    public Unit TargetUnit { get; set; }

    public AbilityEvent(Ability ability, Unit targetUnit)
    {
        RequestType = "use_ability";
        Ability = ability;
        TargetUnit = targetUnit;
    }
}