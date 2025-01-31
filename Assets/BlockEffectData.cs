using UnityEngine;

[CreateAssetMenu(menuName = "AbilityEffect/Block")]
public class BlockEffectData : AbilityEffectData
{
    public override AbilityEffect GetAbilityEffect()
    {
        return new BlockEffect(abilityEffectType, title, duration);
    }
}