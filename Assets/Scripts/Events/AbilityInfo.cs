using System;

[Serializable]
public struct AbilityInfo
{
    public AbilityType abilityType;
    public string title;
    public int cooldown;

    public AbilityInfo(AbilityType abilityType, string title, int cooldown)
    {
        this.abilityType = abilityType;
        this.title = title;
        this.cooldown = cooldown;
    }
}