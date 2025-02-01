using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Regeneration")]
public class RegenerationData : AbilityData
{
    public override Ability GetAbility()
    {
        return new Regeneration(_abilityType, _title, _cooldown, _effects);
    }
}