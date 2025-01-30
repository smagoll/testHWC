using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Database")]
public class Database : ScriptableObject
{
    public AbilityData[] abilities;
    public AbilityEffectData[] abilityEffects;

    public Ability GetAbility(AbilityType abilityType)
    {
        var abilityData = abilities.FirstOrDefault(x => x.abilityType == abilityType);

        return abilityData != null ? new Ability(abilityData.abilityType, abilityData.title, abilityData.damage, abilityData.cooldown, abilityData.effects) : null;
    }
}