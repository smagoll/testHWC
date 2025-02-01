using System;
using UnityEngine.Serialization;

[Serializable]
public struct AbilityEffectInfo
{
    public AbilityEffectType abilityEffectType;
    public string title;
    public int duration;

    public AbilityEffectInfo(AbilityEffectType abilityEffectType, string title, int duration)
    {
        this.abilityEffectType = abilityEffectType;
        this.title = title;
        this.duration = duration;
    }
}