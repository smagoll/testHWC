using System;

[Serializable]
public struct UpdateAbilityEvent
{
    public AbilityType abilityType;
    public int cooldown;

    public UpdateAbilityEvent(AbilityType abilityType, int cooldown)
    {
        this.abilityType = abilityType;
        this.cooldown = cooldown;
    }
}