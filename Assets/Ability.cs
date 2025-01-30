using System;

[Serializable]
public class Ability
{
    public AbilityType AbilityType { get; protected set; }
    public string name;
    public int cooldown;
    public int currentCooldown;

    public Ability(AbilityType abilityType, string name, int cooldown)
    {
        
    }
    
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