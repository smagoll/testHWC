using UnityEngine;

[CreateAssetMenu(menuName = "AbilityEffect/PeriodicDamage")]
public class PeriodicDamageEffectData : AbilityEffectData
{
    [SerializeField]
    private int _damagePerTurn;

    public override AbilityEffect GetAbilityEffect()
    {
        return new PeriodicDamageEffect(abilityEffectType, title, duration, isSelf, _damagePerTurn);
    }
}