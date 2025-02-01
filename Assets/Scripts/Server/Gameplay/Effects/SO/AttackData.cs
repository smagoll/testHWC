using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Attack")]
public class AttackData : AbilityData
{
    [SerializeField]
    private int damage;

    public override Ability ConcreteAbility(AbilityType abilityType, string title, int cooldown, AbilityEffect[] abilityEffects)
    {
        return new Attack(abilityType, title, cooldown, abilityEffects, damage);
    }
}