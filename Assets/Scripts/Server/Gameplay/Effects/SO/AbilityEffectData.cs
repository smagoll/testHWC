using UnityEngine;

public abstract class AbilityEffectData : ScriptableObject
{
    public AbilityEffectType abilityEffectType;
    public string title;
    public int duration;

    public abstract AbilityEffect GetAbilityEffect();
}