using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Regeneration")]
public class RegenerationData : AbilityData
{
    public override Ability ConcreteAbility(AbilityType abilityType, string title, int cooldown, AbilityEffect[] abilityEffects)
    {
        return new Regeneration(abilityType, title, cooldown, abilityEffects);
    }
}