using System;

[Serializable]
public abstract class AbilityEffect
{
    public AbilityEffect(AbilityEffectType abilityEffectType, string title, int duration, bool isSelf)
    {
        _abilityEffectType = abilityEffectType;
        _title = title;
        _duration = duration;
        _isSelf = isSelf;
    }

    private AbilityEffectType _abilityEffectType;
    private string _title;
    private int _duration;
    private bool _isSelf;

    public AbilityEffectType AbilityEffectType => _abilityEffectType;
    public string Title => _title;
    public bool IsSelf => _isSelf;

    public abstract void Use(GameUnit selfUnit);
}