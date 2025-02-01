using System;

[Serializable]
public abstract class AbilityEffect
{
    public AbilityEffect(AbilityEffectType abilityEffectType, string title, int duration, bool isSelf)
    {
        _abilityEffectType = abilityEffectType;
        _title = title;
        _duration = duration;
        _currentDuration = duration;
        _isSelf = isSelf;
    }

    private AbilityEffectType _abilityEffectType;
    private string _title;
    private int _duration;
    private int _currentDuration;
    private bool _isSelf;

    public AbilityEffectType AbilityEffectType => _abilityEffectType;
    public string Title => _title;
    public bool IsSelf => _isSelf;
    public bool IsDeleted { get; set; }
    public int Duration => _currentDuration;

    public void Apply(GameUnit selfUnit)
    {
        StartEffect(selfUnit);
    }

    public void Reduce(GameUnit selfUnit)
    {
        _currentDuration--;
        Action(selfUnit);
        
        if(_currentDuration <= 0) EndEffect(selfUnit);
    }

    private void StartEffect(GameUnit selfUnit)
    {
        OnStart(selfUnit);
    }

    private void EndEffect(GameUnit selfUnit)
    {
        IsDeleted = true;
        OnEnd(selfUnit);
    }

    protected abstract void OnStart(GameUnit selfUnit);
    protected abstract void OnEnd(GameUnit selfUnit);
    protected abstract void Action(GameUnit selfUnit);
}