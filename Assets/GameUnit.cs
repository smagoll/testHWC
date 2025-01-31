using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

[Serializable]
public class GameUnit
{
    public string id = Guid.NewGuid().ToString();
    public string name;
    public int health;
    public Ability[] abilities;
    public List<AbilityEffect> effects = new();
    public bool IsTurn { get; set; }

    public GameUnit(string name, int health, Ability[] abilities)
    {
        this.name = name;
        this.health = health;
        this.abilities = abilities;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        EventBus.UpdateUnit?.Invoke(id, health);
    }

    public Ability GetAbility(AbilityType abilityType)
    {
        return abilities.FirstOrDefault(x => x.abilityType == abilityType);
    }

    public void RemoveEffect(AbilityEffectType abilityEffectType)
    {
        var abilityEffect = effects.FirstOrDefault(x => x.abilityEffectType == abilityEffectType);
        if (abilityEffect != null) effects.Remove(abilityEffect);
    }
    
    public void AddEffect(AbilityEffect abilityEffect)
    {
        effects.Add(abilityEffect);
    }

    public void ApplyEffects()
    {
        foreach (var abilityEffect in effects)
        {
            abilityEffect.Use(this);
        }
    }
}