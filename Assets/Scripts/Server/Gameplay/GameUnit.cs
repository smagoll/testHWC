using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

[Serializable]
public class GameUnit
{
    private bool _isTurn;
    
    public string id = Guid.NewGuid().ToString();
    public string name;
    public int health;
    public Ability[] abilities;
    public List<AbilityEffect> effects = new();

    public bool IsTurn
    {
        get => _isTurn;
        set
        {
            _isTurn = value;
            if (value) UpdateAbility();
        }
    }

    public GameUnit(string name, int health, Ability[] abilities)
    {
        this.name = name;
        this.health = health;
        this.abilities = abilities;
    }

    private void UpdateAbility()
    {
        foreach (var ability in abilities)
        {
            ability.ReduceCooldown();
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        EventBus.UpdateUnit?.Invoke(id, health);
    }

    public Ability GetAbility(AbilityType abilityType)
    {
        return abilities.FirstOrDefault(x => x.AbilityType == abilityType);
    }

    public void RemoveEffect(AbilityEffectType abilityEffectType)
    {
        var abilityEffect = effects.FirstOrDefault(x => x.AbilityEffectType == abilityEffectType);
        if (abilityEffect != null) effects.Remove(abilityEffect);
    }

    public void ClearEffects()
    {
        effects.Clear();
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