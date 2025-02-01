using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

public class GameUnit
{
    private string _id = Guid.NewGuid().ToString();
    private string _name;
    private int _health;
    private Ability[] _abilities;
    private List<AbilityEffect> _effects = new();
    private bool _isTurn;

    private int _bonusHealth;

    public string Id => _id;
    public string Name => _name;
    public int Health => _health;
    public int BonusHealth => _bonusHealth;
    public Ability[] Abilities => _abilities;
    public List<AbilityEffect> Effects => _effects;
    public bool IsTurn
    {
        get => _isTurn;
        set
        {
            _isTurn = value;
            if (value) Turn();
        }
    }

    public GameUnit(string name, int health, Ability[] abilities)
    {
        _name = name;
        _health = health;
        _abilities = abilities;
    }

    private void Turn()
    {
        ApplyEffects();
        UpdateAbility();
        ResponseEventBus.UpdateUnitResponse?.Invoke(_id, _health, _effects.ToArray());
    }
    
    private void UpdateAbility()
    {
        foreach (var ability in Abilities)
        {
            ability.ReduceCooldown();
        }
    }
    
    private void ApplyEffects()
    {
        foreach (var effect in _effects.ToList())
        {
            effect.Reduce(this);
            if (effect.IsDeleted) _effects.Remove(effect);
        }
    }
    
    public void TakeDamage(int damage)
    {
        if (_bonusHealth > 0)
        {
            _bonusHealth -= damage;
            if (_bonusHealth < 0)
            {
                _health += _bonusHealth;
                _bonusHealth = 0;
            }
        }
        else
        {
            _health -= damage;
        }
        
        ResponseEventBus.UpdateUnitResponse?.Invoke(_id, _health, _effects.ToArray());
    }

    public void AddHealth(int health)
    {
        _health += health;
        ResponseEventBus.UpdateUnitResponse?.Invoke(_id, _health, _effects.ToArray());
    }
    
    public void AddBonusHealth(int health)
    {
        _bonusHealth = health;
    }

    public void ClearBonusHealth()
    {
        _bonusHealth = 0;
    }

    public Ability GetAbility(AbilityType abilityType)
    {
        return _abilities.FirstOrDefault(x => x.AbilityType == abilityType);
    }

    public void RemoveEffect(AbilityEffectType abilityEffectType)
    {
        var abilityEffect = _effects.FirstOrDefault(x => x.AbilityEffectType == abilityEffectType);
        if (abilityEffect != null) _effects.Remove(abilityEffect);
        ResponseEventBus.UpdateUnitResponse?.Invoke(_id, _health, _effects.ToArray());
    }
    
    public void AddEffect(AbilityEffect abilityEffect)
    {
        _effects.Add(abilityEffect);
        abilityEffect.Apply(this);
        ResponseEventBus.UpdateUnitResponse?.Invoke(_id, _health, _effects.ToArray());
    }
}