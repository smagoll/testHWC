using System;

[Serializable]
public abstract class AbilityEffect
{
    public AbilityEffect(AbilityEffectType abilityEffectType, string title, int duration)
    {
        this.abilityEffectType = abilityEffectType;
        this.title = title;
        this.duration = duration;
    }

    public AbilityEffectType abilityEffectType;
    public string title;
    public int duration;

    public abstract void Use(GameUnit unitId);
}