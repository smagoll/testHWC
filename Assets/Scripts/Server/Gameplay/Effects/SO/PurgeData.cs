using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Purge")]
public class PurgeData : AbilityData
{
    public override Ability GetAbility()
    {
        return new Purge(_abilityType, _title, _cooldown, _effects);
    }
}