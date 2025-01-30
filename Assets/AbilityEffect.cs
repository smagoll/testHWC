using System;

[Serializable]
public abstract class AbilityEffect
{
    public int duration;

    public abstract void Use(GameUnit unitId);
}