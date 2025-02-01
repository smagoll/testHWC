public abstract class Ability
{
    private AbilityType _abilityType;
    private string _title;
    private int _maxCooldown;
    private int _cooldown;
    private AbilityEffectType[] _effects;

    public AbilityType AbilityType => _abilityType;
    public string Title => _title;
    public int Cooldown => _cooldown;

    public bool IsReady => _cooldown == 0;

    protected Ability(AbilityType abilityType, string title, int maxCooldown, AbilityEffectType[] effects)
    {
        _abilityType = abilityType;
        _title = title;
        _maxCooldown = maxCooldown;
        _effects = effects;
    }

    public void ReduceCooldown()
    {
        if (_cooldown > 0)
        {
            _cooldown--;
        }
    }

    public void Use(GameUnit selfUnit, GameUnit targetUnit)
    {
        if (IsReady)
        {
            _cooldown = _maxCooldown;
            Action(selfUnit, targetUnit);
            UseEffects(selfUnit, targetUnit);
        }
    }

    private void UseEffects(GameUnit selfUnit, GameUnit targetUnit)
    {
        foreach (var abilityEffect in _effects)
        {
            GameplayEventBus.ApplyEffect?.Invoke(abilityEffect, selfUnit, targetUnit);
        }
    }

    protected abstract void Action(GameUnit selfUnit, GameUnit targetUnit);
}