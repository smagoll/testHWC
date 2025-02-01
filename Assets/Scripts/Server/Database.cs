using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Database")]
public class Database : ScriptableObject
{
    [SerializeField]
    private AbilityData[] abilities;
    [SerializeField]
    private AbilityEffectData[] abilityEffects;

    public Ability GetAbility(AbilityType abilityType)
    {
        var abilityData = abilities.FirstOrDefault(x => x.AbilityType == abilityType);

        return abilityData != null ? abilityData.GetAbility() : null;
    }
    
    public AbilityEffect GetEffect(AbilityEffectType abilityEffectType)
    {
        var abilityEffectData = abilityEffects.FirstOrDefault(x => x.abilityEffectType == abilityEffectType);

        return abilityEffectData != null ? abilityEffectData.GetAbilityEffect() : null;
    }
}