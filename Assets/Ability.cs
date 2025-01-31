using System;
using UnityEngine.Serialization;

[Serializable]
public class Ability
{
    public AbilityType abilityType;
    public string name;
    public int damage;
    public int maxCooldown;
    public int cooldown;
    public AbilityEffectType[] effects;

    public bool IsReady => cooldown == 0;

    public Ability(AbilityType abilityType, string name, int damage, int maxCooldown, AbilityEffectType[] effects)
    {
        this.abilityType = abilityType;
        this.damage = damage;
        this.name = name;
        this.maxCooldown = maxCooldown;
        this.effects = effects;
    }

    public void ReduceCooldown()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
    }

    public void Use()
    {
        if (IsReady)
        {
            cooldown = maxCooldown;
        }
    }
}