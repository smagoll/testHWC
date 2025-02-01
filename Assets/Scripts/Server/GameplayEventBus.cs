using System;

public static class GameplayEventBus
{
    public static Action<AbilityEffectType, GameUnit, GameUnit> ApplyEffect;
}