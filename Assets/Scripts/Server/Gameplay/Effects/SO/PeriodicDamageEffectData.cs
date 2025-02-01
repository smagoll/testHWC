using UnityEngine;

[CreateAssetMenu(menuName = "AbilityEffect/PeriodicDamage")]
public class PeriodicDamageEffectData : AbilityEffectData
{
    public int damagePerStep;

    public override AbilityEffect GetAbilityEffect()
    {
        return new PeriodicDamageEffect(abilityEffectType, title, duration, isSelf);
    }
}