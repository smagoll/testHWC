using System;

public static class EventBus
{
    public static Action<string, AbilityType, int> UpdateAbility;
    public static Action<string, int> UpdateUnit;
    public static Action<AbilityType, string, string> UseAbility;
}