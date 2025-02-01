using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Barrier")]
public class BarrierData : AbilityData
{
    public override Ability GetAbility()
    {
        return new Barrier(_abilityType, _title, _cooldown, _effects);
    }
}