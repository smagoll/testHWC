using System;

[Serializable]
public struct UpdateUnitEvent
{
    public string id;
    public int health;
    public AbilityEffectInfo[] abilityEffects;

    public UpdateUnitEvent(string id, int health, AbilityEffectInfo[] abilityEffects)
    {
        this.id = id;
        this.health = health;
        this.abilityEffects = abilityEffects;
    }
}