using UnityEngine;

public abstract class AbilityEffectData : ScriptableObject
{
    public AbilityEffectType abilityEffectType;
    public string title;
    public int duration;
    public bool isSelf;

    public abstract AbilityEffect GetAbilityEffect();
}