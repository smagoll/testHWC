using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/FireBall")]
public class FireBallData : AbilityData
{
    [SerializeField]
    private int damage;

    public override Ability GetAbility()
    {
        return new FireBall(_abilityType, _title, _cooldown, _effects, damage);
    }
}