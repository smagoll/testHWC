using System;

public static class EventBus
{
    public static Action<AbilityType, int> UpdateAbility;
    public static Action<string, int> UpdateUnit;
}