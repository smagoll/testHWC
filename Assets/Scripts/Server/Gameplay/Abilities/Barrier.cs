﻿public class Barrier : Ability
{
    public Barrier(AbilityType abilityType, string title, int maxCooldown, AbilityEffectType[] effects) : base(abilityType, title, maxCooldown, effects)
    {
    }

    protected override void Action(GameUnit selfUnit, GameUnit targetUnit)
    {
        
    }
}