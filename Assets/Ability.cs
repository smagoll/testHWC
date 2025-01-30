using System;

[Serializable]
public class Ability
{
    public AbilityType abilityType;
    public string name;
    public int cooldown;
    public int currentCooldown;

    public void ReduceCooldown()
    {
        if (currentCooldown > 0)
            currentCooldown--;
    }

    public bool IsReady() => currentCooldown == 0;

    protected void StartCooldown()
    {
        currentCooldown = cooldown;
    }
}