using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "AbilityEffect/Regeneration")]
public class RegenerationEffectData : AbilityEffectData
{
    [SerializeField]
    private int _countPerTurn;

    public override AbilityEffect GetAbilityEffect()
    {
        return new RegenerationEffect(abilityEffectType, title, duration, isSelf, _countPerTurn);
    }
}