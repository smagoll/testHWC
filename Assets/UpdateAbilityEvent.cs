using System;

[Serializable]
public struct UpdateAbilityEvent
{
    public string id;
    public AbilityType abilityType;
    public int cooldown;

    public UpdateAbilityEvent(string id, AbilityType abilityType, int cooldown)
    {
        this.id = id;
        this.abilityType = abilityType;
        this.cooldown = cooldown;
    }
}