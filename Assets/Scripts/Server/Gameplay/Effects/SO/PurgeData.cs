using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Purge")]
public class PurgeData : AbilityData
{
    public override Ability ConcreteAbility(AbilityType abilityType, string title, int cooldown, AbilityEffect[] abilityEffects)
    {
        return new Purge(abilityType, title, cooldown, abilityEffects);
    }
}