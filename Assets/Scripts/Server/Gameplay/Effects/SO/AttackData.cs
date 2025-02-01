using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Attack")]
public class AttackData : AbilityData
{
    [SerializeField]
    private int damage;

    public override Ability GetAbility()
    {
        return new Attack(_abilityType, _title, _cooldown, _effects, damage);
    }
}