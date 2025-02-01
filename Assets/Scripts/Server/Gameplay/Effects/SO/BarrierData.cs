using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Barrier")]
public class BarrierData : AbilityData
{
    public override Ability ConcreteAbility(AbilityType abilityType, string title, int cooldown, AbilityEffect[] abilityEffects)
    {
        return new Barrier(abilityType, title, cooldown, abilityEffects);
    }
}