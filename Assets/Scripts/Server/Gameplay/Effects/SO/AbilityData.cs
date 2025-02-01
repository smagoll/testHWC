using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public abstract class AbilityData : ScriptableObject
{
    [SerializeField]
    private AbilityType _abilityType;
    [SerializeField]
    private string _title;
    [SerializeField]
    private int _cooldown;
    [SerializeField]
    private AbilityEffectType[] _effects;

    public AbilityType AbilityType => _abilityType;

    public Ability GetAbility(AbilityEffectData[] abilityEffectDatas)
    {
        var abilityEffects = _effects
            .SelectMany(effectType => abilityEffectDatas
                .Where(x => x.abilityEffectType == effectType)
                .Select(x => x.GetAbilityEffect()))
            .ToArray();
        
        return ConcreteAbility(_abilityType, _title, _cooldown, abilityEffects);
    }

    public abstract Ability ConcreteAbility(AbilityType abilityType, string title, int cooldown, AbilityEffect[] abilityEffects);
}