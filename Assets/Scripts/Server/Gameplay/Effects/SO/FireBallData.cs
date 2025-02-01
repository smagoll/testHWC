using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/FireBall")]
public class FireBallData : AbilityData
{
    [SerializeField]
    private int damage;

    public override Ability ConcreteAbility(AbilityType abilityType, string title, int cooldown, AbilityEffect[] abilityEffects)
    {
        return new FireBall(abilityType, title, cooldown, abilityEffects, damage);
    }
}