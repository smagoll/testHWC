using System;

[Serializable]
public class Ability
{
    public AbilityType abilityType;
    public string name;
    public int cooldown;
    public int currentCooldown;
    public AbilityEffectType[] effects;

    public Ability(string name, int cooldown, AbilityEffectType[] effects)
    {
        this.name = name;
        this.cooldown = cooldown;
        this.effects = effects;
    }
}