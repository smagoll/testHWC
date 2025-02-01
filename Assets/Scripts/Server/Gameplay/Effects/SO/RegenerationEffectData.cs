using UnityEngine;

[CreateAssetMenu(menuName = "AbilityEffect/Regeneration")]
public class RegenerationEffectData : AbilityEffectData
{
    public int count;

    public override AbilityEffect GetAbilityEffect()
    {
        return new RegenerationEffect(abilityEffectType, title, duration, isSelf, count);
    }
}