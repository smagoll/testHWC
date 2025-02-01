using System;

public static class ResponseEventBus
{
    public static Action<string, AbilityType, int> UpdateAbilityResponse;
    public static Action<string, int, AbilityEffect[]> UpdateUnitResponse;
    public static Action<AbilityType, string, string> UseAbilityResponse;
}